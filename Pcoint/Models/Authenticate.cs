﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pcoint.Models
{
    public class Authenticate
    {
        public int Id { get; set; }

        [Display(Name = "LoginUser")]
        public string LoginUser { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }

        
    }
}
