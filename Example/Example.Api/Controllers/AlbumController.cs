using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example.Domain.Commands;
using Example.Domain.Entities;
using Example.Domain.Repository;
using ImprovedApi.Api.Controllers;
using ImprovedApi.Infra.Transactions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Example.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ImprovedRecordController<Album, IAlbumRepository, AlbumHandlers.CreateCommand, AlbumHandlers.UpdateCommand, AlbumHandlers.DeleteCommand>
    {
        public AlbumController(IMediator mediator, IImprovedUnitOfWork unitOfWork, IAlbumRepository repository) : base(mediator, unitOfWork, repository)
        {
        }


    }
}