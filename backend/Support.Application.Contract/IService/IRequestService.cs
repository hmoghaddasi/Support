using System.Collections.Generic;
using Support.Application.Contract.DTO;
using Support.Application.Contract.Grid;

namespace Support.Application.Contract.IService
{
    public interface IRequestService : IApplicationService
    {

        RequestDTO GetById(int requestId);
        FilterResponse<RequestDTO> GetAllFilter(GridRequest request);
        List<RequestDTO> GetAll();
        void Delete(int requestId);
        List<RequestDTO> GetCustomerRequests(int personId, string userName);
        void Create(RequestDTO dto, string userName);
        List<RequestDTO> GetAllRequestResponcesById(int personId, string userName);
    }
}