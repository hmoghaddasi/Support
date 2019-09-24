using System;
using System.Collections.Generic;
using System.Linq;
using Framework.Core.Filtering;
using Support.Application.Contract.Constant;
using Support.Application.Contract.DTO;
using Support.Application.Contract.IService;
using Support.Application.Mapper;
using Support.Domain.IRepository;

namespace Support.Application.Service
{
    public class ConfigService : IConfigService
    {
        private readonly IConfigRepository _repository;
        private readonly IAccessPolicyServices _accessPolicyServices;
        public ConfigService(IConfigRepository repository, IAccessPolicyServices accessPolicyServices)
        {
            this._repository = repository;
            this._accessPolicyServices = accessPolicyServices;
        }
      
        
        public ConfigDTO GetById(int Id)
        {
            var config = _repository.GetById(Id);
            return ConfigMapper.Map(config);
        }
       

        public BaseResponseDTO Create(ConfigDTO dto)
        {
            _repository.Create(ConfigMapper.MapToModel(dto));
            return BaseResponseHelper.Success();
        }
        public BaseResponseDTO Edit(ConfigDTO dto)
        {
            var model = _repository.GetById(dto.ConfigId);
            var data = ConfigMapper.MapToEditModel(model, dto);
            _repository.Edit(data);
            return BaseResponseHelper.Success();
        }
        public BaseResponseDTO Delete(int id)
        {
            _repository.Delete(_repository.GetById(id));
            return BaseResponseHelper.Success();
        }

      

        public List<ConfigDTO> GetConfigChild(int id, string user)
        {
            var accessBasedConfig = _accessPolicyServices.GetAccessBasedConfig(user);

            return _repository.Get(a => a.ConfigHdrId == id && a.ConfigId != 0
                                        && (accessBasedConfig.Contains(a.ConfigValue) || id != ConfigType.Project)
                                        ).Select(ConfigMapper.Map).ToList();
           
        }

        public FilterResponse<ConfigDTO> GetForGrid(GridRequestWithArgument request)
        {
            throw new NotImplementedException();
        }
    }
}
