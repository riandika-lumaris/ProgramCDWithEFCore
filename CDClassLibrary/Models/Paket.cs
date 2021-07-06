using System;
using System.Collections.Generic;

namespace CDClassLibrary.Models
{
    public partial class Paket
    {
        public Paket()
        {
            Trpaket = new HashSet<Trpaket>();
        }

        public string Kodepk { get; set; }
        public string Nama { get; set; }
        public byte? Jumlah { get; set; }
        public int? Harga { get; set; }

        public virtual ICollection<Trpaket> Trpaket { get; set; }
    }
}
