using Framework.Core.Filtering;
using Support.Application.Contract.Constant;
using Support.Application.Contract.DTO;
using Support.Application.Contract.IService;
using Support.Application.Mapper;
using Support.Domain.Exception;
using Support.Domain.IRepositories;
using Support.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Support.Application.Service
{
    public class AccessPolicyService : IAccessPolicyServices
    {
        private readonly IAccessPolicyRepository _accessPolicyRepository;
        private readonly IAccessRepository _accessRepository;

        public AccessPolicyService(IAccessPolicyRepository accessPolicyRepository, IAccessRepository accessRepository)
        {
            this._accessPolicyRepository = accessPolicyRepository;
            this._accessRepository = accessRepository;
        }

        public BaseResponseDTO Create(AccessPolicyDTO accessPolicyDTO)
        {
            var response = new BaseResponseDTO();
            try
            {
                _accessPolicyRepository.Create(AccessPolicyMapper.MapToModel(accessPolicyDTO));
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
        public BaseResponseDTO Delete(int accessPolicyId)
        {
            var response = new BaseResponseDTO();
            var accessPolicyToDelete = _accessPolicyRepository.GetById(accessPolicyId);
            if (accessPolicyToDelete == null)
            {
                throw new NotExistAccessPloicyException();
            }
            try
            {
                _accessPolicyRepository.Delete(accessPolicyToDelete);
                response.ResultCode = ResultCode.Success;
                response.Message = "عملیات حذف  با موفقیت انجام شد";
            }
            catch (Exception ex)
            {
                response.ResultCode = ResultCode.Error;
                response.Message = "عملیات حذف  با خطا مواجه شد";
            }
            return response;
        }
        public AccessPolicyDTO GetById(int accessPolicyId)
        {
            return AccessPolicyMapper.Map(_accessPolicyRepository.GetById(accessPolicyId));
        }
        public FilterResponse<AccessPolicyDTO> GetList(GridRequest request)
        {
            var result = _accessPolicyRepository.GetAll().Select(AccessPolicyMapper.Map).AsQueryable();
            var data = result.ApplyFilters(request, false);
            return new FilterResponse<AccessPolicyDTO>(data.data, data.total);
        }

        public List<AccessPolicyDTO> GetAll()
        {
            return _accessPolicyRepository.GetAll().Select(AccessPolicyMapper.Map).ToList();
        }

        public string GetUserAccess(string user)
        {
            var access = "";
            var list = _accessPolicyRepository.Get(a => a.Person.LoginName.ToLower() == user.ToLower())
                .Select(a => a.Access.AccessName).ToList();
            foreach (var item in list)
            {
                access += $"{item},";
            }

            return access;
        }

        public void AddGeneralAccess(int personId)
        {
            _accessPolicyRepository.AddRange(
                _accessRepository.Get(a => a.IsGeneral)
                    .Select(a => new AccessPolicy
                    {
                        AccessId = a.AccessId,
                        PersonId = personId
                    }).ToList());
        }

        public BaseResponseDTO ChangePersonAccess(ChangePersonAccessDTO request)
        {
            var response = new BaseResponseDTO();
            var accessPolicyList = _accessPolicyRepository.Get(d => d.PersonId == request.PersonId && d.AccessId == request.AccessId);
            if (request.AddOrRemove)
            {
                var tempRecord = new AccessPolicy
                {
                    AccessId = request.AccessId,
                    PersonId = request.PersonId
                };
                try
                {
                    _accessPolicyRepository.Create(tempRecord);
                    response.ResultCode = ResultCode.Success;
                    response.Message = "تخصیص دسترسی به کاربر با موفقیت انجام شد";
                }
                catch (Exception ex)
                {
                    response.ResultCode = ResultCode.Error;
                    response.Message = "تخصیص دسترسی به کاربر با خطا مواجه شد";
                }
            }
            else
            {
                if (!accessPolicyList.Any())
                {
                    throw new AccessPolicyNotFoundException();
                }
                try
                {
                    var tempRecord = accessPolicyList.First();
                    _accessPolicyRepository.Delete(tempRecord);
                    response.ResultCode = ResultCode.Success;
                    response.Message = "صلب دسترسی از کاربر با موفقیت انجام شد";
                }
                catch (Exception ex)
                {
                    response.ResultCode = ResultCode.Error;
                    response.Message = "صلب دسترسی از کاربر با خطا مواجه شد";
                }
            }
            return response;
        }
    }
}
