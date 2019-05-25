using System.Collections.Generic;

namespace Support.Domain.Model
{
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LoginName { get; set; }
        public string Email { get; set; }
        public bool Gender { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public int StatusId { get; set; }
        public virtual List<AccessPolicy> AccessPolicies { get; set; }
        public virtual List<Log> Logs { get; set; }
        public virtual Config Status { get; set; }
        public List<Request> Requests { get; set; }
        public List<Response> CreateResponses { get; set; }
        public List<Request> AssignResponses { get; set; }

      
    }
}
