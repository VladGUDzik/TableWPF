using System;
using System.Collections.Generic;

#nullable disable

namespace WPF_SQL.Models
{
    public partial class TakeCash
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public decimal Cost { get; set; }
        public DateTime DataGive { get; set; }
        public string Comment { get; set; }

        public virtual Student Student { get; set; }
    }
}
