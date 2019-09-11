using System.Collections.Generic;
using System.Linq;
using Support.Application.Contract.DTO;
using Support.Application.Contract.Grid;

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
        FilterResponse<ConfigDTO> GetForGrid(GridRequest request);
    }
}
