using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

#nullable disable

namespace WPF_SQL.Models
{
    public partial class Student
    {
        public Student()
        {
            DiscountTables = new HashSet<DiscountTable>();
            GiveCashes = new HashSet<GiveCash>();
            Marks = new HashSet<Mark>();
            Rates = new HashSet<Rate>();
            TakeCashes = new HashSet<TakeCash>();
            Zachetkas = new HashSet<Zachetka>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Cost { get; set; }
        public DateTime Dates { get; set; }
        public int GroupId { get; set; }

        public virtual Group Group { get; set; }
        public virtual ICollection<DiscountTable> DiscountTables { get; set; }
        public virtual ICollection<GiveCash> GiveCashes { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }
        public virtual ICollection<Rate> Rates { get; set; }
        public virtual ICollection<TakeCash> TakeCashes { get; set; }
        public virtual ICollection<Zachetka> Zachetkas { get; set; }

        public static implicit operator DbSet<object>(Student v)
        {
            throw new NotImplementedException();
        }
    }
}
