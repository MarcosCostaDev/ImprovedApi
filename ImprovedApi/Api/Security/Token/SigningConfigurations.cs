using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImprovedApi.Api.Security.Token
{
    public class SigningConfigurations
    {

        public SigningCredentials SigningCredentials { get; }
        private readonly SymmetricSecurityKey _signingKey;

        public SigningConfigurations(IOptions<TokenConfiguration> options)
        {
            _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(options.Value.SecretKey));
            SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
        }
    }
}
