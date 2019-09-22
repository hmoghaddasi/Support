namespace Support.Application.Contract.DTO
{
    public class ChangePersonAccessDTO
    {
        public int AccessId { get; set; }

        public int PersonId { get; set; }

        public bool AddOrRemove { get; set; }
    }
}
