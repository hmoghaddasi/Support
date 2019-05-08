using System.Collections.Generic;
using System.Linq;
using Support.Application.Contract.DTO;
using Support.Application.Contract.IService;
using Support.Application.Mapper;
using Support.Domain.IRepository;

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
        public RequestDTO GetById(int requestId)
        {
            return RequestMapper.Map(_requestRepository.Get(a => a.RequestId == requestId).First());
        }

        //public FilterResponse<RequestDTO> GetAllFilter(GridRequest request)
        //{
        //    var result = _requestRepository.GetAll().Select(RequestMapper.Map).AsQueryable();
        //    var data = result.ApplyFilters(request, false);
        //    return new FilterResponse<RequestDTO>(data.Data, data.Count);
        //}

        public List<RequestDTO> GetAll()
        {
            return _requestRepository.GetAll().Select(RequestMapper.Map).ToList();

        }

        public void Delete(int requestId)
        {
            _requestRepository.Delete(requestId);
        }

        public List<RequestDTO> GetCustomerRequests(int personId, string userName)
        {
            return _requestRepository
                .Get(a => (personId == SelectedPerson.Unknown && a.RequestBy.LoginName == userName) || a.RequestById == personId)
                .Select(RequestMapper.Map).ToList();

        }

        public void Create(RequestDTO dto, string userName)
        {
            dto.AssignedId = _accessPolicyService.FindRequestAdmin();
            dto.RequestById = _personService.GetPersonByLogin(userName);
            dto.StatusId = RequestStatus.New;
            _requestRepository.Create(RequestMapper.MapToModel(dto));
        }

        public List<RequestDTO> GetAllRequestResponcesById(int personId, string userName)
        {

            var model = _requestRepository
                .Get(a => a.RequestById == personId || a.AssignedId == personId)
                .Select(RequestMapper.Map).ToList();
            return model;
        }


    }
}
