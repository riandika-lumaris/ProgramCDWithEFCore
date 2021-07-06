using System;
using System.Collections.Generic;

namespace CDClassLibrary.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            Hbeli = new HashSet<Hbeli>();
        }

        public string Kodesup { get; set; }
        public string Nama { get; set; }
        public string Alamat { get; set; }
        public string Telp { get; set; }

        public virtual ICollection<Hbeli> Hbeli { get; set; }
    }
}
