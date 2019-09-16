using System.Collections.Generic;
using System.Linq;
using Support.Application.Contract.DTO;
using Support.Application.Contract.IService;
using Support.Application.Mapper;
using Support.Domain.Model;
using System;
using Framework.Core.Text;
using Support.Domain.IRepositories;
using Framework.Core.Filtering;
using Support.Domain.Exception;
using Support.Application.Contract.Constant;
using Framework.Core.Notification;

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

        public int GetCurrentPersonTypeId(string loginName)
        {
            var person = GetCurrentPerson(loginName);
            if (person == null) return 0;
            return person.StatusId;
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

        public void Delete(int id)
        {
            _personRepository.Delete(id);
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
            var result = _personRepository.GetForGrid(new GridRequest
            {
                Take = request.Take,
                Skip = request.Skip,
                Filter = request.Filter,
                FilterX = request.FilterX,
                Sort = request.Sort,
            }, request.Id);
            return new FilterResponse<PersonDTO>(result.data.Select(PersonMapper.Map).ToList(), result.total);
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
            _notificationService.SendSms(person.Mobile, $"کاربر شما با نام کاربری {person.LoginName} غیرفعال گردید.");
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
            _notificationService.SendSms(person.Mobile, $"کاربر شما با نام کاربری {person.LoginName} فعال گردید.");
            return BaseResponseHelper.Success();
        }

        public List<PersonDTO> GetAll(int personTypeId = 0)
        {
            throw new NotImplementedException();
        }
    }
}
