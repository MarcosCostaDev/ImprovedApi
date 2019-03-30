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

        public class UpdateCommand : IRequest<ResponseResult>
        {
            public string ArtistId { get; set; }
            public string Name { get; set; }
        }

        public class DeleteCommand : IRequest<ResponseResult>
        {
            public int ArtistId { get; set; }
        }


        public class AuthCommand : IRequest<ResponseResult>
        {
            public string Name { get; set; }
        }

        public sealed class Handlers : ImprovedHandler<IArtistRepository>,
           IRequestHandler<CreateCommand, ResponseResult>,
            IRequestHandler<UpdateCommand, ResponseResult>,
             IRequestHandler<DeleteCommand, ResponseResult>,
            IRequestHandler<AuthCommand, ResponseResult>
        {
            readonly IAlbumRepository _albumRepository;
            public Handlers(IImprovedUnitOfWork unitOfWork, IMediator mediator, IArtistRepository repository, IAlbumRepository albumRepository) : base(unitOfWork, mediator, repository)
            {
                _albumRepository = albumRepository;
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
                /*
                var artist = _repository.GetByName(request.Name);
                contract.IsNotNull(artist, "user", "user not authenticated");
                AddNotifications(contract);
                */
                var artist = new Artist(request.Name);
                return new ResponseResult(artist, this);
            }

            public async Task<ResponseResult> Handle(UpdateCommand request, CancellationToken cancellationToken)
            {
                _repository.IncludeInTrasation(_unitOfWork);
                var artist = _repository.GetById(request.ArtistId);
                artist.Update(request.Name);
                _repository.Edit(artist);
                AddNotifications(artist);
                return new ResponseResult(artist, this);
            }

            public async Task<ResponseResult> Handle(DeleteCommand request, CancellationToken cancellationToken)
            {
                _repository.IncludeInTrasation(_unitOfWork);
                var albums = _albumRepository.GetAlbumsByArtist(request.ArtistId);
                var resultDelete = await _mediator.Send(new AlbumHandlers.DeleteManyCommand { Albums = albums });
                AddNotifications(resultDelete);
                _repository.Delete(request.ArtistId);
                return new ResponseResult(null, this);
            }
        }
    }
}
