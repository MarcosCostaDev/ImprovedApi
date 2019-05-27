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
    public class SelfOneHandlers
    {
        public class CreateCommand : IRequest<ResponseResult>
        {
            public string Property01 { get; set; }
            public Many Many { get; set; }
        }


        public class Handlers : ImprovedHandler<ISelfOneRepository>,
             IRequestHandler<CreateCommand, ResponseResult>

        {
            public Handlers(IImprovedUnitOfWork unitOfWork, IMediator mediator, ISelfOneRepository repository) : base(unitOfWork, mediator, repository)
            {
            }

            public async Task<ResponseResult> Handle(CreateCommand request, CancellationToken cancellationToken)
            {
                _repository.IncludeInTrasation(_unitOfWork);

                var last = _repository.Last();
                var toOne = new SelfOne(last, request.Many, request.Property01);
                AddNotifications(toOne);
                _repository.Add(toOne);
                return new ResponseResult(toOne, this);
            }
        }


    }
}
