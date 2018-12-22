using Flunt.Notifications;
using BaseApi.Domain.Repositories.Interfaces;
using BaseApi.Infra.Transactions;
using MediatR;

namespace BaseApi.Domain.Commands
{
    public abstract class BaseHandler<TRepository> : Notifiable
        where TRepository : IRepository
    {
        protected readonly TRepository _repository;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMediator _mediator;
        public BaseHandler(IUnitOfWork unitOfWork, IMediator mediator, TRepository repository)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }
    }
}
