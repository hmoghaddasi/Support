using System.Collections.Generic;
using Support.Application.Contract.DTO;

namespace Support.Application.Contract.IService
{
    public interface IAccessPolicyServices : IApplicationService
    {

        void Create(AccessPolicyDTO accessPolicy);
        void Delete(int accessPolicyId);
        bool CheckUserHaveCustomAccess(string userName, int customAccess);
        int FindRequestAdmin();
        void AddGeneralAccess(int personId);
    }
}
