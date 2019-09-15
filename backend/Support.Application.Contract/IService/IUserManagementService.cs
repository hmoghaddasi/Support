namespace Support.Application.Contract.IService
{
    public interface IUserManagementService

    {
        bool IsValidUser(string username, string password);
    }
}