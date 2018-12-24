using System;
using System.Collections.Generic;
using System.Text;

namespace ImprovedApi.Api.Security.Token
{
    public class TokenConfiguration
    {
        public string SecretKey { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int Seconds { get; set; }
    }
}
