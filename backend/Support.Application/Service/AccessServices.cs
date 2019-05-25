using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Support.Application.Contract.DTO;
using Support.Application.Contract.IService;
using Support.Application.Mapper;
using Support.Domain.IRepository;
using Support.Domain.Model;

namespace Support.Application.Service
{
    public class AccessServices : IAccessServices
    {
        private readonly IAccessRepository _accessRepository;
        private readonly IAccessPolicyRepository _accessPolicyrepository;
        public AccessServices(IAccessRepository _accessRepository, IAccessPolicyRepository _accessPolicyrepository)
        {
            this._accessRepository = _accessRepository;
            this._accessPolicyrepository = _accessPolicyrepository;

        }

        public IQueryable<AccessDTO> GetAllIQueryable()
        {
            return _accessRepository.GetAll().Select(AccessMapper.Map).AsQueryable();
        }

        public AccessDTO GetById(int Id)
        {
            return AccessMapper.Map(_accessRepository.GetById(Id));
        }

        public string GetAllAccessId(string loginName)
        {
            string access = "";
            if (loginName != null)
            {
                var accesslist = _accessPolicyrepository.Get(a => a.Person.LoginName == loginName);

                foreach (var item in accesslist)
                {
                    access += item.Access.AccessName.ToLower() + ",";
                }
            }
            return access;
        }

       //public FilterResponse<AccessDTO> GetAll(GridRequest request)
        //{
        //    var result = _accessRepository.GetAll().OrderByDescending(a => a.AccessName).Select(AccessMapper.Map).AsQueryable();
        //    var data = result.ApplyFilters(request, false);
        //    return new FilterResponse<AccessDTO>(data.Data, data.Count);
        //}
        public int CreateOrUpdate(AccessDTO dto)
        {
            int AccessId = dto.AccessId;
            if (AccessId == 0)
            {
                Create(dto);
                return 1;

            }
            else
            {
                Edit(dto);
            }
            return AccessId;
        }

        public void Create(AccessDTO accessvm)
        {
            _accessRepository.Create(AccessMapper.MapToModel(accessvm));
            
        }

        public void Delete(int Id)
        {
            _accessRepository.Delete(_accessRepository.GetById(Id));
        }

        public void Edit(AccessDTO accessvm)
        {
            var accessToEdit = AccessMapper.MapToUpdate(
                _accessRepository.GetById(accessvm.AccessId)
                                , accessvm);
            _accessRepository.Edit(accessToEdit);
        }




    }
}
