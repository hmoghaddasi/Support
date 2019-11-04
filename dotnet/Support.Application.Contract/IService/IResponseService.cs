using System.Collections.Generic;
using Framework.Core.OnionClass;
using Support.Application.Contract.DTO;

namespace Support.Application.Contract.IService
{
    public interface IResponseService : IApplicationService
    {

        List<ResponseDTO> GetAll(int requestId,string userName);
        BaseResponseDTO Create(ResponseCreateDTO dto, string userName);
        BaseResponseDTO Delete(int responseId, string userName);
    }
}