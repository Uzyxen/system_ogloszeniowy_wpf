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
        public static User ReadUser(int id)
        {
            string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "serwis_ogloszeniowy.db");

            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                var selectCommand = new SqliteCommand("SELECT * FROM uzytkownicy WHERE user_id = @Id", db);
                selectCommand.Parameters.AddWithValue("@Id", id);

                var query = selectCommand.ExecuteReader();

                if (query.Read())
                {
                    var user = new User();

                    user.Id = query.GetInt32(0);
                    user.Zdjecie = query.GetString(1);
                    user.Imie = query.GetString(2);
                    user.Nazwisko = query.GetString(3);
                    user.Opis = query.GetString(4);
                    user.Stanowisko = query.GetString(5);
                    user.Wyksztalcenie = query.GetString(6);
                    user.Login = query.GetString(7);
                    user.Haslo = query.GetString(8);
                    user.Email = query.GetString(9);
                    user.Numer_telefonu = query.GetString(10);
                    user.Admin = query.GetBoolean(11);

                    return user;
                }
                else
                {
                    return null;
                }
            }
        }

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
                    user.Zdjecie = query.GetString(1);
                    user.Imie = query.GetString(2);
                    user.Nazwisko = query.GetString(3);
                    user.Opis = query.GetString(4);
                    user.Stanowisko = query.GetString(5);
                    user.Wyksztalcenie = query.GetString(6);
                    user.Login = query.GetString(7);
                    user.Haslo = query.GetString(8);
                    user.Email = query.GetString(9);
                    user.Numer_telefonu = query.GetString(10);
                    user.Admin = query.GetBoolean(11);

                    users.Add(user);
                }
            }

            return users;
        }

        public static void EditUser(User user)
        {
            string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "serwis_ogloszeniowy.db");

            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                var updateCommand = new SqliteCommand("UPDATE uzytkownicy SET zdjecie = @Zdjecie, imie = @Imie, nazwisko = @Nazwisko, opis = @Opis, stanowisko = @Stanowisko, wyksztalcenie = @Wyksztalcenie, login = @Login, haslo = @Haslo, email = @Email, numer_telefonu = @Numer_tel, czy_admin = @Admin WHERE user_id = @UserId", db);
                updateCommand.Parameters.AddWithValue("@Zdjecie", user.Zdjecie);
                updateCommand.Parameters.AddWithValue("@Imie", user.Imie);
                updateCommand.Parameters.AddWithValue("@Nazwisko", user.Nazwisko);
                updateCommand.Parameters.AddWithValue("@Opis", user.Opis);
                updateCommand.Parameters.AddWithValue("@Stanowisko", user.Stanowisko);
                updateCommand.Parameters.AddWithValue("@Wyksztalcenie", user.Wyksztalcenie);
                updateCommand.Parameters.AddWithValue("@Login", user.Login);
                updateCommand.Parameters.AddWithValue("@Haslo", user.Haslo);
                updateCommand.Parameters.AddWithValue("@Email", user.Email);
                updateCommand.Parameters.AddWithValue("@Numer_tel", user.Numer_telefonu);
                updateCommand.Parameters.AddWithValue("@Admin", user.Admin);
                updateCommand.Parameters.AddWithValue("@UserId", App.loggedUser.Id);

                updateCommand.ExecuteNonQuery();
            }
        }

        public static void AddUser(User user)
        {
            string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "serwis_ogloszeniowy.db");

            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                var insertCommand = new SqliteCommand("INSERT INTO uzytkownicy (user_id, zdjecie, imie, nazwisko, opis, stanowisko, wyksztalcenie, login, haslo, email, numer_telefonu, czy_admin) VALUES (NULL, @Zdjecie, @Imie, @Nazwisko, @Opis, @Stanowisko, @Wyksztalcenie, @Login, @Haslo, @Email, @Numer_tel, @Admin)", db);
                insertCommand.Parameters.AddWithValue("@Zdjecie", user.Zdjecie);
                insertCommand.Parameters.AddWithValue("@Imie", user.Imie);
                insertCommand.Parameters.AddWithValue("@Nazwisko", user.Nazwisko);
                insertCommand.Parameters.AddWithValue("@Opis", user.Opis);
                insertCommand.Parameters.AddWithValue("@Stanowisko", user.Stanowisko);
                insertCommand.Parameters.AddWithValue("@Wyksztalcenie", user.Wyksztalcenie);
                insertCommand.Parameters.AddWithValue("@Login", user.Login);
                insertCommand.Parameters.AddWithValue("@Haslo", user.Haslo);
                insertCommand.Parameters.AddWithValue("@Email", user.Email);
                insertCommand.Parameters.AddWithValue("@Numer_tel", user.Numer_telefonu);
                insertCommand.Parameters.AddWithValue("@Admin", user.Admin);

                insertCommand.ExecuteReader();
            }
        }
    }
}
