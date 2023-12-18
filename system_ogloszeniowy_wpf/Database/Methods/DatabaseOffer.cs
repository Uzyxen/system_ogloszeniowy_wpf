using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using system_ogloszeniowy_wpf.Models;
using system_ogloszeniowy_wpf.Pages;

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
                    offer.Stanowisko = query.GetString(4);
                    offer.Placa_min = query.GetInt32(5);
                    offer.Placa_max = query.GetInt32(6);
                    offer.Lokalizacja = query.GetString(7);
                    offer.Odleglosc = query.GetInt32(8);
                    offer.Data = query.GetString(9);

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

                var insertCommand = new SqliteCommand("INSERT INTO oferty (oferta_id, tytul, opis, kategoria, stanowisko, placa_min, placa_max, lokalizacja, odleglosc, data_dodania) VALUES (NULL, @Tytul, @Opis, @Kategoria, @Stanowisko, @Placa_min, @Placa_max, @Lokalizacja, @Odleglosc, @Data)", db);
                insertCommand.Parameters.AddWithValue("@Tytul", offer.Tytul);
                insertCommand.Parameters.AddWithValue("@Opis", offer.Opis);
                insertCommand.Parameters.AddWithValue("@Kategoria", offer.Kategoria);
                insertCommand.Parameters.AddWithValue("@Stanowisko", offer.Stanowisko);
                insertCommand.Parameters.AddWithValue("@Placa_min", offer.Placa_min);
                insertCommand.Parameters.AddWithValue("@Placa_max", offer.Placa_max);
                insertCommand.Parameters.AddWithValue("@Lokalizacja", offer.Lokalizacja);
                insertCommand.Parameters.AddWithValue("@Odleglosc", offer.Odleglosc);
                insertCommand.Parameters.AddWithValue("@Data", DateTime.Now.ToString("dd MMMM yyyy"));

                insertCommand.ExecuteReader();
            }
        }

        public static void EditOffer(Offer offer)
        {
            string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "serwis_ogloszeniowy.db");

            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                var updateCommand = new SqliteCommand("UPDATE oferty SET tytul = @Tytul, opis = @Opis, kategoria = @Kategoria, stanowisko = @Stanowisko, placa_min = @Placa_min, placa_max = @Placa_max, lokalizacja = @Lokalizacja, odleglosc = @Odleglosc WHERE oferta_id = @OfferId", db);
                updateCommand.Parameters.AddWithValue("@Tytul", offer.Tytul);
                updateCommand.Parameters.AddWithValue("@Opis", offer.Opis);
                updateCommand.Parameters.AddWithValue("@Kategoria", offer.Kategoria);
                updateCommand.Parameters.AddWithValue("@Stanowisko", offer.Stanowisko);
                updateCommand.Parameters.AddWithValue("@Placa_min", offer.Placa_min);
                updateCommand.Parameters.AddWithValue("@Placa_max", offer.Placa_max);
                updateCommand.Parameters.AddWithValue("@Lokalizacja", offer.Lokalizacja);
                updateCommand.Parameters.AddWithValue("@Odleglosc", offer.Odleglosc);
                updateCommand.Parameters.AddWithValue("@OfferId", offer.Id);

                updateCommand.ExecuteNonQuery();
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
