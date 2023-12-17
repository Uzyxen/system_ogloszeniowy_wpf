using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace system_ogloszeniowy_wpf.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Imie { get; set; }
        public string? Nazwisko { get; set; }
        public string? Opis { get; set; }
        public string? Stanowisko { get; set; }
        public string? Login { get; set; }
        public string? Haslo { get; set; }
        public string? Email { get; set; }
        public string? Numer_telefonu { get; set; }
    }
}
