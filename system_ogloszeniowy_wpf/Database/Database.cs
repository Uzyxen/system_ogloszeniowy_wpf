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

                string usersTableCommand = "CREATE TABLE IF NOT EXISTS uzytkownicy (user_id INTEGER PRIMARY KEY AUTOINCREMENT, zdjecie NVARCHAR(255), imie NVARCHAR(50), nazwisko NVARCHAR(50), opis NVARCHAR(3000), stanowisko NVARCHAR(30), wyksztalcenie NVARCHAR(30), github NVARCHAR(255), status NVARCHAR(50), login NVARCHAR(20), haslo NVARCHAR(20), email NVARCHAR(255), numer_telefonu NVARCHAR(16), czy_admin bool)";
                var createUsersTable = new SqliteCommand(usersTableCommand, db);

                string offersTableCommand = "CREATE TABLE IF NOT EXISTS oferty (oferta_id INTEGER PRIMARY KEY AUTOINCREMENT, tytul NVARCHAR(100), opis NVARCHAR(1000), kategoria NVARCHAR(30), stanowisko NVARCHAR(50), umowa NVARCHAR(15), placa_min INTEGER, placa_max INTEGER, lokalizacja NVARCHAR(50), odleglosc INTEGER, data_dodania DATE, firma NVARCHAR(30))";
                var createOffersTable = new SqliteCommand(offersTableCommand, db);

                string appsTableCommand = "CREATE TABLE IF NOT EXISTS aplikacje (aplikacja_id INTEGER PRIMARY KEY AUTOINCREMENT, user_id INTEGER, oferta_id INTEGER, login NVARCHAR(20), firma NVARCHAR(30))";
                var createAppsTable = new SqliteCommand(appsTableCommand, db);

                createUsersTable.ExecuteReader();
                createOffersTable.ExecuteReader();
                createAppsTable.ExecuteReader();
                
            }
        }
    }
}
