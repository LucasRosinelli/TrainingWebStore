using TrainingWebStore.Domain.Scopes;

namespace TrainingWebStore.Domain.Entities
{
    public class Category
    {
        protected Category()
        {
        }

        public Category(string title)
        {
            this.Title = title;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }

        public void Register()
        {
            this.CreateCategoryScopeIsValid();
        }

        public void UpdateTitle(string title)
        {
            if (!this.UpdateCategoryScopeIsValid(title))
            {
                return;
            }

            this.Title = title;
        }
    }
}