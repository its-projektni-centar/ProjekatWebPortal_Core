﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjekatWebPortal_Core.ViewModels
{
    public class LoggedUserViewModel
    {
        public byte[] slika { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
    }
}