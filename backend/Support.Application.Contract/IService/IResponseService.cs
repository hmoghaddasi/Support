using System.Collections.Generic;
using Support.Application.Contract.DTO;
using Support.Application.Contract.Grid;

namespace Support.Application.Contract.IService
{
    public interface IResponseService : IApplicationService
    {

        ResponseDTO GetById(int responseId);
        FilterResponse<ResponseDTO> GetAllFilter(GridRequest request);
        List<ResponseDTO> GetAll();
        void Create(ResponseDTO dto, string userName);

        void Delete(int responseId);

        List<ResponseDTO> GetResponseByRequest(int requestId, bool showPrivate);
    }
}