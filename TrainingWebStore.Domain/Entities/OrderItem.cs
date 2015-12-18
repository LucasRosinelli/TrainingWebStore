using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingWebStore.Domain.Entities
{
    public class OrderItem
    {
        public OrderItem(int quantity, decimal price, int productId, int orderId)
        {
            this.Quantity = quantity;
            this.Price = price;
            this.ProductId = productId;
            this.OrderId = orderId;
        }

        public int Id { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }
        public int ProductId { get; private set; }
        public Product Product { get; private set; }
        public int OrderId { get; private set; }
        public Order Order { get; private set; }
    }
}