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
            throw new NotImplementedException();
        }

        public List<Order> GetCreated(string email)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetPaid(string email)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetDelivered(string email)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetCanceled(string email)
        {
            throw new NotImplementedException();
        }

        public Order GetDetails(int id, string email)
        {
            throw new NotImplementedException();
        }

        public Order Create(CreateOrderCommand command, string email)
        {
            //var user = this._userRepository.GetByEmail(email);
            //var orderItems = new List<OrderItem>();
            //foreach (var item in command.OrderItems)
            //{
            //    var orderItem = new OrderItem(item.Quantity, item.Price, item.ProductId, 0);
            //}
        }

        public void Pay(int id, string email)
        {
            throw new NotImplementedException();
        }

        public void Delivery(int id, string email)
        {
            throw new NotImplementedException();
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