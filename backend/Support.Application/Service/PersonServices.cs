using System.Collections.Generic;
using System.Linq;
using Support.Application.Contract.DTO;
using Support.Application.Contract.IService;
using Support.Application.Mapper;
using Support.Domain.Model;
using System;
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
            // return _personRepository.GetAuthenticated(loginName, MD5Tool.Hash(password));
            throw new NotImplementedException();
        }



        public bool ChangePassword(string username, string password, string newPassword)
        {
            //var hashPassword = MD5Tool.Hash(password);
            //var person = _personRepository.Get(a => a.LoginName == username && a.PassKey == hashPassword);
            //if (person.Any())
            //{
            //    person.First().PassKey = MD5Tool.Hash(newPassword);
            //    _personRepository.Edit(person.FirstOrDefault());
            //}
            //return person.Any();
            throw new NotImplementedException();
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

        //public List<PersonDropDownDTO> GetPerson()
        //{
        //    return _personRepository.GetAll()
        //        .Select(PersonMapper.MapDropDown).ToList();
        //}

        //public PatientCreditDTO GetPersonForPrescription(PatientSearchDTO dto)
        //{
        //    var patient = _personRepository.Get(a => a.PersonTypeId == PersonType.Patient &&
        //                                             a.NationalCode == dto.NationalCode);

        //    if (patient.Any())
        //    {
        //        int maxAcceptable = _creditTransactionService.GetMaxAcceptable(patient.First().PersonId, dto.ProductId);
        //        return PersonMapper.MapToCreditValue(patient.First(), maxAcceptable);

        //    }
        //    else
        //    {
        //        throw new PersonNotFoundException();
        //    }

        //}
        //public PatientDeliverDTO GetPersonByNational(string nationalCode)
        //{
        //    return PersonMapper.MapToPatient(
        //                    _personRepository.GetPatient(a =>
        //                        a.PersonTypeId == PersonType.Patient &&
        //                        a.NationalCode == nationalCode));

        //}

        public int GetCurrentPersonContentTypeId(string userName)
        {
            //var person = GetCurrentPerson(userName);
            //if (person == null)
            //{
            //    return 0;
            //}
            //return person.PersonType.ConfigValue;
            throw new NotImplementedException();
            
        }
    }
}
