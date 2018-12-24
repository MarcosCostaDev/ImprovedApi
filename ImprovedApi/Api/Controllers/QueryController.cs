using ImprovedApi.Domain.Entities;
using ImprovedApi.Domain.Repositories.Interfaces;
using ImprovedApi.Domain.ViewModels;
using ImprovedApi.Infra.Transactions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ImprovedApi.Api.Controllers
{

    public abstract class QueryController<TEntity, TRepository> : BaseController
        where TEntity : Entity
        where TRepository : IQueryRepository<TEntity>

    {
        protected readonly TRepository _repository;
        public QueryController(IMediator mediator, IUnitOfWork unitOfWork, TRepository repository) : base(mediator, unitOfWork)
        {
            _repository = repository;
        }

        [HttpGet("v1/{id}")]
        public virtual OkObjectResult GetById([FromRoute] int id)
        {
            return Ok(_repository.GetById(id));
        }

        [HttpGet, Route("v1/list")]
        public virtual OkObjectResult List()
        {
            return Ok(_repository.List());
        }

    }

    


}
