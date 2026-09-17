using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkosOtthonErtesitesiRendszer
{
    internal class DatabaseHelper
    {
        private static string dbFile = "ertesitesek.db";
        private static string connectionString = $"Data Source={dbFile};Version=3;";

        public static void AdatbazisInicializalasa()
        {
            if (!File.Exists(dbFile))
                SQLiteConnection.CreateFile(dbFile);

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = @"CREATE TABLE IF NOT EXISTS Ertesitesek (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                Csatorna TEXT NOT NULL,
                                Uzenet TEXT NOT NULL,
                                Idopont TEXT NOT NULL)";
                using (var cmd = new SQLiteCommand(sql, conn))
                    cmd.ExecuteNonQuery();
            }
        }

        public static void MentesAdatbazisba(string csatornaNev, Notification n)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO Ertesitesek (Csatorna, Uzenet, Idopont) VALUES (@c, @u, @i)";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@c", csatornaNev);
                    cmd.Parameters.AddWithValue("@u", n.Message);
                    cmd.Parameters.AddWithValue("@i", n.Timestamp.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
