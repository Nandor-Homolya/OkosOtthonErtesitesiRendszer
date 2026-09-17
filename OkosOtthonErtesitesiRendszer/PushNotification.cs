using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkosOtthonErtesitesiRendszer
{
    public class PushNotification : NotificationChannel
    {
        public string DeviceID { get; set; }

        public PushNotification(string deviceID)
        {
            DeviceID = deviceID;
        }

        public override void Kuld(Notification notification)
        {
            throw new NotImplementedException();
        }
    }
}
}
