﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Exceptions
{
    internal class InvalidFirstName : Exception
    {
        public InvalidFirstName(string message) : base(message) { }
    }
}
