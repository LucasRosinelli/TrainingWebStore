using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TrainingWebStore.Domain.Entities;
using TrainingWebStore.Domain.Repositories;
using TrainingWebStore.Domain.Specs;
using TrainingWebStore.Infrastructure.Persistence.DataContexts;

namespace TrainingWebStore.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private StoreDataContext _context;

        public OrderRepository(StoreDataContext context)
        {
            this._context = context;
        }

        public List<Order> Get(string email, int skip, int take)
        {
            return this._context.Orders
                .Where(OrderSpecs.GetOrdersFromUser(email))
                .OrderByDescending(x => x.Date)
                .Skip(skip)
                .Take(take)
                .ToList();
        }

        public List<Order> GetCreated(string email)
        {
            return this._context.Orders
                .Where(OrderSpecs.GetCreatedOrders(email))
                .OrderByDescending(x => x.Date)
                .ToList();
        }

        public List<Order> GetPaid(string email)
        {
            return this._context.Orders
                .Where(OrderSpecs.GetPaidOrders(email))
                .OrderByDescending(x => x.Date)
                .ToList();
        }

        public List<Order> GetDelivered(string email)
        {
            return this._context.Orders
                .Where(OrderSpecs.GetDeliveredOrders(email))
                .OrderByDescending(x => x.Date)
                .ToList();
        }

        public List<Order> GetCanceled(string email)
        {
            return this._context.Orders
                .Where(OrderSpecs.GetCanceledOrders(email))
                .OrderByDescending(x => x.Date)
                .ToList();
        }

        public Order GetDetails(int id, string email)
        {
            return this._context.Orders
                .Include(x => x.OrderItems)
                .Where(OrderSpecs.GetOrderDetails(id, email))
                .FirstOrDefault();
        }

        public Order GetHeader(int id, string email)
        {
            return this._context.Orders
                .Where(OrderSpecs.GetOrderDetails(id, email))
                .FirstOrDefault();
        }

        public void Create(Order order)
        {
            this._context.Orders.Add(order);
        }

        public void Update(Order order)
        {
            this._context.Entry<Order>(order)
                .State = EntityState.Modified;
        }
    }
}