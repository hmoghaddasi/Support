using System.Collections.Generic;
using Framework.Core.Text;
using Support.Application.Contract.Constant;
using Support.Application.Contract.DTO;
using Support.Application.Contract.Tools;
using Support.Domain.Model;

namespace Support.Application.Mapper
{
    public static class PersonMapper
    {
        public static PersonDTO Map(Person person)
        {
            if (person == null)
            {
                return new PersonDTO();
            }

            return new PersonDTO()
            {
                PersonId = person.PersonId,
                FirstName = person.FirstName,
                LastName = person.LastName,
                LoginName = person.LoginName,
                Email = person.Email,
                Gender = person.Gender,
                GenderText = person.Gender ? "مرد" : "زن",
                Status = person.Status.ConfigName,
                StatusId = person.StatusId,
                FullName = $"{person.FirstName} {person.LastName}",
                Mobile = person.Mobile,
            };
        }

        public static Person MapToModel(PersonCreateDTO person)
        {
            return new Person()
            {
                PersonId = 0,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Mobile = person.Mobile,
                StatusId = PersonStatus.New,
                Gender = false,
                Password = MD5Tool.Hash(person.Password),
                LoginName = person.Mobile
            };
        }

        public static Person MapEditDTO(Person model, PersonDTO editDTO)
        {
            model.FirstName = editDTO.FirstName;
            model.LastName = editDTO.LastName;
            model.Email = editDTO.Email;
            model.Mobile = editDTO.Mobile;
            model.StatusId = editDTO.StatusId;
            model.Gender = editDTO.Gender;

            return model;
        }

        public static PersonCreateDTO MapToRegister(PersonRegisterDTO dto)
        {
            return new PersonCreateDTO()
            {
                PersonId = 0,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                LoginName = dto.Mobile,
                Mobile = dto.Mobile,
                Password = PersonTools.GetRandomPassKey()
            };
        }

        public static ProfileDTO MapProfileDTO(Person person)
        {
            return new ProfileDTO()
            {
                PersonId = person.PersonId,
                FirstName = person.FirstName,
                LastName = person.LastName,
                FullName = person.FirstName + " " + person.LastName,
                LoginName = person.LoginName,
                Email = person.Email,
                Gender = person.Gender,
                GenderText = person.Gender ? "مرد" : "زن",
                Status = person.Status?.ConfigName,
                Mobile = person.Mobile,
                StatusId = person.StatusId
            };
        }

        public static Person MapEditProfileDTO(Person person, ProfileDTO request)
        {
            person.FirstName = request.FirstName;
            person.LastName = request.LastName;
            person.Mobile = request.Mobile;
            person.Gender = request.Gender;
            person.Email = request.Email;
            return person;
        }
    }

}

