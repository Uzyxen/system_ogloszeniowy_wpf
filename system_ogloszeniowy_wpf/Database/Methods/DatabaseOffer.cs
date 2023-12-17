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
    public class DatabaseOffer
    {
        public static List<Offer> ReadOffers()
        {
            var users = new List<Offer>();
            string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "serwis_ogloszeniowy.db");

            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                var selectCommand = new SqliteCommand("SELECT * FROM oferty", db);
                var query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    var offer = new Offer();
                    offer.Id = query.GetInt32(0);
                    offer.Tytul = query.GetString(1);
                    offer.Opis = query.GetString(2);
                    offer.Kategoria = query.GetString(3);
                    offer.Lokalizacja = query.GetString(4);
                    offer.Odleglosc = query.GetInt32(5);

                    users.Add(offer);
                }
            }

            return users;
        }
    }
}
