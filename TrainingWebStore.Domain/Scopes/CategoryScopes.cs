using TrainingWebStore.Domain.Entities;
using TrainingWebStore.SharedKernel.Validation;

namespace TrainingWebStore.Domain.Scopes
{
    public static class CategoryScopes
    {
        public static bool CreateCategoryScopeIsValid(this Category category)
        {
            return AssertionConcern.IsSatisfiedBy
                (
                    AssertionConcern.AssertNotEmpty(category.Title, "O título é obrigatório."),
                    AssertionConcern.AssertLength(category.Title, 3, 30, "Tamanho do título inválido.")
                );
        }

        public static bool UpdateCategoryScopeIsValid(this Category category, string title)
        {
            return AssertionConcern.IsSatisfiedBy
                (
                    AssertionConcern.AssertNotEmpty(title, "O título é obrigatório."),
                    AssertionConcern.AssertLength(title, 3, 30, "Tamanho do título inválido.")
                );
        }
    }
}