using System.Collections.Generic;
using System.Linq;
using Support.Application.Contract.DTO;
using Support.Application.Contract.Grid;
using Support.Domain.Model;

namespace Support.Application.Contract.IService
{
    public interface IRequestServices : IApplicationService
    {
        List<RequestListDTO> GetAll();
        FilterResponse<RequestListDTO> GetAllFilter(GridRequest request);
        RequestEditDTO GetById(int Id);
        void Create(RequestCreateDTO config);
        void Delete(int Id);
        List<RequestDTO> GetCustomerRequests(int personId, string userName);
        List<RequestDTO> GetAllRequestResponcesById(int personId, string userName);
    }
}
