using System.Linq;
using Framework.Core.Filtering;
using Support.Application.Contract.Constant;
using Support.Application.Contract.DTO;
using Support.Application.Contract.IService;
using Support.Application.Mapper;
using Support.Domain.Exception;
using Support.Domain.IRepository;
using Support.Domain.Model;

namespace Support.Application.Service
{
    public class RequestService : IRequestService
    {
        private readonly IRequestRepository _requestRepository;
        private readonly IPersonServices _personService;
        private readonly IAccessPolicyServices _accessPolicyService;
        private readonly INotificationService _notificationService;
        public RequestService(IRequestRepository requestRepository, IPersonServices personService, IAccessPolicyServices accessPolicyService, INotificationService notificationService)
        {
            this._requestRepository = requestRepository;
            this._personService = personService;
            this._accessPolicyService = accessPolicyService;
            this._notificationService = notificationService;
        }

        public BaseResponseDTO Create(RequestCreateDTO dto, string userName)
        {
            var user = _personService.GetByUserName(userName);
            var admin = _personService.GetById(0);
            _requestRepository.Create(RequestMapper.MapToModel(dto, user.PersonId));
            this._notificationService.CreateNewTicket(admin.Mobile,$"{user.FirstName}", dto.Title);
            return BaseResponseHelper.Success();
        }

        public BaseResponseDTO Delete(int requestId)
        {
            var requestToDelete = _requestRepository.GetById(requestId);
            if (requestToDelete == null)
            {
                throw new RequestNotFoundException();
            }
            _requestRepository.Delete(requestId);
            return BaseResponseHelper.Success();
        }

        public RequestDetailDTO GetDetail(int id, string user)
        {
            var request = _requestRepository.GetByIdExtended(id);
            if (request == null)
            {
                throw new RequestNotFoundException();
            }
            var personId = _personService.GetPersonByLogin(user);
            if (personId != request.RequestById && personId != 0)
            {
                throw new InvalidDataAccessException();
            }
            return RequestMapper.MapDto(request);

        }

        public FilterResponse<RequestDTO> GetForGrid(GridRequest request)
        {
            var result = _requestRepository.GetForGrid(request, null);
            return new FilterResponse<RequestDTO>(result.data.Select(RequestMapper.Map).ToList(), result.total);
        }

        public FilterResponse<RequestDTO> GetForGrid(GridRequest request, string userName)
        {
            var result = _requestRepository.GetForGrid(request, a => a.RequestBy.LoginName == userName);
            return new FilterResponse<RequestDTO>(result.data.Select(RequestMapper.Map).ToList(), result.total);
        }

        public Request GetRequestById(int requestId)
        {
            return _requestRepository.GetById(requestId);
        }

        public BaseResponseDTO UpdateStatus(int id)
        {
            var request = _requestRepository.GetById(id);
            if (request == null)
            {
                throw new RequestNotFoundException();
            }
            request.StatusId = RequestStatus.Close;
            _requestRepository.Edit(request);
            return BaseResponseHelper.Success();
        }
    }
}
