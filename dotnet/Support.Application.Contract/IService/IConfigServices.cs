using System.Collections.Generic;
using Framework.Core.Filtering;
using Framework.Core.OnionClass;
using Support.Application.Contract.DTO;

namespace Support.Application.Contract.IService
{
    public interface IConfigService : IApplicationService
    {
        ConfigDTO GetById(int Id);
        BaseResponseDTO Create(ConfigDTO config);
        BaseResponseDTO Edit(ConfigDTO config);
        BaseResponseDTO Delete(int Id);
        List<ConfigDTO> GetConfigChild(int id, string user);
        FilterResponse<ConfigDTO> GetForGrid(GridRequestWithArgument request);
    }
}
