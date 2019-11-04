using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core.Notification
{
    public interface INotificationHelper
    {
        void SendSms(string receptor, string message);
    }
}
