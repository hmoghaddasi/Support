using System.Collections.Generic;
using System.Linq;
using Support.Application.Contract.DTO;
using Support.Application.Contract.IService;
using Support.Application.Mapper;
using Support.Domain.Model;
using System;
using Framework.Core.Text;
using Support.Application.Contract.Grid;
using Support.Domain.IRepositories;

namespace Support.Application.Service
{
    public class PersonServices : IPersonServices
    {
        private readonly IPersonRepository _personRepository;

        public PersonServices(IPersonRepository personRepository)
        {
            this._personRepository = personRepository;
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

        public List<PersonDTO> GetAll(int personTypeId = 0)
        {
            if (personTypeId == 0)
            {
                return _personRepository.GetAll().Select(PersonMapper.Map).ToList();
            }

            return _personRepository.GetAll().Select(PersonMapper.Map).Where(a => a.PersonTypeId == personTypeId).ToList();
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

        public FilterResponse<PersonDTO> GetForGrid(GridRequest request)
        {
            throw new NotImplementedException();
        }

        public BaseResponseDTO DeActivateUser(int id)
        {
            throw new NotImplementedException();
        }

        public ProfileDTO GetProfile(object currentUserName)
        {
            throw new NotImplementedException();
        }

        public BaseResponseDTO Edit(object currentUserName, ProfileDTO request)
        {
            throw new NotImplementedException();
        }

        public BaseResponseDTO ValidateUser(int id)
        {
            throw new NotImplementedException();
        }

        public BaseResponseDTO ActivateUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
