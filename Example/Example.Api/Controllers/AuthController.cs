using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example.Domain.Commands;
using ImprovedApi.Api.Controllers;
using ImprovedApi.Infra.Transactions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Example.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ImprovedAuthController<ArtistHandlers.AuthCommand>
    {
        public AuthController(IMediator mediator, IImprovedUnitOfWork unitOfWork) : base(mediator, unitOfWork)
        {
        }
    }
}