namespace Support.Application.Contract.DTO
{
    public class PasswordChangeDTO
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string UserName { get; set; }
    }
}
