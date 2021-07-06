using System;
using System.Collections.Generic;

namespace CDClassLibrary.Models
{
    public partial class Dbeli
    {
        public string Notabeli { get; set; }
        public string Kodecd { get; set; }
        public byte? Jumlah { get; set; }
        public short? Harga { get; set; }

        public virtual Cd KodecdNavigation { get; set; }
        public virtual Hbeli NotabeliNavigation { get; set; }
    }
}
