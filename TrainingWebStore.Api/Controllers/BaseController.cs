using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TrainingWebStore.SharedKernel;
using TrainingWebStore.SharedKernel.Events;

namespace TrainingWebStore.Api.Controllers
{
    public class BaseController : ApiController
    {
        public IHandler<DomainNotification> Notifications;
        public HttpResponseMessage ResponseMessage;

        public BaseController()
        {
            this.Notifications=DomainEvent.Container.GetService<IHandler<DomainNotification>>();
            this.ResponseMessage = new HttpResponseMessage();
        }

        protected override void Dispose(bool disposing)
        {
            this.Notifications.Dispose();
        }

        public Task<HttpResponseMessage> CreateResponse(HttpStatusCode code, object result)
        {
            if (this.Notifications.HasNotifications())
            {
                this.ResponseMessage = this.Request.CreateResponse(HttpStatusCode.BadRequest, new { errors = this.Notifications.Notify() });
            }
            else
            {
                this.ResponseMessage = this.Request.CreateResponse(code, result);
            }

            return Task.FromResult<HttpResponseMessage>(this.ResponseMessage);
        }
    }
}