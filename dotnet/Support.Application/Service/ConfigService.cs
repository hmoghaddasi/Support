using System;
using System.Collections.Generic;
using System.Linq;
using Framework.Core.Filtering;
using Support.Application.Contract.DTO;
using Support.Application.Contract.IService;
using Support.Application.Mapper;
using Support.Domain.IRepository;

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
            return ConfigMapper.Map(config);
        }
        public List<ConfigDTO> GetParent(int Id)
        {
            return
                _repository.Get(a => a.ConfigId == Id)
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

        public ConfigParentDTO GetConfigParent()
        {
            throw new System.NotImplementedException();
        }

        public List<ConfigDTO> GetConfigChildsByParentId(int id)
        {
            try
            {
                return _repository.Get(d => d.ConfigHdrId == id && d.ConfigId != 0).Select(ConfigMapper.Map).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public FilterResponse<ConfigDTO> GetForGrid(GridRequestWithArgument request)
        {
            throw new NotImplementedException();
        }
    }
}
