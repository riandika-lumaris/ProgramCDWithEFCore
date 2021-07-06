using System;
using System.Collections.Generic;

namespace CDClassLibrary.Models
{
    public partial class Trpaket
    {
        public Trpaket()
        {
            Dpjmcd = new HashSet<Dpjmcd>();
        }

        public string Kodetp { get; set; }
        public string Kodecust { get; set; }
        public string Kodepk { get; set; }
        public byte? Sisa { get; set; }

        public virtual Customer KodecustNavigation { get; set; }
        public virtual Paket KodepkNavigation { get; set; }
        public virtual ICollection<Dpjmcd> Dpjmcd { get; set; }
    }
}
