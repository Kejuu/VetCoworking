﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetCoworking.Domain.Models
{
    public partial class Booking
    {
        public Guid Id { get; set; }
        public string PatientName { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
