using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using ImprovedApi.Api.Responses;
using ImprovedApi.Api.Security.Token;
using ImprovedApi.Infra.Transactions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.IdentityModel.Tokens;

namespace ImprovedApi.Api.Controllers
{
    public abstract class ImprovedAuthController<TAuthCommand> : ImprovedBaseController
        where TAuthCommand : IRequest<ResponseResult>

    {
        public ImprovedAuthController(IMediator mediator, IImprovedUnitOfWork unitOfWork) : base(mediator, unitOfWork)
        {
        }

        [AllowAnonymous]
        [HttpPost, Route("v1/Auth")]
        public virtual async Task<OkObjectResult> Auth([FromBody] TAuthCommand request, 
            [FromServices]IOptions<TokenConfiguration> options, 
            [FromServices] SigningConfigurations signingConfigurations)
        {
            var result = await _mediator.Send(request);
            if(result.Valid)
            {
                var token = CreateToken(result, options, signingConfigurations);
                return Ok(token, result.Notifications);
            }
            else
            {
                return Unauthorized(result);
            }
            
        }
    
        [NonAction]
        protected virtual object CreateToken(ResponseResult result, IOptions<TokenConfiguration> options, SigningConfigurations signingConfigurations)
        {
            ClaimsIdentity identity = CreateClaimIdentity(result);

            DateTime Created = DateTime.Now;
            DateTime Expire = Created +
                TimeSpan.FromSeconds(options.Value.Seconds);

            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = options.Value.Issuer,
                Audience = options.Value.Audience,
                SigningCredentials = signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = Created,
                Expires = Expire
            });
            var token = handler.WriteToken(securityToken);
            return new
            {
                created = Created.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = Expire.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = token,
                message = "OK"
            };
        }

        [NonAction]
        protected virtual ClaimsIdentity CreateClaimIdentity(ResponseResult result)
        {
            return new ClaimsIdentity(
                   new GenericIdentity(SetIndentify(result), "Login"),
                   new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, result.Object.ToString()),
                        new Claim("UserName", SetUserName(result))
                   }
               );
        }

        [NonAction]
        protected virtual string SetIndentify(ResponseResult result)
        {
            return result.Object.ToString();
        }


        [NonAction]
        protected virtual string SetUserName(ResponseResult result)
        {
            return result.Object.ToString();
        }
    }

}
