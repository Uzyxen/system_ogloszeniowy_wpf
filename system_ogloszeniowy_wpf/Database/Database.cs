using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace system_ogloszeniowy_wpf.Database
{
    public static class Database
    {
        public static void InitializeDatabase()
        {
            string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "serwis_ogloszeniowy.db");

            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                string usersTableCommand = "CREATE TABLE IF NOT EXISTS uzytkownicy (user_id INTEGER PRIMARY KEY AUTOINCREMENT, imie NVARCHAR(50), nazwisko NVARCHAR(50), opis NVARCHAR(2000), login NVARCHAR(20), haslo NVARCHAR(20), email NVARCHAR(255), numer_telefonu NVARCHAR(16))";
                var createUsersTable = new SqliteCommand(usersTableCommand, db);

                createUsersTable.ExecuteReader();
            }
        }
    }
}
