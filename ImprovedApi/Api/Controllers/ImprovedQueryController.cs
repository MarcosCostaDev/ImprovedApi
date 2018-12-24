using ImprovedApi.Domain.Entities;
using ImprovedApi.Domain.Repositories.Interfaces;
using ImprovedApi.Domain.ViewModels;
using ImprovedApi.Infra.Transactions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ImprovedApi.Api.Controllers
{

    public abstract class ImprovedQueryController<TEntity, TRepository> : ImprovedBaseController
        where TEntity : ImprovedEntity
        where TRepository : IImprovedQueryRepository<TEntity>

    {
        protected readonly TRepository _repository;
        public ImprovedQueryController(IMediator mediator, IImprovedUnitOfWork unitOfWork, TRepository repository) : base(mediator, unitOfWork)
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

        [HttpGet, Route("v1/list/{page:int:min(1)}/{pageSize:int}")]
        public virtual OkObjectResult List([FromRoute]int page, [FromRoute]int pageSize)
        {
            return Ok(_repository.ListPaged(page, pageSize));
        }
    }

    


}
