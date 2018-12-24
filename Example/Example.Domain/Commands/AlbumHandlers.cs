using Example.Domain.Entities;
using Example.Domain.Repository;
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
    public sealed class AlbumHandlers
    {
        public class CreateCommand : IRequest<ResponseResult>
        {
            public int ArtistId { get; set; }

            public string Title { get; set; }
        }

        public sealed class Handlers : ImprovedHandler<IAlbumRepository>,
            IRequestHandler<CreateCommand, ResponseResult>
        {
            public Handlers(IImprovedUnitOfWork unitOfWork, IMediator mediator, IAlbumRepository repository) : base(unitOfWork, mediator, repository)
            {
            }

            public async Task<ResponseResult> Handle(CreateCommand request, CancellationToken cancellationToken)
            {
                _repository.IncludeInTrasation(_unitOfWork);
                var album = new Album(request.Title, request.ArtistId);
                AddNotifications(album);
                _repository.Add(album);
                return new ResponseResult(album, this);
            }
        }
    }
}
