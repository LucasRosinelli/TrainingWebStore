using System.Collections.Generic;
using TrainingWebStore.Domain.Commands.ProductCommands;
using TrainingWebStore.Domain.Entities;

namespace TrainingWebStore.Domain.ApplicationServices
{
    public interface IProductApplicationService
    {
        List<Product> Get();
        List<Product> Get(int skip, int take);
        List<Product> GetProductsInStock();
        List<Product> GetProductsOutOfStock();
        Product Get(int id);
        Product Create(CreateProductCommand command);
        Product UpdateBasicInformation(UpdateProductInfoCommand command);
        Product Delete(int id);
    }
}