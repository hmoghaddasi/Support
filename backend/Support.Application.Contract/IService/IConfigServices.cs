using System.Collections.Generic;
using System.Linq;
using Support.Application.Contract.DTO;

namespace Support.Application.Contract.IService
{
    public interface IConfigService : IApplicationService
    {
        List<ConfigDTO> GetAll();
        ConfigDTO GetById(int Id);
        List<ConfigDTO> GetParent(int Id);
        List<ConfigDTO> GetChild(int parentId, int related);
        void CreateOrUpdate(ConfigDTO config);
        void Delete(int Id);
        ConfigParentDTO GetConfigParent();
    }
}
