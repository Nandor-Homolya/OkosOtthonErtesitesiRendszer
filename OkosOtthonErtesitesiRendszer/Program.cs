// 1. feladat: Az Okosotthon Értesítési Rendszere
using System;
using System.Collections.Generic;

namespace OkosOtthonErtesitesiRendszer
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseHelper.AdatbazisInicializalasa();

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

            Console.WriteLine();
            Console.WriteLine("--- Adatbazisbol lekerdezett ertesitesek ---");
            DatabaseHelper.OsszesLekerdezese();

            Console.ReadKey();
        }
    }
}