namespace Support.Application.Contract.DTO
{
    public class LoginResultDTO
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public int StatusId { get; set; }
    }
}
