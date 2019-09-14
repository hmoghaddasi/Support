using System.Collections.Generic;
using System.Linq;
using Framework.Core.Filtering;
using Support.Application.Contract.DTO;

namespace Support.Application.Contract.IService
{
    public interface IConfigService : IApplicationService
    {
        List<ConfigDTO> GetAll();
        ConfigDTO GetById(int Id);
        List<ConfigDTO> GetParent(int Id);
        List<ConfigDTO> GetChild(int parentId);
        BaseResponseDTO Create(ConfigDTO config);
        BaseResponseDTO Edit(ConfigDTO config);
        BaseResponseDTO Delete(int Id);
        ConfigParentDTO GetConfigParent();
        List<ConfigDTO> GetConfigChildsByParentId(int id);
        FilterResponse<ConfigDTO> GetForGrid(GridRequestWithArgument request);
    }
}
