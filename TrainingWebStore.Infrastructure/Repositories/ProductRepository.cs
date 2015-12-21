using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TrainingWebStore.Domain.Entities;
using TrainingWebStore.Domain.Repositories;
using TrainingWebStore.Domain.Specs;
using TrainingWebStore.Infrastructure.Persistence.DataContexts;

namespace TrainingWebStore.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private StoreDataContext _context;

        public ProductRepository(StoreDataContext context)
        {
            this._context = context;
        }

        public List<Product> Get()
        {
            return this._context.Products
                .ToList();
        }

        public List<Product> Get(int skip, int take)
        {
            return this._context.Products
                .OrderBy(x => x.Title)
                .Skip(skip)
                .Take(take)
                .ToList();
        }

        public List<Product> GetProductsInStock()
        {
            return this._context.Products
                .Where(ProductSpecs.GetProductsInStock())
                .OrderBy(x => x.Title)
                .ToList();
        }

        public List<Product> GetProductsOutOfStock()
        {
            return this._context.Products
                .Where(ProductSpecs.GetProductsOutOfStock())
                .OrderBy(x => x.Title)
                .ToList();
        }

        public Product Get(int id)
        {
            return this._context.Products
                .Find(id);
        }

        public void Create(Product product)
        {
            this._context.Products.Add(product);
        }

        public void Update(Product product)
        {
            this._context.Entry<Product>(product)
                .State = EntityState.Modified;
        }

        public void Delete(Product product)
        {
            this._context.Products.Remove(product);
        }
    }
}