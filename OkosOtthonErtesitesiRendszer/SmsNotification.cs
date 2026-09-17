using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkosOtthonErtesitesiRendszer
{
    public class SmsNotification : NotificationChannel
    {
        public string PhoneNumber { get; set; }

        public SmsNotification(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }

        public override void Kuld(Notification notification)
        {
            Console.WriteLine($"[SMS] Telefonszam: {PhoneNumber} | Uzenet: {notification.Message} | Ido: {notification.Timestamp}");
        }
    }
}
