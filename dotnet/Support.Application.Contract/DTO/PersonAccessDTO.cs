namespace Support.Application.Contract.DTO
{
    public class PersonAccessDTO
    {
        public int AccessPolicyId { get; set; }
        public int AccessId { get; set; }
        public string AccessName { get; set; }
        public bool IsGeneral { get; set; }
        public string AccessDesc { get; set; }
    }
}
