﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAboutProjects.Models
{
    public static class Role
    {
        public const string SuperAdmin = "SuperAdmin";
        public const string Admin = "Admin";
        public const string User = "User";
    }

    public class AppSettings
    {
        public string Secret { get; set; }
    }
}
