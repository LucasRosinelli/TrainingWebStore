using System.Collections.Generic;
using TrainingWebStore.Domain.ApplicationServices;
using TrainingWebStore.Domain.Commands.OrderCommands;
using TrainingWebStore.Domain.Entities;
using TrainingWebStore.Domain.Repositories;
using TrainingWebStore.Infrastructure.Persistence;

namespace TrainingWebStore.ApplicationService
{
    public class OrderApplicationService : ApplicationServiceBase, IOrderApplicationService
    {
        private IOrderRepository _orderRepository;
        private IUserRepository _userRepository;
        private IProductRepository _productRepository;

        public OrderApplicationService(IOrderRepository orderRepository, IUserRepository userRepository, IProductRepository productRepository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this._orderRepository = orderRepository;
            this._userRepository = userRepository;
            this._productRepository = productRepository;
        }

        public List<Order> Get(string email, int skip, int take)
        {
            return this._orderRepository.Get(email, skip, take);
        }

        public List<Order> GetCreated(string email)
        {
            return this._orderRepository.GetCreated(email);
        }

        public List<Order> GetPaid(string email)
        {
            return this._orderRepository.GetPaid(email);
        }

        public List<Order> GetDelivered(string email)
        {
            return this._orderRepository.GetDelivered(email);
        }

        public List<Order> GetCanceled(string email)
        {
            return this._orderRepository.GetCanceled(email);
        }

        public Order GetDetails(int id, string email)
        {
            return this._orderRepository.GetDetails(id, email);
        }

        public Order Create(CreateOrderCommand command, string email)
        {
            var user = this._userRepository.GetByEmail(email);
            var orderItems = new List<OrderItem>();
            foreach (var item in command.OrderItems)
            {
                var orderItem = new OrderItem();
                var product = this._productRepository.Get(item.ProductId);
                orderItem.AddProduct(product, item.Quantity, item.Price);
                orderItems.Add(orderItem);
            }

            var order = new Order(orderItems, user.Id);
            order.Place();
            this._orderRepository.Create(order);

            if (this.Commit())
            {
                return order;
            }

            return null;
        }

        public void Pay(int id, string email)
        {
            var order = this._orderRepository.GetHeader(id, email);
            order.MarkAsPaid();
            this._orderRepository.Update(order);

            this.Commit();
        }

        public void Delivery(int id, string email)
        {
            var order = this._orderRepository.GetHeader(id, email);
            order.MarkAsDelivered();
            this._orderRepository.Update(order);

            this.Commit();
        }

        public void Cancel(int id, string email)
        {
            var order = this._orderRepository.GetHeader(id, email);
            order.Cancel();
            this._orderRepository.Update(order);

            this.Commit();
        }
    }
}