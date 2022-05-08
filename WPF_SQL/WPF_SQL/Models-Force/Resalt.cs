using System;
using System.Collections.Generic;

#nullable disable

namespace WPF_SQL.Models
{
    public partial class Resalt
    {
        public int Id { get; set; }
        public int RecordBookId { get; set; }
        public int Val { get; set; }

        public virtual Zachetka RecordBook { get; set; }
    }
}
