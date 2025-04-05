﻿using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ContactApp_WebAPI.Model.Entity
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [NotNull]
        public string Name { get; set; }
        [NotNull]
        public bool IsAdmin { get; set; }
        [NotNull]
        public bool IsActive { get; set; }

        [NotNull]
        public string Password { get; set; }
    }
}
