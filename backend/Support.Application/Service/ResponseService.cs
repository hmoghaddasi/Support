using System;
using System.Collections.Generic;
using System.Linq;
using Framework.Core.Filtering;
using Support.Application.Contract.DTO;
using Support.Application.Contract.IService;
using Support.Application.Mapper;
using Support.Domain.IRepositories;
using Support.Domain.Model;

namespace Support.Application.Service
{
    public class RequestService : IRequestServices
    {
        private readonly IRequestRepository _repository;
        public RequestService(IRequestRepository repository)
        {
            this._repository = repository;
        }
        public List<RequestListDTO> GetAll()
        {
            //return
            //     _repository.GetAll().Select(ConfigMapper.Map)
            //         .ToList();
            throw new NotImplementedException();
        }
        public RequestEditDTO GetById(int Id)
        {
            throw new NotImplementedException();
            //var config = _repository.GetById(Id);
            //return  ConfigMapper.Map(config);
        }
        public void Create(RequestCreateDTO dto)
        {
            // _repository.Create(ConfigMapper.MapToModel(dto));
        }
        public void Edit(RequestEditDTO dto)
        {
            throw new NotImplementedException();
            //var model = _repository.GetById(dto.ConfigId);

            //var data=ConfigMapper.MapToEditModel(model, dto);
            // _repository.Edit(data);

        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
            //_repository.Delete(_repository.GetById(id));
        }

        public List<RequestDTO> GetCustomerRequests(int personId, string userName)
        {
            throw new NotImplementedException();
        }

        public List<RequestDTO> GetAllRequestResponcesById(int personId, string userName)
        {
            throw new NotImplementedException();
        }

        public FilterResponse<RequestListDTO> GetAllFilter(GridRequest request)
        {
            throw new NotImplementedException();
        }
        //public ConfigParentDTO GetConfigParent()
        //{
        //    return ConfigMapper.MapToConfigParentDTO();
        //}

        //public FilterResponse<ConfigDTO> GetAllConfig(GridRequest request,int parentId)
        //{
        //    var result = _repository.Get(a=>a.ConfigHdrId==parentId).Select(ConfigMapper.Map).AsQueryable();

        //    var data = result.ApplyFilters(request, false);
        //    return new FilterResponse<ConfigDTO>(data.Data, data.Count);
        //}


        //public FilterResponse<ConfigDTO> GetAllForGrid(GridRequest request)
        //{
        //    var result = _repository.GetAll().Select(ConfigMapper.Map).AsQueryable();

        //    var data = result.ApplyFilters(request, false);
        //    return new FilterResponse<ConfigDTO>(data.Data, data.Count);
        //}

        //public List<PairValueDTO> GetPersonType()
        //{
        //    return _repository.Get(a => a.ConfigHdrId == ConfigType.CreditType)
        //        .OrderBy(a=>a.ConfigSort)
        //        .Select(ConfigMapper.MapToPairValue).ToList();
        //}

        //public List<ConfigDTO> GetCreditType()
        //{
        //    return _repository.Get(a => a.ConfigHdrId == ConfigType.CreditType)
        //        .OrderBy(a => a.ConfigSort)
        //        .Select(ConfigMapper.Map).ToList();
        //}

        //public List<PairValueDTO> GetContentType()
        //{
        //    return _repository.Get(a => a.ConfigHdrId == ConfigType.ContentType)
        //        .OrderBy(a => a.ConfigSort)
        //        .Select(ConfigMapper.MapToPair).ToList();
        //}
    }
}
