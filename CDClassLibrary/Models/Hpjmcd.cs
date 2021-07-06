using System;
using System.Collections.Generic;

namespace CDClassLibrary.Models
{
    public partial class Hpjmcd
    {
        public Hpjmcd()
        {
            Dpjmcd = new HashSet<Dpjmcd>();
        }

        public string Notapjm { get; set; }
        public string Kodecust { get; set; }
        public DateTime? Tanggal { get; set; }
        public int? Total { get; set; }

        public virtual Customer KodecustNavigation { get; set; }
        public virtual ICollection<Dpjmcd> Dpjmcd { get; set; }
    }
}
