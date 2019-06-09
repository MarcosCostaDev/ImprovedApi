using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImprovedApi.Api.Controllers;
using ImprovedApi.Infra.Transactions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestCodeFirst.Domain.Commands;
using TestCodeFirst.Domain.Entities;
using TestCodeFirst.Domain.Repositories;

namespace TestCodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class ToOneController : ImprovedQueryController<ToOne, IToOneRepository>
    {
        public ToOneController(IMediator mediator, IImprovedUnitOfWork unitOfWork, IToOneRepository repository) : base(mediator, unitOfWork, repository)
        {
        }
    }
}