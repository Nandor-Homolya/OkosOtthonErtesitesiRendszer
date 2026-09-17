using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkosOtthonErtesitesiRendszer
{
     class Program
    {
        static void Main(string[] args)
        {
            List<NotificationChannel> csatornak = new List<NotificationChannel>
            {
                new PushNotification("DEV-001"),
                new EmailNotification("kovacs.anna@example.com", "Riasztas"),
                new SmsNotification("+36301234567")
            };

            Notification ertesites = new Notification("Mozgaserzekelo riasztast eszlelt a nappaliban!");

            foreach (var csatorna in csatornak)
            {
                csatorna.Kuld(ertesites);
                DatabaseHelper.MentesAdatbazisba(csatorna.GetType().Name, ertesites);
            }

            Console.ReadKey();
        }
    }
}
