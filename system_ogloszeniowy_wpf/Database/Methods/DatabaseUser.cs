using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using system_ogloszeniowy_wpf.Models;

namespace system_ogloszeniowy_wpf.Database.Methods
{
    public class DatabaseUser
    {
        public static List<User> ReadUsers()
        {
            var users = new List<User>();
            string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "serwis_ogloszeniowy.db");

            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                var selectCommand = new SqliteCommand("SELECT * FROM uzytkownicy", db);
                var query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    var user = new User();
                    user.Id = query.GetInt32(0);
                    user.Imie = query.GetString(1);
                    user.Nazwisko = query.GetString(2);
                    user.Opis = query.GetString(3);
                    user.Login = query.GetString(4);
                    user.Haslo = query.GetString(5);
                    user.Email = query.GetString(6);
                    user.Numer_telefonu = query.GetString(7);

                    users.Add(user);
                }
            }

            return users;
        }
        public static void AddUser(User user)
        {
            string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "serwis_ogloszeniowy.db");

            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                var insertCommand = new SqliteCommand("INSERT INTO uzytkownicy (user_id, imie, nazwisko, opis, login, haslo, email, numer_telefonu) VALUES (NULL, @Imie, @Nazwisko, @Opis, @Login, @Haslo, @Email, @Numer_tel)", db);
                insertCommand.Parameters.AddWithValue("@Imie", user.Imie);
                insertCommand.Parameters.AddWithValue("@Nazwisko", user.Nazwisko);
                insertCommand.Parameters.AddWithValue("@Opis", user.Opis);
                insertCommand.Parameters.AddWithValue("@Login", user.Login);
                insertCommand.Parameters.AddWithValue("@Haslo", user.Haslo);
                insertCommand.Parameters.AddWithValue("@Email", user.Email);
                insertCommand.Parameters.AddWithValue("@Numer_tel", user.Numer_telefonu);

                insertCommand.ExecuteReader();
            }
        }
    }
}
