﻿using System;
using System.Collections.Generic;

#nullable disable

namespace WPF_SQL.Models
{
    public partial class DiscountTable
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public decimal To { get; set; }
        public decimal From { get; set; }
        public int Dicsount { get; set; }
        public decimal Cost { get; set; }

        public virtual Student Student { get; set; }
    }
}
