using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public class TokenOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpirationTime { get; set; }
        public string SecurityKey { get; set; }
    }
}
