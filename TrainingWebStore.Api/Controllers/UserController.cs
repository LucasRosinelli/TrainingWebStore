using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TrainingWebStore.Domain.ApplicationServices;
using TrainingWebStore.Domain.Commands.UserCommands;

namespace TrainingWebStore.Api.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserApplicationService _service;

        public UserController(IUserApplicationService service)
        {
            this._service = service;
        }

        [HttpPost]
        [Route("api/users")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var command = new RegisterUserCommand(
                email: (string)body.email,
                password: (string)body.password,
                isAdmin: (bool)body.isAdmin
                );
            var user = this._service.Register(command);

            return base.CreateResponse(HttpStatusCode.Created, user);
        }
    }
}