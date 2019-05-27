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
    public class ManyHandlers
    {
        public class CreateCommand : IRequest<ResponseResult>
        {
            public One One { get; set; }
            public string ManyProperty01 { get; set; }
        }


        public class Handlers : ImprovedHandler<IManyRepository>,
           IRequestHandler<CreateCommand, ResponseResult>

        {
            public Handlers(IImprovedUnitOfWork unitOfWork, IMediator mediator, IManyRepository repository) : base(unitOfWork, mediator, repository)
            {
            }

            public async Task<ResponseResult> Handle(CreateCommand request, CancellationToken cancellationToken)
            {
                _repository.IncludeInTrasation(_unitOfWork);

                var many = new Many(request.One, request.ManyProperty01);
                
                AddNotifications(many);
                _repository.Add(many);
                return new ResponseResult(many, this);
            }
        }
    }
}
