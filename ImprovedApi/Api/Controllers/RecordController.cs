using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ImprovedApi.Api.Responses;
using ImprovedApi.Domain.Entities;
using ImprovedApi.Domain.Repositories.Interfaces;
using ImprovedApi.Domain.ViewModels;
using ImprovedApi.Infra.Transactions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ImprovedApi.Api.Controllers
{

    public abstract class RecordController<TEntity, TRepository, TCreateCommand> : QueryController<TEntity, TRepository>
        where TEntity : Entity
        where TRepository : IRecordRepository<TEntity>
        where TCreateCommand : IRequest<ResponseResult>
    {
        public RecordController(IMediator mediator, IUnitOfWork unitOfWork, TRepository repository) : base(mediator, unitOfWork, repository)
        {
        }

        [HttpPost, Route("v1/")]
        public async virtual Task<OkObjectResult> Create([FromBody] TCreateCommand request)
        {
            return Ok(await _mediator.Send(request));
        }
    }

    public abstract class RecordController<TEntity, TRepository, TCreateCommand, TUpdateCommand> : RecordController<TEntity, TRepository, TCreateCommand>
        where TEntity : Entity
        where TRepository : IRecordRepository<TEntity>
        where TCreateCommand : IRequest<ResponseResult>
        where TUpdateCommand : IRequest<ResponseResult>
    {
        public RecordController(IMediator mediator, IUnitOfWork unitOfWork, TRepository repository) : base(mediator, unitOfWork, repository)
        {
        }

        [HttpPut, Route("v1/")]
        public async virtual Task<OkObjectResult> Update([FromBody] TUpdateCommand request)
        {
            return Ok(await _mediator.Send(request));
        }
    }

    public abstract class RecordController<TEntity, TRepository, TCreateCommand, TUpdateCommand, TDeleteCommand> : RecordController<TEntity, TRepository, TCreateCommand, TUpdateCommand>
        where TEntity : Entity
        where TRepository : IRecordRepository<TEntity>
        where TCreateCommand : IRequest<ResponseResult>
        where TUpdateCommand : IRequest<ResponseResult>
        where TDeleteCommand : IRequest<ResponseResult>
    {
        public RecordController(IMediator mediator, IUnitOfWork unitOfWork, TRepository repository) : base(mediator, unitOfWork, repository)
        {
        }

        [HttpDelete, Route("v1/")]
        public async virtual Task<OkObjectResult> Delete([FromBody] TDeleteCommand request)
        {
            return Ok(await _mediator.Send(request));
        }
    }

}
