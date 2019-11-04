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

        public FilterResponse<PersonDTO> GetForGrid(GridRequest request, int statusId)
        {
            var result = _personRepository.GetForGrid(request, statusId);
            return new FilterResponse<PersonDTO>(result.data.Select(PersonMapper.MapToGrid).ToList(), result.total);
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
            try
            {
                request.Mobile = request.Mobile.PersianToEnglish();

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
            catch (Exception e)
            {
                return BaseResponseHelper.Failure(e.Message);
            }
           
        }

        public BaseResponseDTO ValidateUser(int id)
        {
            try
            {
                var person = _personRepository.GetById(id);
                if (person == null)
                {
                    throw new PersonNotFoundException();
                }

                person.StatusId = PersonStatus.Active;
                _personRepository.Edit(person);
                return BaseResponseHelper.Success();
            }
            catch (Exception e)
            {
                return BaseResponseHelper.Failure(e.Message);
            }

        }

        public BaseResponseDTO ActivateUser(int id)
        {
            try
            {
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
            catch (Exception e)
            {
                return BaseResponseHelper.Failure(e.Message);
            }
           
        }

      
    }
}
