using System;
using System.Collections.Generic;

#nullable disable

namespace WPF_SQL.Models
{
    public partial class Zachetka
    {
        public Zachetka()
        {
            Resalts = new HashSet<Resalt>();
        }

        public int Id { get; set; }
        public int StudentId { get; set; }
        public string Number { get; set; }

        public virtual Student Student { get; set; }
        public virtual ICollection<Resalt> Resalts { get; set; }
    }
}
