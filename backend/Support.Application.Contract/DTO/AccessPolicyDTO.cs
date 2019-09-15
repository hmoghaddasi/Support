namespace Support.Application.Contract.DTO
{
    public class AccessPolicyDTO
    {
        public int AccessPolicyId { get; set; }
        public int AccessId { get; set; }
        public int PersonId { get; set; }
        public string AccessName { get; set; }
        public string FullName { get; set; }
    }
}