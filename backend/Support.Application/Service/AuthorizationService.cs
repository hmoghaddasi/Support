using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Framework.Core.Notification;
using Framework.Core.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Support.Application.Contract.Constant;
using Support.Application.Contract.DTO;
using Support.Application.Contract.IService;
using Support.Application.Contract.Tools;
using Support.Application.Mapper;
using Support.Domain.Exception;
using Support.Domain.IRepositories;
using Support.Domain.Model;
using Support.Host.Tools;
namespace Support.Application.Service
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IPersonRepository _personRepository;
        private readonly INotificationService _notificationService;
        private readonly IAccessPolicyServices _accessPolicyService;

        public AuthorizationService(IPersonRepository personRepository, INotificationService notificationService, IAccessPolicyServices accessPolicyService)
        {
            _personRepository = personRepository;
            _notificationService = notificationService;
            _accessPolicyService = accessPolicyService;

        }

        public List<Claim> RegisterPerson(PersonRegisterDTO dto)
        {
            var registerPerson = PersonMapper.MapToRegister(dto);
            GuardDuplicateMobileNumber(dto.Mobile);
            var person = PersonMapper.MapToModel(registerPerson);
            var personId = _personRepository.Create(person);
            _accessPolicyService.AddGeneralAccess(personId);
            _notificationService.SendSms(person.Mobile,
               $"پیوستن شما به سامانه پشتیبانی SAAP را تبریک می گوییم نام کاربری {person.Mobile} رمز عبور  {registerPerson.Password}");
            return CreateClaims(person);
        }
        private void GuardDuplicateMobileNumber(string mobile)
        {
            if (_personRepository.Get(a => a.Mobile == mobile).Any())
            {
                throw new MobileExistsException();
            }
        }
        public List<Claim> CreateClaimsFor(TokenDTO dto)
        {
            var password = MD5Tool.Hash(dto.Password);
            var user = _personRepository.Get(a => a.LoginName == dto.UserName && a.Password == password);
            if (!user.Any())
            {
                throw new PersonNotFoundException();
            }
            if(user.First().StatusId != PersonStatus.Active)
            {
                throw new PersonNotActiveException();
            }
           
            return CreateClaims(user.First());
        }
        private List<Claim> CreateClaims(Person user)
        {
            return new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.LoginName),
                new Claim(ClaimTypes.NameIdentifier, user.PersonId.ToString()),
            };
        }
        public List<Claim> Verification(VerificationDTO dto, string mobile)
        {
            var password = MD5Tool.Hash(dto.Code);
            var person = _personRepository.Get(a => a.Mobile == mobile &&
                                               a.Password == password);
            person.First().StatusId = PersonStatus.Verified;
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
            _notificationService.SendSms(person.First().Mobile, $"رمز عبور جدید شما {pass} می‌باشد");
            person.First().Password = MD5Tool.Hash(pass);
            _personRepository.Edit(person.First());
        }
    }
}
