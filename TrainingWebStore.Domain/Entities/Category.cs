namespace TrainingWebStore.Domain.Entities
{
    public class Category
    {
        public Category(string title)
        {
            this.Title = title;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
    }
}