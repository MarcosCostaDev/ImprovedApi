using Example.Domain.Entities;
using Example.Domain.Repository;
using Flunt.Validations;
using ImprovedApi.Api.Responses;
using ImprovedApi.Domain.Commands;
using ImprovedApi.Infra.Transactions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example.Domain.Commands
{
    public sealed class ArtistHandlers
    {
        public class CreateCommand : IRequest<ResponseResult>
        {
            public string Name { get; set; }
        }

        public class AuthCommand : IRequest<ResponseResult>
        {
            public string Name { get; set; }
        }

        public sealed class Handlers : ImprovedHandler<IArtistRepository>,
           IRequestHandler<CreateCommand, ResponseResult>,
            IRequestHandler<AuthCommand, ResponseResult>
        {
            public Handlers(IImprovedUnitOfWork unitOfWork, IMediator mediator, IArtistRepository repository) : base(unitOfWork, mediator, repository)
            {
            }

            public async Task<ResponseResult> Handle(CreateCommand request, CancellationToken cancellationToken)
            {
                _repository.IncludeInTrasation(_unitOfWork);
                var artist = new Artist(request.Name);
                AddNotifications(artist);
                return new ResponseResult(artist, this);
            }

            public async Task<ResponseResult> Handle(AuthCommand request, CancellationToken cancellationToken)
            {
                var contract = new Contract();
                var artist = _repository.GetByName(request.Name);
                contract.IsNotNull(artist, "user", "user not authenticated");
                AddNotifications(contract);
                return new ResponseResult(artist, this);
            }
        }
    }
}
