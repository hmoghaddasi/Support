using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Core.Notification;
using Kavenegar;
using Kavenegar.Exceptions;

namespace Framework.Kavenegar
{
    public class NotificationHelper : INotificationHelper
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
