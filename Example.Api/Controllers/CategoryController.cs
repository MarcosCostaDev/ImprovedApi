using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ImprovedApi.Api.Controllers;
using Example.Domain.Entities;
using Example.Domain.Repository;
using ImprovedApi.Infra.Transactions;
using MediatR;

namespace Example.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : QueryController<Category, ICategoryRepository>
    {
        public CategoryController(IMediator mediator, IUnitOfWork unitOfWork, ICategoryRepository repository) : base(mediator, unitOfWork, repository)
        {
        }
    }
}