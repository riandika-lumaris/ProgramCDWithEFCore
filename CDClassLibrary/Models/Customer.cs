using System;
using System.Collections.Generic;

namespace CDClassLibrary.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Hpjmcd = new HashSet<Hpjmcd>();
            Trpaket = new HashSet<Trpaket>();
        }

        public string Kodecust { get; set; }
        public string Nama { get; set; }
        public string Alamat { get; set; }
        public string Telp { get; set; }

        public virtual ICollection<Hpjmcd> Hpjmcd { get; set; }
        public virtual ICollection<Trpaket> Trpaket { get; set; }
    }
}
