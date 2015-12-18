using System;
using System.Collections.Generic;
using System.Linq;
using TrainingWebStore.Domain.Enums;
using TrainingWebStore.SharedKernel.Events;
using TrainingWebStore.SharedKernel.Validation;

namespace TrainingWebStore.Domain.Entities
{
    public class Order
    {
        private IList<OrderItem> _orderItems;

        public Order(IList<OrderItem> orderItems, int userId)
        {
            this.Date = DateTime.Now;
            this._orderItems = new List<OrderItem>();
            orderItems.ToList().ForEach(x => this.AddItem(x));
            this.Status = EOrderStatus.Created;
            this.UserId = userId;
        }

        public int Id { get; private set; }
        public DateTime Date { get; private set; }
        public IEnumerable<OrderItem> OrderItems
        {
            get { return this._orderItems; }
            private set { this._orderItems = new List<OrderItem>(value); }
        }
        public decimal Total
        {
            get
            {
                decimal total = 0.0M;
                foreach (var item in this._orderItems)
                {
                    total += (item.Price * item.Quantity);
                }

                return total;
            }
        }
        public EOrderStatus Status { get; private set; }

        public int UserId { get; private set; }
        public User User { get; private set; }

        public void AddItem(OrderItem orderItem)
        {
            #region Removido
            //if (orderItem == null)
            //{
            //    throw new NullReferenceException("Item inválido");
            //}
            //if (orderItem.Price <= 0.0M)
            //{
            //    throw new Exception("Preço inválido (menor ou igual a zero)");
            //}
            //if (orderItem.Quantity <= 0)
            //{
            //    throw new Exception("Quantidade inválida (menor ou igual a zero)");
            //}

            //this._orderItems.Add(orderItem);
            #endregion
            AssertionConcern.AssertLength("123456", 2, 5, "Mínimo de 2 caracteres");
        }
    }
}