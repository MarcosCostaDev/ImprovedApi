using Flunt.Notifications;
using ImprovedApi.Domain.Repositories.Interfaces;
using ImprovedApi.Infra.Transactions;
using MediatR;

namespace ImprovedApi.Domain.Commands
{
    public abstract class ImprovedHandler<TRepository> : Notifiable
        where TRepository : IImprovedRepository
    {
        protected readonly TRepository _repository;
        protected readonly IImprovedUnitOfWork _unitOfWork;
        protected readonly IMediator _mediator;
        public ImprovedHandler(IImprovedUnitOfWork unitOfWork, IMediator mediator, TRepository repository)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }
    }
}
