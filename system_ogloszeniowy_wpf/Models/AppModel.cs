using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace system_ogloszeniowy_wpf.Models
{
    public class AppModel
    {
        public int Id { get; set; }
        public int User_id { get; set; }
        public int Offer_Id { get; set; }
        public string? Firma { get; set; }
        public string? Login { get; set; }
        public string? Status { get; set; }
    }
}
