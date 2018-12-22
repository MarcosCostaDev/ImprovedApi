using BaseApi.Domain.Entities;
using BaseApi.Domain.Repositories.Interfaces;
using BaseApi.Domain.ViewModels;
using BaseApi.Infra.Transactions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BaseApi.Api.Controllers
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

        [HttpGet("v1/{id:long}")]
        public virtual OkObjectResult GetById([FromRoute] long id)
        {
            return Ok(_repository.GetById(id));
        }

        [HttpGet, Route("v1/list")]
        public virtual OkObjectResult List()
        {
            return Ok(_repository.List());
        }

    }

    

    public abstract class QueryController<TEntity, TRepository, TQueryViewModel> : QueryController<TEntity, TRepository>
        where TEntity : Entity
        where TRepository : IQueryRepository<TEntity, TQueryViewModel>
        where TQueryViewModel : QueryViewModel
    {
        public QueryController(IMediator mediator, IUnitOfWork unitOfWork, TRepository repository) : base(mediator, unitOfWork, repository)
        {
        }

        [HttpGet, Route("v1/list/viewmodel")]
        public virtual OkObjectResult ListViewModel()
        {
            return Ok(_repository.ListViewModel());
        }
    }



}
