using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Core.OnionClass;

namespace Framework.Core.Notification
{
    public interface INotificationService
    {
        void SendSms(string receptor, string message);
    }
}
