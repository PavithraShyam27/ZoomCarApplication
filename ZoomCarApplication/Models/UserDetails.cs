﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZoomCarApplication.Models
{
    [Table("UserDetails")]
    public class UserDetails
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int MblNo { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}