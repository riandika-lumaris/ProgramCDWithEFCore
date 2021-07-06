using System;
using System.Collections.Generic;

namespace CDClassLibrary.Models
{
    public partial class Cd
    {
        public Cd()
        {
            Dbeli = new HashSet<Dbeli>();
            Dpjmcd = new HashSet<Dpjmcd>();
        }

        public string Kodecd { get; set; }
        public string Judulcd { get; set; }
        public short? Hrgsewa { get; set; }
        public byte? Lamasw { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Dbeli> Dbeli { get; set; }
        public virtual ICollection<Dpjmcd> Dpjmcd { get; set; }
    }
}
