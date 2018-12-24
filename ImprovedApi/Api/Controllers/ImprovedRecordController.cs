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

    public abstract class ImprovedRecordController<TEntity, TRepository, TCreateCommand> : ImprovedQueryController<TEntity, TRepository>
        where TEntity : ImprovedEntity
        where TRepository : IImprovedRecordRepository<TEntity>
        where TCreateCommand : IRequest<ResponseResult>
    {
        public ImprovedRecordController(IMediator mediator, IImprovedUnitOfWork unitOfWork, TRepository repository) : base(mediator, unitOfWork, repository)
        {
        }

        [HttpPost, Route("v1/")]
        public async virtual Task<OkObjectResult> Create([FromBody] TCreateCommand request)
        {
            return Ok(await _mediator.Send(request));
        }
    }

    public abstract class ImprovedRecordController<TEntity, TRepository, TCreateCommand, TUpdateCommand> : ImprovedRecordController<TEntity, TRepository, TCreateCommand>
        where TEntity : ImprovedEntity
        where TRepository : IImprovedRecordRepository<TEntity>
        where TCreateCommand : IRequest<ResponseResult>
        where TUpdateCommand : IRequest<ResponseResult>
    {
        public ImprovedRecordController(IMediator mediator, IImprovedUnitOfWork unitOfWork, TRepository repository) : base(mediator, unitOfWork, repository)
        {
        }

        [HttpPut, Route("v1/")]
        public async virtual Task<OkObjectResult> Update([FromBody] TUpdateCommand request)
        {
            return Ok(await _mediator.Send(request));
        }
    }

    public abstract class ImprovedRecordController<TEntity, TRepository, TCreateCommand, TUpdateCommand, TDeleteCommand> : ImprovedRecordController<TEntity, TRepository, TCreateCommand, TUpdateCommand>
        where TEntity : ImprovedEntity
        where TRepository : IImprovedRecordRepository<TEntity>
        where TCreateCommand : IRequest<ResponseResult>
        where TUpdateCommand : IRequest<ResponseResult>
        where TDeleteCommand : IRequest<ResponseResult>
    {
        public ImprovedRecordController(IMediator mediator, IImprovedUnitOfWork unitOfWork, TRepository repository) : base(mediator, unitOfWork, repository)
        {
        }

        [HttpDelete, Route("v1/")]
        public async virtual Task<OkObjectResult> Delete([FromBody] TDeleteCommand request)
        {
            return Ok(await _mediator.Send(request));
        }
    }

}
