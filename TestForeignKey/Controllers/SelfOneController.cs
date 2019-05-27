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
using TestForeignKey.Domain.Commands;
using TestForeignKey.Domain.Entities;
using TestForeignKey.Domain.Repositories;

namespace TestForeignKey.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class SelfOneController : ImprovedQueryController<SelfOne, ISelfOneRepository>
    {
        public SelfOneController(IMediator mediator, IImprovedUnitOfWork unitOfWork, ISelfOneRepository repository) : base(mediator, unitOfWork, repository)
        {
        }
    }
}