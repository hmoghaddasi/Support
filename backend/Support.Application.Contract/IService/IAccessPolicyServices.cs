using System.Collections.Generic;
using Framework.Core.Filtering;
using Support.Application.Contract.DTO;

namespace Support.Application.Contract.IService
{
    public interface IAccessPolicyServices : IApplicationService
    {
        BaseResponseDTO Create(AccessPolicyDTO accessPolicyDTO);
        BaseResponseDTO Delete(int accessPolicyId);
        AccessPolicyDTO GetById(int accessPolicyId);
        FilterResponse<AccessPolicyDTO> GetList(GridRequest request);
        List<AccessPolicyDTO> GetAll();
        string GetUserAccess(string user);
        void AddGeneralAccess(int personId);
        BaseResponseDTO ChangePersonAccess(ChangePersonAccessDTO request);
    }
}
