using System.Collections.Generic;
using TrainingWebStore.Domain.ApplicationServices;
using TrainingWebStore.Domain.Commands.CategoryCommands;
using TrainingWebStore.Domain.Entities;
using TrainingWebStore.Domain.Repositories;
using TrainingWebStore.Infrastructure.Persistence;

namespace TrainingWebStore.ApplicationService
{
    public class CategoryApplicationService : ApplicationServiceBase, ICategoryApplicationService
    {
        private ICategoryRepository _repository;

        public CategoryApplicationService(ICategoryRepository repository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this._repository = repository;
        }

        public List<Category> Get()
        {
            return this._repository.Get();
        }

        public List<Category> Get(int skip, int take)
        {
            return this._repository.Get(skip, take);
        }

        public Category Get(int id)
        {
            return this._repository.Get(id);
        }

        public Category Create(CreateCategoryCommand command)
        {
            var category = new Category(command.Title);
            category.Register();
            this._repository.Create(category);

            if (this.Commit())
            {
                return category;
            }

            return null;
        }

        public Category Update(EditCategoryCommand command)
        {
            var category = this._repository.Get(command.Id);
            category.UpdateTitle(command.Title);
            this._repository.Update(category);

            if (this.Commit())
            {
                return category;
            }

            return null;
        }

        public Category Delete(int id)
        {
            var category = this._repository.Get(id);
            this._repository.Delete(category);

            if (this.Commit())
            {
                return category;
            }

            return null;
        }
    }
}