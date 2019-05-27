using ImprovedApi.Api.Responses;
using ImprovedApi.Domain.Commands;
using ImprovedApi.Infra.Transactions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestForeignKey.Domain.Entities;
using TestForeignKey.Domain.Repositories;

namespace TestForeignKey.Domain.Commands
{
    public class ToOneHandlers
    {
        public class CreateCommand : IRequest<ResponseResult>
        {
            public string Property01 { get; set; }
            public Many Many { get; set; }
        }


        public class Handlers : ImprovedHandler<IToOneRepository>,
             IRequestHandler<CreateCommand, ResponseResult>

        {
            public Handlers(IImprovedUnitOfWork unitOfWork, IMediator mediator, IToOneRepository repository) : base(unitOfWork, mediator, repository)
            {
            }

            public async Task<ResponseResult> Handle(CreateCommand request, CancellationToken cancellationToken)
            {
                _repository.IncludeInTrasation(_unitOfWork);

                var toOne = new ToOne(request.Many, request.Property01);
                AddNotifications(toOne);
                _repository.Add(toOne);
                return new ResponseResult(toOne, this);
            }
        }


    }
}
