using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using system_ogloszeniowy_wpf.Models;

namespace system_ogloszeniowy_wpf.Database.Methods
{
    public class DatabaseApp
    {
        public static void AddApp(Offer offer)
        {
            string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "serwis_ogloszeniowy.db");

            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                var insertCommand = new SqliteCommand("INSERT INTO aplikacje (aplikacja_id, user_id, oferta_id, login, firma, status) VALUES (NULL, @User_id, @Oferta_id, @Login, @Firma, @Status)", db);
                insertCommand.Parameters.AddWithValue("@User_id", App.loggedUser.Id);
                insertCommand.Parameters.AddWithValue("@Oferta_id", offer.Id);
                insertCommand.Parameters.AddWithValue("@Login", App.loggedUser.Login);
                insertCommand.Parameters.AddWithValue("@Firma", offer.Firma);
                insertCommand.Parameters.AddWithValue("@Status", "Oczekiwanie");

                insertCommand.ExecuteReader();
            }
        }

        public static List<AppModel> ReadApps()
        {
            var apps = new List<AppModel>();
            string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "serwis_ogloszeniowy.db");

            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                var selectCommand = new SqliteCommand("SELECT * FROM aplikacje WHERE status != 'zakończone' AND status != 'anulowane' AND status != 'odrzucone'", db);
                var query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    var app = new AppModel();
                    app.Id = query.GetInt32(0);
                    app.User_id = query.GetInt32(1);
                    app.Offer_Id = query.GetInt32(2);
                    app.Login = query.GetString(3);
                    app.Firma = query.GetString(4);
                    app.Status = query.GetString(5);

                    apps.Add(app);
                }
            }

            return apps;
        }

        public static List<AppModel> ReadAppsForUser()
        {
            var apps = new List<AppModel>();
            string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "serwis_ogloszeniowy.db");

            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                var selectCommand = new SqliteCommand("SELECT * FROM aplikacje WHERE user_id = @UserId", db);
                selectCommand.Parameters.AddWithValue("@UserId", App.loggedUser.Id);

                var query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    var app = new AppModel();
                    app.Id = query.GetInt32(0);
                    app.User_id = query.GetInt32(1);
                    app.Offer_Id = query.GetInt32(2);
                    app.Login = query.GetString(3);
                    app.Firma = query.GetString(4);
                    app.Status = query.GetString(5);

                    apps.Add(app);
                }
            }

            return apps;
        }

        public static void AcceptApp(int user_id, int id, string status)
        {
            string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "serwis_ogloszeniowy.db");

            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                var updateCommand = new SqliteCommand("UPDATE uzytkownicy SET status = @Status WHERE user_id = @UserId", db);
                updateCommand.Parameters.AddWithValue("@Status", status);
                updateCommand.Parameters.AddWithValue("@UserId", user_id);

                var deleteCommand = new SqliteCommand("UPDATE aplikacje SET status = 'zakończone' WHERE aplikacja_id=@Id", db);
                deleteCommand.Parameters.AddWithValue("@Id", id);

                updateCommand.ExecuteNonQuery();
                deleteCommand.ExecuteNonQuery();
            }
        }

        public static void DeleteApp(int id)
        {
            string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "serwis_ogloszeniowy.db");

            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                var deleteCommand = new SqliteCommand("UPDATE aplikacje SET status = 'odrzucone' WHERE aplikacja_id=@Id", db);
                deleteCommand.Parameters.AddWithValue("@Id", id);

                deleteCommand.ExecuteNonQuery();
            }
        }

        public static void CancelApp(int id)
        {
            string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "serwis_ogloszeniowy.db");

            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                var deleteCommand = new SqliteCommand("UPDATE aplikacje SET status = 'anulowane' WHERE aplikacja_id=@Id", db);
                deleteCommand.Parameters.AddWithValue("@Id", id);

                deleteCommand.ExecuteNonQuery();
            }
        }
    }
}
