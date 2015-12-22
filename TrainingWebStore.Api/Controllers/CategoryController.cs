using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TrainingWebStore.Domain.ApplicationServices;
using TrainingWebStore.Domain.Commands.CategoryCommands;
using TrainingWebStore.SharedKernel;

namespace TrainingWebStore.Api.Controllers
{
    public class CategoryController : BaseController
    {
        private ICategoryApplicationService _service;

        public CategoryController(ICategoryApplicationService service)
        {
            this._service = service;
        }

        [HttpGet]
        [Route("api/categories")]
        public Task<HttpResponseMessage> Get()
        {
            var categories = this._service.Get();
            return base.CreateResponse(HttpStatusCode.OK, categories);
        }

        [HttpGet]
        [Route("api/categories/{skip}/{take}")]
        public Task<HttpResponseMessage> Get(int skip, int take)
        {
            var categories = this._service.Get(skip, take);
            return base.CreateResponse(HttpStatusCode.OK, categories);
        }

        [HttpGet]
        [Route("api/categories/{id}")]
        public Task<HttpResponseMessage> Get(int id)
        { 
            var categories = this._service.Get(id);
            return base.CreateResponse(HttpStatusCode.OK, categories);
        }

        [HttpPost]
        [Route("api/categories")]
        [Authorize(Roles = Constants.RoleAdmin)]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var command = new CreateCategoryCommand(
                title: (string)body.title
                );

            var category = this._service.Create(command);
            return base.CreateResponse(HttpStatusCode.Created, category);
        }

        [HttpPut]
        [Route("api/categories/{id}")]
        [Authorize(Roles = Constants.RoleAdmin)]
        public Task<HttpResponseMessage> Put(int id, [FromBody]dynamic body)
        {
            var command = new EditCategoryCommand(
                id: id,
                title: (string)body.title
                );

            var category = this._service.Update(command);
            return base.CreateResponse(HttpStatusCode.OK, category);
        }

        [HttpDelete]
        [Route("api/categories/{id}")]
        [Authorize(Roles = Constants.RoleAdmin)]
        public Task<HttpResponseMessage> Delete(int id)
        {
            var category = this._service.Delete(id);
            return base.CreateResponse(HttpStatusCode.OK, category);
        }
    }
}