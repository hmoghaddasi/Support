using System.Collections.Generic;
using System.Linq;
using Support.Application.Mapper;

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
                _repository.Get(a=>a.ConfigId==ConfigType.Parent)
                    .Select(ConfigMapper.Map)
                    .ToList();
        }

        public List<ConfigDTO> GetChild(int parentId, int related)
        {
            return
             _repository.Get(a => (a.ConfigHdrId == parentId || a.ConfigId == ConfigType.Parent)&&
                                  (related==0 || a.ConfigValue==related))
                 .Select(ConfigMapper.Map)
                 .ToList();
        }

        public void CreateOrUpdate(ConfigDTO dto)
        {
            if (dto.ConfigId == 0)
            {
                Create(dto);
            }
            else
            {
                Edit(dto);
            }
        }


        private void Create(ConfigDTO dto)
        {
            _repository.Create(ConfigMapper.MapToModel(dto));
        }

        private void Edit(ConfigDTO dto)
        {
            var model = _repository.GetById(dto.ConfigId);
            
            var data=ConfigMapper.MapToEditModel(model, dto);
             _repository.Edit(data);
            
        }

     

        public void Delete(int id)
        {
            _repository.Delete(_repository.GetById(id));
        }

        

        public ConfigParentDTO GetConfigParent()
        {
            return ConfigMapper.MapToConfigParentDTO();
        }

        public FilterResponse<ConfigDTO> GetAllConfig(GridRequest request,int parentId)
        {
            var result = _repository.Get(a=>a.ConfigHdrId==parentId).Select(ConfigMapper.Map).AsQueryable();

            var data = result.ApplyFilters(request, false);
            return new FilterResponse<ConfigDTO>(data.Data, data.Count);
        }


        public FilterResponse<ConfigDTO> GetAllForGrid(GridRequest request)
        {
            var result = _repository.GetAll().Select(ConfigMapper.Map).AsQueryable();

            var data = result.ApplyFilters(request, false);
            return new FilterResponse<ConfigDTO>(data.Data, data.Count);
        }

        public List<PairValueDTO> GetPersonType()
        {
            return _repository.Get(a => a.ConfigHdrId == ConfigType.CreditType)
                .OrderBy(a=>a.ConfigSort)
                .Select(ConfigMapper.MapToPairValue).ToList();
        }

        public List<ConfigDTO> GetCreditType()
        {
            return _repository.Get(a => a.ConfigHdrId == ConfigType.CreditType)
                .OrderBy(a => a.ConfigSort)
                .Select(ConfigMapper.Map).ToList();
        }

        public List<PairValueDTO> GetContentType()
        {
            return _repository.Get(a => a.ConfigHdrId == ConfigType.ContentType)
                .OrderBy(a => a.ConfigSort)
                .Select(ConfigMapper.MapToPair).ToList();
        }
    }
}
