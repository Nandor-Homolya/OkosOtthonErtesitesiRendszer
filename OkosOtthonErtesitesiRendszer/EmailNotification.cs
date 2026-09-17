using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkosOtthonErtesitesiRendszer
{
    public class EmailNotification : NotificationChannel
    {
        public string EmailAddress { get; set; }
        public string Subject { get; set; }

        public EmailNotification(string emailAddress, string subject)
        {
            EmailAddress = emailAddress;
            Subject = subject;
        }

        public override void Kuld(Notification notification)
        {
            Console.WriteLine($"[Email] Cimzett: {EmailAddress} | Targy: {Subject} | Uzenet: {notification.Message} | Ido: {notification.Timestamp}");
        }
    }
}
