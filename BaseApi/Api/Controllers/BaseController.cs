using Flunt.Notifications;
using BaseApi.Api.Exceptions;
using BaseApi.Api.Responses;
using BaseApi.Domain.Entities;
using BaseApi.Infra.Transactions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseApi.Api.Controllers
{
    public abstract class BaseController : Controller
    {
        protected IUnitOfWork _unitOfWork;
        protected IMediator _mediator;
      
        public BaseController(IMediator mediator, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        [NonAction]
        public override OkObjectResult Ok(object value)
        {

            if (value is Entity)
            {
                var convert = value as Entity;
                if (convert.Invalid) throw new EntityException(convert);
            }
            else if(value is Notifiable)
            {
                var notifiable = value as Notifiable;
                if (notifiable.Invalid) throw new EntityException(notifiable);
            }

            _unitOfWork.Commit();

            var result = new ResponseResult(value);

#if DEBUG
            System.Diagnostics.Debug.WriteLine($"Result: ${JsonConvert.SerializeObject(result)}", "Information");
#endif

            return base.Ok(result);

        }

        [NonAction]
        public OkObjectResult Ok(object value, IEnumerable<Notification> notifications)
        {
            if (notifications.Any())
            {
                throw new EntityException(notifications);
            }
            _unitOfWork.Commit();

            var result = new ResponseResult(value, notifications);

#if DEBUG
            System.Diagnostics.Debug.WriteLine($"Result: ${JsonConvert.SerializeObject(result)}", "Information");
#endif

            return base.Ok(result);
        }
    }
}
