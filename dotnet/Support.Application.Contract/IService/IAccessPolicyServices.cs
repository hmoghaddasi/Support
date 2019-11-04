using System;
using System.Collections.Generic;
using Framework.Core.Filtering;
using Framework.Core.OnionClass;
using Support.Application.Contract.DTO;

namespace Support.Application.Contract.IService
{
    public interface IAccessPolicyServices : IApplicationService
    {
        BaseResponseDTO Create(AccessPolicyDTO accessPolicyDTO);
        BaseResponseDTO Delete(int accessPolicyId);
        string GetUserAccess(string user);
        BaseResponseDTO ChangePersonAccess(ChangePersonAccessDTO request);
        List<int> GetAccessBasedConfig(string user);
    }
}
