using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControl.Models
{
    public class JwtOptions
    {
        public string? SecretKey { get; set; }
        public int ExpiryMinutes { get; set; }
        public string? Issuer { get; set; }
        public bool ValidateAudience { get; set; }
        public bool ValidateLifetime { get; set; }
    }
}
