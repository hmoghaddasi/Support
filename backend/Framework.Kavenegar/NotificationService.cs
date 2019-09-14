using Framework.Core.Notification;
using Kavenegar;
using Kavenegar.Core.Exceptions;
using System;

namespace Framework.Kavenegar
{
    public class NotificationService : INotificationService
    {
        public void SendSms(string receptor, string message)
        {
            try
            {
                KavenegarApi api = new KavenegarApi(MessageSetting.TokenKey);
                var result = api.Send(MessageSetting.Sender, receptor, message);

            }
            catch (ApiException ex)
            {
                Console.Write("Message : " + ex.Message);
            }
            catch (HttpException ex)
            {
                Console.Write("Message : " + ex.Message);
            }
        }
    }
}
