using System;
using System.Collections.Generic;

#nullable disable

namespace WPF_SQL.Models
{
    public partial class Mark
    {
        public int Id { get; set; }
        public int Marks { get; set; }
        public int StudentId { get; set; }

        public virtual Student Student { get; set; }
    }
}
