using System;
using System.Collections.Generic;

namespace TrainingWebStore.Domain.Entities
{
    public class Order
    {
        public Order(IList<OrderItem> orderItems, int userId)
        {
            this.Date = DateTime.Now;
            this.OrderItems = orderItems;
            this.UserId = userId;
        }

        public int Id { get; private set; }
        public DateTime Date { get; private set; }
        public ICollection<OrderItem> OrderItems { get; private set; }
        public int UserId { get; private set; }
        public User User { get; private set; }
    }
}