﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingProject1.Models
{
    public class User
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    } public class Login
    {
      
        public string username { get; set; }
        public string password { get; set; }
    }
}