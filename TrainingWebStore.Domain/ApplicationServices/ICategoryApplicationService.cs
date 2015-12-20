using System.Collections.Generic;
using TrainingWebStore.Domain.Commands.CategoryCommands;
using TrainingWebStore.Domain.Entities;

namespace TrainingWebStore.Domain.ApplicationServices
{
    public interface ICategoryApplicationService
    {
        List<Category> Get();
        List<Category> Get(int skip, int take);
        Category Get(int id);
        Category Create(CreateCategoryCommand command);
        Category Update(EditCategoryCommand command);
        Category Delete(int id);
    }
}