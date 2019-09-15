using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Framework.Core.Filtering;
using Support.Application.Contract.Constant;
using Support.Application.Contract.DTO;
using Support.Application.Contract.IService;
using Support.Application.Mapper;
using Support.Domain.Exception;
using Support.Domain.IRepositories;
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
        public FilterResponse<AccessDTO> GetForGrid(GridRequest request)
        {
            var result = _accessRepository.GetForGrid(request);
            return new FilterResponse<AccessDTO>(result.data.Select(AccessMapper.Map).ToList(), result.total);
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

        public List<AccessDTO> Get(Expression<Func<Access, bool>> predicate)
        {
            return _accessRepository.Get(predicate).Select(AccessMapper.Map).ToList();
        }

        public BaseResponseDTO Create(AccessDTO accessvm)
        {
            var response = new BaseResponseDTO();
            try
            {
                _accessRepository.Create(AccessMapper.MapToModel(accessvm));
                response.ResultCode = ResultCode.Success;
                response.Message = "عملیات درج  با موفقیت انجام شد";
            }
            catch (Exception ex)
            {
                response.ResultCode = ResultCode.Error;
                response.Message = "عملیات درج  با خطا مواجه شد";
            }
            return response;
        }

        public void Delete(int Id)
        {
            _accessRepository.Delete(_accessRepository.GetById(Id));
        }
        public BaseResponseDTO Edit(AccessDTO accessvm)
        {
            var response = new BaseResponseDTO();
            var model = _accessRepository.GetById(accessvm.AccessId);
            if (model == null)
            {
                throw new NotExistAccessException();
            }
            try
            {
                var accessToEdit = AccessMapper.MapToUpdate(model, accessvm);
                _accessRepository.Edit(accessToEdit);

                response.ResultCode = ResultCode.Success;
                response.Message = "عملیات ویرایش  با موفقیت انجام شد";
            }
            catch (Exception ex)
            {
                response.ResultCode = ResultCode.Error;
                response.Message = "عملیات ویرایش  با خطا مواجه شد";
            }
            return response;
        }

        public void AddOrUpdate(AccessDTO dto)
        {
            throw new NotImplementedException();
        }

        public List<PersonAccessDTO> PersonAccess(int id)
        {
            var accessList = _accessRepository.GetAll();
            var result = accessList.Select(AccessMapper.MapToPeronAccessDTO).ToList();
            for (var i = 0; i < result.Count; i++)
            {
                result[i].PolicyAvailable = accessList[i].AccessPolicies != null ? accessList[i].AccessPolicies.Any(d => d.PersonId == id) : false;
            }
            return result;
        }
    }
}
