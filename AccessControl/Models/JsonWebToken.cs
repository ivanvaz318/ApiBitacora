﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControl.Models
{
    public class JsonWebToken
    {
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
        public long Expires { get; set; }
    }
}
