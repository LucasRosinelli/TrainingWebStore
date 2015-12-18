namespace TrainingWebStore.Domain.Entities
{
    public class Product
    {
        public Product(string title, string description, decimal price, int quantityOnHand, int categoryId)
        {
            this.Title = title;
            this.Description = description;
            this.Price = price;
            this.QuantityOnHand = quantityOnHand;
            this.CategoryId = categoryId;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int QuantityOnHand { get; private set; }

        public int CategoryId { get; private set; }
        public Category Category { get; private set; }
    }
}