using System.Collections.Generic;

namespace Support.Application.Contract.DTO
{
    public class ProfileDTO
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string CompanyName { get; set; }
        public bool Gender { get; set; }
        public string GenderText { get; set; }
        public int TypeId { get; set; }
        public string Type { get; set; }
        public int StatusId { get; set; }
        public string Status { get; set; }
        public List<PersonTestDTO> IndividualTests { get; set; }
        public string FullName { get; set; }
        public string LoginName { get; set; }
    }
}
