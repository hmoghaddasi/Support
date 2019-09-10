using System.Collections.Generic;

namespace Support.Application.Contract.DTO
{
    public class ProfileDTO
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LoginName { get; set; }
        public string Email { get; set; }
        public bool Gender { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public int PersonTypeId { get; set; }
        public int StatusId { get; set; }
        public int GroupId { get; set; }
        public int CategoryId { get; set; }
        public string Note { get; set; }
        public string FullName { get; set; }
        public string GenderTxt { get; set; }
        public string Status { get; set; }
        public string StatusClass { get; set; }
    }
}
