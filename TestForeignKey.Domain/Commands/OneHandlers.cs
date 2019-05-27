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
    public class OneHandlers
    {
        public class CreateCommand : IRequest<ResponseResult>
        {
            public string OneProperty01 { get; set; }
            public string ManyProperty01 { get; set; }
        }


        public class Handlers : ImprovedHandler<IOneRepository>,
             IRequestHandler<CreateCommand, ResponseResult>

        {
            public Handlers(IImprovedUnitOfWork unitOfWork, IMediator mediator, IOneRepository repository) : base(unitOfWork, mediator, repository)
            {
            }

            public async Task<ResponseResult> Handle(CreateCommand request, CancellationToken cancellationToken)
            {
                _repository.IncludeInTrasation(_unitOfWork);

                var one = new One(request.OneProperty01);
                AddNotifications(one);

                _repository.Add(one);

                for (int i = 0; i < 10; i++)
                {
                    var manyRequest = new ManyHandlers.CreateCommand
                    {
                        One = one,
                        ManyProperty01 = request.ManyProperty01 + $"{i + 1}"
                    };

                   var manyResult = await _mediator.Send(manyRequest);

                    AddNotifications(manyResult);
                }

                return new ResponseResult(one, this);
            }
        }


    }
}
