using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TrainingWebStore.Domain.ApplicationServices;
using TrainingWebStore.Domain.Commands.ProductCommands;
using TrainingWebStore.SharedKernel;

namespace TrainingWebStore.Api.Controllers
{
    public class ProductController : BaseController
    {
        private IProductApplicationService _service;

        public ProductController(IProductApplicationService service)
        {
            this._service = service;
        }

        [HttpGet]
        [Route("api/products")]
        public Task<HttpResponseMessage> Get()
        {
            var products = this._service.Get();
            return base.CreateResponse(HttpStatusCode.OK, products);
        }

        [HttpGet]
        [Route("api/products/{skip:int:min(0)}/{take:int:min(1)}")]
        public Task<HttpResponseMessage> GetByRange(int skip, int take)
        {
            var products = this._service.Get(skip, take);
            return base.CreateResponse(HttpStatusCode.OK, products);
        }

        [HttpGet]
        [Route("api/products/{id}")]
        public Task<HttpResponseMessage> Get(int id)
        {
            var products = this._service.Get(id);
            return base.CreateResponse(HttpStatusCode.OK, products);
        }

        [HttpGet]
        [Route("api/products/instock")]
        public Task<HttpResponseMessage> GetInStock()
        {
            var products = this._service.GetProductsInStock();
            return base.CreateResponse(HttpStatusCode.OK, products);
        }

        [HttpGet]
        [Route("api/products/outofstock")]
        public Task<HttpResponseMessage> GetOutOfStock()
        {
            var products = this._service.GetProductsOutOfStock();
            return base.CreateResponse(HttpStatusCode.OK, products);
        }

        [HttpPost]
        [Route("api/products")]
        [Authorize(Roles = Constants.RoleAdmin)]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var command = new CreateProductCommand(
                title: (string)body.title,
                description: (string)body.description,
                price: (decimal)body.price,
                quantityOnHand: (int)body.quantityOnHand,
                category: (int)body.categoryId
                );

            var product = this._service.Create(command);
            return base.CreateResponse(HttpStatusCode.Created, product);
        }

        [HttpPut]
        [Route("api/products/{id}")]
        [Authorize(Roles = Constants.RoleAdmin)]
        public Task<HttpResponseMessage> Put(int id, [FromBody]dynamic body)
        {
            var command = new UpdateProductInfoCommand(
                id: id,
                title: (string)body.title,
                description: (string)body.description,
                category: (int)body.categoryId
                );

            var product = this._service.UpdateBasicInformation(command);
            return base.CreateResponse(HttpStatusCode.OK, product);
        }

        [HttpDelete]
        [Route("api/products/{id}")]
        [Authorize(Roles = Constants.RoleAdmin)]
        public Task<HttpResponseMessage> Delete(int id)
        {
            var product = this._service.Delete(id);
            return base.CreateResponse(HttpStatusCode.OK, product);
        }
    }
}