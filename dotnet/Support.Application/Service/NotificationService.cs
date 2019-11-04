using Framework.Core.Notification;
using Support.Application.Contract.DTO;
using Support.Application.Contract.IService;

namespace Support.Application.Service
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationHelper _messageHelper;

        public NotificationService(INotificationHelper messageHelper)
        {
            this._messageHelper = messageHelper;
        }
        public void UserRegister(PersonNotificationDTO model)
        {
            _messageHelper.SendSms(model.Mobile,
            $"پیوستن شما به سیستم پشتیبانی ساپ را تبریک می گوییم. نام کاربری {model.LoginName} رمز ورود {model.Password} "
             );
        }


       
        public void ResendPassword(PersonNotificationDTO model)
        {
            _messageHelper.SendSms(model.Mobile, $"رمز عبور کاربر شما{model.LoginName} به {model.Password} تغییر یافت. ساپ" );
         
        }

        public void CreateResponse(string mobile, string title)
        {

            _messageHelper.SendSms(mobile, $"یک پاسخ از سمت کارشناسان سامانه ساپ بر روی تیکت شما با عنوان {title} درج گردید.");
        }

        public void CreateNewTicket(string adminMobile, string userFullName, string title)
        {
            _messageHelper.SendSms(adminMobile, $"یک تیکت جدید در سامانه از سمت کاربر {userFullName} با عنوان {title} ثبت گردید.");
        }

        public void ActivateUser(string personMobile, string personLoginName)
        {
            _messageHelper.SendSms(personMobile, $"کاربر شما با نام کاربری {personLoginName} فعال گردید.");
        }

        public void DeActiveUser(string personMobile, string personLoginName)
        {
            _messageHelper.SendSms(personMobile, $"کاربر شما با نام کاربری {personLoginName} غیرفعال گردید.");
        }

        public void CreateResponseFromUser(string userMobile, string requestTitle)
        {
            _messageHelper.SendSms(userMobile, $"بر روی تیکت با عنوان {requestTitle} یک پاسخ جدید از سوی کاربر درج شده است.");
        }
    }
}
