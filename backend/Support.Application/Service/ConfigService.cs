using System;
using System.Collections.Generic;
using System.Linq;
using Support.Application.Contract.DTO;
using Support.Application.Contract.Grid;
using Support.Application.Contract.IService;
using Support.Application.Mapper;
using Support.Domain.IRepositories;

namespace Support.Application.Service
{
    public class ConfigService : IConfigService
    {
        private readonly IConfigRepository _repository;
        public ConfigService(IConfigRepository repository)
        {
            this._repository = repository;
        }
        public List<ConfigDTO> GetConfigName()
        {
            return _repository.Get(w => w.ConfigHdrId == 0).Select(ConfigMapper.Map).ToList();
            
        }
        public List<ConfigDTO> GetAll()
        {
            return
                 _repository.GetAll().Select(ConfigMapper.Map)
                     .ToList();
        }
        public IQueryable<ConfigDTO> GetAllIQueryable()
        {
            return
                _repository.GetAll().Select(ConfigMapper.Map)
                    .AsQueryable();
        }
        public ConfigDTO GetById(int Id)
        {
            var config = _repository.GetById(Id);
            return  ConfigMapper.Map(config);
        }
        public List<ConfigDTO> GetParent(int Id)
        {
            return
                _repository.Get(a=>a.ConfigId== Id)
                    .Select(ConfigMapper.Map)
                    .ToList();
        }
        public List<ConfigDTO> GetChild(int parentId)
        {
            return
             _repository.Get(a => (a.ConfigHdrId == parentId || a.ConfigId == parentId))
                 .Select(ConfigMapper.Map)
                 .ToList();
        }
      
        public BaseResponseDTO Create(ConfigDTO dto)
        {
            try
            {

                _repository.Create(ConfigMapper.MapToModel(dto));
                return BaseResponseHelper.Success();
            }
            catch (Exception e)
            {
                return BaseResponseHelper.Failure(e.Message);
            }
        }
        public BaseResponseDTO Edit(ConfigDTO dto)
        {
            try
            {
                var model = _repository.GetById(dto.ConfigId);
            
            var data=ConfigMapper.MapToEditModel(model, dto);
             _repository.Edit(data);
             return BaseResponseHelper.Success();
            }
        catch (Exception e)
        {
            return BaseResponseHelper.Failure(e.Message);
        }

}
        public BaseResponseDTO Delete(int id)
        {
            try
            {
                _repository.Delete(_repository.GetById(id));
                return BaseResponseHelper.Success();
            }
        catch (Exception e)
        {
        return BaseResponseHelper.Failure(e.Message);
}
        }

        public ConfigParentDTO GetConfigParent()
        {
            throw new System.NotImplementedException();
        }

        public FilterResponse<ConfigDTO> GetForGrid(GridRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}
