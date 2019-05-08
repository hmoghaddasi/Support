using System.Collections.Generic;
using Support.Application.Contract.DTO;
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
                Mobile = person.Mobile,
            };
        }

        public static Person MapToModel(PersonDTO dto)
        {
            return new Person()
            {
                PersonId = dto.PersonId,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                LoginName = dto.LoginName,
                Email = dto.Email,
                Mobile = dto.Mobile,
                Gender = dto.Gender,
                //Password = MD5Tool.Hash(dto.Password),
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
    
    }

}

