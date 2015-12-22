using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TrainingWebStore.Domain.ApplicationServices;
using TrainingWebStore.Domain.Commands.OrderCommands;
using TrainingWebStore.SharedKernel;

namespace TrainingWebStore.Api.Controllers
{
    public class OrderController : BaseController
    {
        private IOrderApplicationService _service;

        public OrderController(IOrderApplicationService service)
        {
            this._service = service;
        }

        [HttpPost]
        [Route("api/orders")]
        [Authorize]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var command = new CreateOrderCommand(
                orderItems: body.orderItems.ToObject<List<CreateOrderItemCommand>>()
                );

            var order = this._service.Create(command, this.User.Identity.Name);
            return base.CreateResponse(HttpStatusCode.Created, order);
        }
    }
}