using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Framework.Core.Number;
using Framework.Core.Text;
using Support.Application.Contract.Constant;
using Support.Application.Contract.DTO;
using Support.Application.Contract.IService;
using Support.Application.Contract.Tools;
using Support.Application.Mapper;
using Support.Domain.Exception;
using Support.Domain.IRepository;
using Support.Domain.Model;

namespace Support.Application.Service
{
    public class AuthorizationService : IAuthorizationService
    {
        private IPersonRepository _personRepository;
        private INotificationService _notificationService;
        private IAccessPolicyRepository _accessPolicyRepository;
        public AuthorizationService(IPersonRepository personRepository, INotificationService notificationService,
            IAccessPolicyRepository accessPolicyRepository)
        {
            this._personRepository = personRepository;
            this._notificationService = notificationService;
            this._accessPolicyRepository = accessPolicyRepository;
        }

        public List<Claim> CreateClaimsFor(TokenDTO dto)
        {
            var hashPassword = MD5Tool.Hash(dto.Password.PersianToEnglish());
            var user = _personRepository.GetByUsername(dto.UserName.PersianToEnglish(), hashPassword);
            if (user == null)
            {

                throw new PersonIsNotActiveException();
            }

         
            return CreateClaims(user);
        }

        public List<Claim> CreateClaims(Person user)
        {
            return new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.LoginName),
                new Claim(ClaimTypes.NameIdentifier, user.PersonId.ToString())
            };
        }

        public List<Claim> Verification(VerificationDTO dto, string user)
        {
            var password = MD5Tool.Hash(dto.Code);
            var person = _personRepository.Get(a => a.LoginName.ToLower() == user.ToLower() &&
                                                    a.Password == password);
            if (person.Any())
            {
                return CreateClaims(person.First());
            }
            else
            {
                throw new PersonNotFoundException();
            }

        }
        public void ResendVerificationCode(string mobile)
        {
            var person = _personRepository.Get(a => a.Mobile == mobile);
            if (!person.Any())
            {
                throw new PersonNotFoundException();
            }

            var pass = PersonTools.GetRandomPassKey();
            var dto = new PersonNotificationDTO() { Mobile = mobile, Password = pass, LoginName = person.First().LoginName};

            _notificationService.ResendPassword(dto);

            person.First().Password = MD5Tool.Hash(pass);
            _personRepository.Edit(person.First());


        }

        public object GetAllAccess(string loginName)
        {
            string access = "";
            if (loginName != null)
            {
                var accessList = _accessPolicyRepository.Get(a => a.Person.LoginName == loginName);

                foreach (var item in accessList)
                {
                    access += item.Access.AccessName.ToLower() + ",";
                }
            }
            return access;
        }

        public bool ChangePassword(PasswordChangeDTO dto)
        {
            var password = MD5Tool.Hash(dto.CurrentPassword);
            var person = _personRepository.Get(a => a.LoginName.ToLower() == dto.UserName.ToLower()
                                                    && a.Password == password);
            if (person.Any())
            {
                person.First().Password = MD5Tool.Hash(dto.NewPassword);
                _personRepository.Edit(person.FirstOrDefault());
            }
            else
            {
                throw new PersonNotFoundException();
            }

            return person.Any();
        }

        public List<Claim> RegisterPerson(PersonRegisterDTO dto)
        {
            dto.Mobile = dto.Mobile.PersianToEnglish();

            var registerPerson = PersonMapper.MapToRegister(dto);
           
            var person = PersonMapper.MapToModel(registerPerson);
            _personRepository.Create(person);
     
            _notificationService.UserRegister(PersonMapper.MapToNotification(registerPerson));
            return CreateClaims(person);
        }

        public List<Claim> GetPersonByUser(string user)
        {
            var person = _personRepository.Get(a => a.LoginName.ToLower() == user.ToLower());
            return CreateClaims(person.First());
        }

        
        public bool GetAuthenticated(TokenDTO dto)
        {
            string hashPass = MD5Tool.Hash(dto.Password);
            return _personRepository.GetByUsername(dto.UserName, hashPass) != null;

        }

     
    }
}
