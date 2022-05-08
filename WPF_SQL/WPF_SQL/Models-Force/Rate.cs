using System;
using System.Collections.Generic;

#nullable disable

namespace WPF_SQL.Models
{
    public partial class Rate
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public DateTime MakeAt { get; set; }
        public int Val { get; set; }

        public virtual Student Student { get; set; }
    }
}
