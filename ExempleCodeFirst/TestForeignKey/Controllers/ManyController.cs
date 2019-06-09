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
using TestCodeFirst.Domain.Entities;
using TestCodeFirst.Domain.Repositories;

namespace TestCodeFirst.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class ManyController : ImprovedQueryController<Many, IManyRepository>
    {
        public ManyController(IMediator mediator, IImprovedUnitOfWork unitOfWork, IManyRepository repository) : base(mediator, unitOfWork, repository)
        {
        }

        [HttpGet]
        [Route("v1/ListCustomMany")]
        public OkObjectResult ListCustomMany()
        {
            return Ok(_repository.ListCustomMany());
        }
    }
}