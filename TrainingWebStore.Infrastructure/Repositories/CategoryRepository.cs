using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TrainingWebStore.Domain.Entities;
using TrainingWebStore.Domain.Repositories;
using TrainingWebStore.Infrastructure.Persistence.DataContexts;

namespace TrainingWebStore.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private StoreDataContext _context;

        public CategoryRepository(StoreDataContext context)
        {
            this._context = context;
        }

        public List<Category> Get()
        {
            return this._context.Categories.ToList();
        }

        public List<Category> Get(int skip, int take)
        {
            return this._context.Categories.OrderBy(x => x.Title)
                .OrderBy(x => x.Title)
                .Skip(skip)
                .Take(take)
                .ToList();
        }

        public Category Get(int id)
        {
            return this._context.Categories.Find(id);
        }

        public void Create(Category category)
        {
            this._context.Categories.Add(category);
        }

        public void Update(Category category)
        {
            this._context.Entry<Category>(category)
                .State = EntityState.Modified;
        }

        public void Delete(Category category)
        {
            this._context.Categories.Remove(category);
        }
    }
}