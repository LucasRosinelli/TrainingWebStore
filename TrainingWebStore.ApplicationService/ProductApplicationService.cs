using System.Collections.Generic;
using TrainingWebStore.Domain.ApplicationServices;
using TrainingWebStore.Domain.Commands.ProductCommands;
using TrainingWebStore.Domain.Entities;
using TrainingWebStore.Domain.Repositories;
using TrainingWebStore.Infrastructure.Persistence;

namespace TrainingWebStore.ApplicationService
{
    public class ProductApplicationService : ApplicationServiceBase, IProductApplicationService
    {
        private IProductRepository _repository;

        public ProductApplicationService(IProductRepository repository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this._repository = repository;
        }

        public List<Product> Get()
        {
            return this._repository.Get();
        }

        public List<Product> Get(int skip, int take)
        {
            return this._repository.Get(skip, take);
        }

        public List<Product> GetProductsInStock()
        {
            return this._repository.GetProductsInStock();
        }

        public List<Product> GetProductsOutOfStock()
        {
            return this._repository.GetProductsOutOfStock();
        }

        public Product Get(int id)
        {
            return this._repository.Get(id);
        }

        public Product Create(CreateProductCommand command)
        {
            var product = new Product(command.Title, command.Description, command.Price, command.QuantityOnHand, command.Category);
            product.Register();
            this._repository.Create(product);

            if (this.Commit())
            {
                return product;
            }

            return null;
        }

        public Product UpdateBasicInformation(UpdateProductInfoCommand command)
        {
            var product = this._repository.Get(command.Id);
            product.UpdateInfo(command.Title, command.Description, command.Category);
            this._repository.Update(product);

            if (this.Commit())
            {
                return product;
            }

            return null;
        }

        public Product Delete(int id)
        {
            var product = this._repository.Get(id);
            this._repository.Delete(product);

            if (this.Commit())
            {
                return product;
            }

            return null;
        }
    }
}