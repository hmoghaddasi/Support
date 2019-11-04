using Framework.Core.Filtering;
using Framework.Core.OnionClass;
using Support.Application.Contract.DTO;
using Support.Domain.Model;

namespace Support.Application.Contract.IService
{
    public interface IRequestService : IApplicationService
    {
        FilterResponse<RequestDTO> GetForGrid(GridRequest request);
        BaseResponseDTO Delete(int requestId);
        FilterResponse<RequestDTO> GetForGrid(GridRequest request, string userName);
        BaseResponseDTO Create(RequestCreateDTO dto, string userName);
        BaseResponseDTO UpdateStatus(int id);
        RequestDetailDTO GetDetail(int id, string user);
        Request GetRequestById(int requestId);
    }
}