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
            var offers = new List<Offer>();
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

                    offers.Add(offer);
                }
            }

            return offers;
        }

        public static void AddOffer(Offer offer)
        {
            string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "serwis_ogloszeniowy.db");

            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                var insertCommand = new SqliteCommand("INSERT INTO oferty (oferta_id, tytul, opis, kategoria, lokalizacja, odleglosc) VALUES (NULL, @Tytul, @Opis, @Kategoria, @Lokalizacja, @Odleglosc)", db);
                insertCommand.Parameters.AddWithValue("@Tytul", offer.Tytul);
                insertCommand.Parameters.AddWithValue("@Opis", offer.Opis);
                insertCommand.Parameters.AddWithValue("@Kategoria", offer.Kategoria);
                insertCommand.Parameters.AddWithValue("@Lokalizacja", offer.Lokalizacja);
                insertCommand.Parameters.AddWithValue("@Odleglosc", offer.Odleglosc);

                insertCommand.ExecuteReader();
            }
        }

        public static void DeleteOffer(int id)
        {
            string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "serwis_ogloszeniowy.db");

            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                var insertCommand = new SqliteCommand("DELETE FROM oferty WHERE oferta_id=@Id", db);
                insertCommand.Parameters.AddWithValue("@Id", id);

                insertCommand.ExecuteNonQuery();
            }
        }
    }
}
