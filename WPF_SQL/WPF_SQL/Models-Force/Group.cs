using System;
using System.Collections.Generic;

#nullable disable

namespace WPF_SQL.Models
{
    public partial class Group
    {
        public Group()
        {
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
