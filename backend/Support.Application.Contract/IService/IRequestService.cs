using System.Collections.Generic;
using Framework.Core.Filtering;
using Support.Application.Contract.DTO;

namespace Support.Application.Contract.IService
{
    public interface IRequestService : IApplicationService
    {
        FilterResponse<RequestDTO> GetForGrid(GridRequest request);
        BaseResponseDTO Delete(int requestId);
        FilterResponse<RequestDTO> GetForGrid(GridRequest request, string userName);
        BaseResponseDTO Create(RequestCreateDTO dto, string userName);
        BaseResponseDTO UpdateStatus(int id);

    }
}