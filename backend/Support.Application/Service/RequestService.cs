using System.Collections.Generic;
using System.Linq;
using Framework.Core.Filtering;
using Support.Application.Contract.Constant;
using Support.Application.Contract.DTO;
using Support.Application.Contract.IService;
using Support.Application.Mapper;
using Support.Domain.Exception;
using Support.Domain.IRepositories;

namespace Support.Application.Service
{
    public class RequestService : IRequestService
    {
        private readonly IRequestRepository _requestRepository;
        private readonly IPersonServices _personService;
        private readonly IAccessPolicyServices _accessPolicyService;
        public RequestService(IRequestRepository requestRepository, IPersonServices personService, IAccessPolicyServices accessPolicyService)
        {
            this._requestRepository = requestRepository;
            this._personService = personService;
            this._accessPolicyService = accessPolicyService;
        }

        public BaseResponseDTO Create(RequestCreateDTO dto, string userName)
        {
            var personId = _personService.GetPersonByLogin(userName);
            _requestRepository.Create(RequestMapper.MapToModel(dto, personId));
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

        public RequestListDTO GetDetail(int id, string user)
        {
            var request = _requestRepository.GetById(id);
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
