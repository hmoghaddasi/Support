using System.Collections.Generic;
using System.Linq;
using Support.Application.Contract.DTO;
using Support.Application.Contract.IService;
using Support.Application.Mapper;
using Support.Domain.IRepository;
using Support.Domain.Model;

namespace Support.Application.Service
{
    public class AccessPolicyServices : IAccessPolicyServices
    {
        private readonly IAccessPolicyRepository _accessPolicyRepository;
        private readonly IAccessRepository _accessRepository;
        public AccessPolicyServices(IAccessPolicyRepository accessPolicyRepository, IAccessRepository accessRepository)
        {
            this._accessPolicyRepository = accessPolicyRepository;
            this._accessRepository = accessRepository;

        }

       public void Create(AccessPolicyDTO accessPolicy)
        {
            _accessPolicyRepository.Create(AccessPolicyMapper.MapToModel(accessPolicy));
        }

        public void Delete(int accessPolicyId)
        {
            _accessPolicyRepository.Delete(accessPolicyId);
        }


        public bool CheckUserHaveCustomAccess(string userName, int customAccess)
        {
            return _accessPolicyRepository.
                Get(a => a.Person.LoginName == userName && a.AccessId == customAccess).Any();
        }

        public int FindRequestAdmin()
        {
            var person = _accessPolicyRepository.Get(a => a.AccessId == BusinessAccess.TicketAdmin);
            return person.Any() ? person.First().PersonId : 0;
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
    }
}
