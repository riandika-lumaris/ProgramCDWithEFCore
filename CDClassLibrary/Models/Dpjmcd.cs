using System;
using System.Collections.Generic;

namespace CDClassLibrary.Models
{
    public partial class Dpjmcd
    {
        public string Notapjm { get; set; }
        public string Kodecd { get; set; }
        public DateTime? Tglkembali { get; set; }
        public string Kodetp { get; set; }
        public string Status { get; set; }
        public int? Subtotal { get; set; }

        public virtual Cd KodecdNavigation { get; set; }
        public virtual Trpaket KodetpNavigation { get; set; }
        public virtual Hpjmcd NotapjmNavigation { get; set; }
    }
}
