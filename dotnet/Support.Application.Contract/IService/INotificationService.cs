using Support.Application.Contract.DTO;

namespace Support.Application.Contract.IService
{
    public interface INotificationService:Framework.Core.OnionClass.IApplicationService
    {
        void UserRegister(PersonNotificationDTO model);
        void ResendPassword(PersonNotificationDTO model);
        void CreateResponse(string userMobile, string requestTitle);
        void CreateNewTicket(string adminMobile, string userFullName, string title);
        void ActivateUser(string personMobile, string personLoginName);
        void DeActiveUser(string personMobile, string personLoginName);
        void CreateResponseFromUser(string userMobile, string requestTitle);
    }
}
