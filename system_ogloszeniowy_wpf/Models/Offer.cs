using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace system_ogloszeniowy_wpf.Models
{
    public class Offer
    {
        public int Id { get; set; }
        public string? Tytul { get; set; }
        public string? Opis { get; set; }
        public string? Kategoria { get; set; }

        public string? Stanowisko { get; set; }
        public string? Umowa { get; set; }
        public int Placa_min { get; set; }
        public int Placa_max { get; set; }
        public string? Lokalizacja { get; set; }
        public int Odleglosc { get; set; }
        public string? Data { get; set; }
    }
}
