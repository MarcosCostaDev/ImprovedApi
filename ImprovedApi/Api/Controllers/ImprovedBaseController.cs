using Flunt.Notifications;
using ImprovedApi.Api.Exceptions;
using ImprovedApi.Api.Responses;
using ImprovedApi.Domain.Entities;
using ImprovedApi.Infra.Transactions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImprovedApi.Api.Controllers
{
    public abstract class ImprovedBaseController : Controller
    {
        protected IImprovedUnitOfWork _unitOfWork;
        protected IMediator _mediator;
      
        public ImprovedBaseController(IMediator mediator, IImprovedUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        [NonAction]
        public override OkObjectResult Ok(object value)
        {

            if (value is ImprovedEntity)
            {
                var convert = value as ImprovedEntity;
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
            System.Diagnostics.Debug.WriteLine($@"Result: ${JsonConvert.SerializeObject(result, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            })}", "Information");
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
            System.Diagnostics.Debug.WriteLine($@"Result: ${JsonConvert.SerializeObject(result, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            })}", "Information");
#endif

            return base.Ok(result);
        }

        [NonAction]
        public OkObjectResult Unauthorized(string message)
        {
            throw new UnauthorizedException(message);
        }

        [NonAction]
        public OkObjectResult Unauthorized(object value)
        {

            if (value is ImprovedEntity)
            {
                var convert = value as ImprovedEntity;              
                if (convert.Invalid) throw new UnauthorizedException(convert.Notifications);
            }
            else if (value is Notifiable)
            {
                var notifiable = value as Notifiable;
                if (notifiable.Invalid) throw new UnauthorizedException(notifiable.Notifications);
            }

            _unitOfWork.Commit();

            var result = new ResponseResult(value);

#if DEBUG
            System.Diagnostics.Debug.WriteLine($@"Result: ${JsonConvert.SerializeObject(result, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            })}", "Information");
#endif

            return base.Ok(result);

        }

        [NonAction]
        public OkObjectResult Unauthorized(object value, IEnumerable<Notification> notifications)
        {
            if (notifications.Any())
            {
                throw new UnauthorizedException(notifications);
            }
            _unitOfWork.Commit();

            var result = new ResponseResult(value, notifications);

#if DEBUG
            System.Diagnostics.Debug.WriteLine($@"Result: ${JsonConvert.SerializeObject(result, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            })}", "Information");
#endif

            return base.Ok(result);
        }

    }
}
