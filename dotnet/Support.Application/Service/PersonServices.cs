using System;
using System.Collections.Generic;
using System.Linq;
using Framework.Core.Filtering;
using Framework.Core.Number;
using Framework.Core.Text;
using Support.Application.Contract.Constant;
using Support.Application.Contract.DTO;
using Support.Application.Contract.IService;
using Support.Application.Mapper;
using Support.Domain.Exception;
using Support.Domain.IRepository;
using Support.Domain.Model;

namespace Support.Application.Service
{
    public class PersonServices : IPersonServices
    {
        private readonly IPersonRepository _personRepository;
        private readonly INotificationService _notificationService;

        public PersonServices(IPersonRepository personRepository, INotificationService notificationService)
        {
            this._personRepository = personRepository;
            this._notificationService = notificationService;
        }

   

        public PersonDTO GetByLogin(string loginName)
        {
            var person = GetCurrentPerson(loginName);
            return PersonMapper.Map(person);
        }


        private Person GetCurrentPerson(string loginName)
        {
            return _personRepository.Get(a => a.LoginName.ToLower() == loginName.ToLower()).FirstOrDefault();
        }

        public bool GetAuthenticated(string loginName, string password)
        {
            var hashPassword = MD5Tool.Hash(password);
            return _personRepository.Get(a => a.LoginName.ToLower() == loginName.ToLower() && a.Password == hashPassword).Any();
        }



        public bool ChangePassword(string username, string password, string newPassword)
        {
            var hashPassword = MD5Tool.Hash(password);
            var person = _personRepository.Get(a => a.LoginName == username && a.Password == hashPassword);
            if (person.Any())
            {
                person.First().Password = MD5Tool.Hash(newPassword);
                _personRepository.Edit(person.FirstOrDefault());
            }
            return person.Any();
        }

        public PersonDTO GetById(int Id)
        {
            return PersonMapper.Map(_personRepository.Get(a => a.PersonId == Id).FirstOrDefault());
        }
        public PersonDTO GetByUserName(string loginName)
        {
            return PersonMapper.Map(_personRepository.Get(a => a.LoginName == loginName).FirstOrDefault());
        }

        public void Delete(int id)
        {
            _personRepository.Delete(_personRepository.GetById(id));
        }

        public int GetPersonByLogin(string userName)
        {
            var person = _personRepository.Get(a => a.LoginName == userName).FirstOrDefault();
            if (person != null)
            {
                return person.PersonId;
            }
            return 0;
        }

        public FilterResponse<PersonDTO> GetForGrid(GridRequestWithArgument request)
        {
            throw new NotImplementedException();
        }


        public BaseResponseDTO DeActivateUser(int id)
        {
            var response = new BaseResponseDTO();
            var person = _personRepository.GetById(id);
            if (person == null)
            {
                throw new PersonNotFoundException();
            }
            person.StatusId = PersonStatus.DeActive;
            _personRepository.Edit(person);
            _notificationService.DeActiveUser(person.Mobile, person.LoginName);
            return BaseResponseHelper.Success();
        }

        public ProfileDTO GetProfile(string userName)
        {
            var persons = _personRepository.Get(a => a.LoginName.ToLower() == userName.ToLower());
            var person = persons[0];
            var response = PersonMapper.MapProfileDTO(person);
            return response;
        }

        public BaseResponseDTO Edit(string currentUserName, ProfileDTO request)
        {
            request.Mobile = request.Mobile.PersianToEnglish();

            var response = new BaseResponseDTO();
            var persons = _personRepository.Get(a => a.LoginName.ToLower() == currentUserName.ToLower());
            var person = _personRepository.GetById(persons[0].PersonId);
            if (person == null)
            {
                throw new PersonNotFoundException();
            }
            if (_personRepository.Get(d => d.Mobile == request.Mobile && d.PersonId != person.PersonId).Any())
            {
                throw new MobileExistsException();
            }
            var editEntity = PersonMapper.MapEditProfileDTO(person, request);
            _personRepository.Edit(editEntity);
            return BaseResponseHelper.Success();
        }

        public BaseResponseDTO ValidateUser(int id)
        {
            var response = new BaseResponseDTO();
            var person = _personRepository.GetById(id);
            if (person == null)
            {
                throw new PersonNotFoundException();
            }

            person.StatusId = PersonStatus.Active;
            _personRepository.Edit(person);
            return BaseResponseHelper.Success();
        }

        public BaseResponseDTO ActivateUser(int id)
        {
            var response = new BaseResponseDTO();
            var person = _personRepository.GetById(id);
            if (person == null)
            {
                throw new PersonNotFoundException();
            }
            person.StatusId = PersonStatus.Active;
            _personRepository.Edit(person);
            _notificationService.ActivateUser(person.Mobile, person.LoginName);
                
            return BaseResponseHelper.Success();
        }

        public List<PersonDTO> GetAll(int personTypeId = 0)
        {
            throw new NotImplementedException();
        }
    }
}
