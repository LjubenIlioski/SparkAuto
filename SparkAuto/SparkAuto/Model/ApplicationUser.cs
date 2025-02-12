﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SparkAuto.Model
{
    public class ApplicationUser :IdentityUser
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostaCode { get; set; }
    }
}
