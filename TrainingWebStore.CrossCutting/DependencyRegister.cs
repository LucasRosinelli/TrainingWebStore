using Microsoft.Practices.Unity;
using TrainingWebStore.ApplicationService;
using TrainingWebStore.Domain.ApplicationServices;
using TrainingWebStore.Domain.Repositories;
using TrainingWebStore.Infrastructure.Persistence;
using TrainingWebStore.Infrastructure.Persistence.DataContexts;
using TrainingWebStore.Infrastructure.Repositories;
using TrainingWebStore.SharedKernel;
using TrainingWebStore.SharedKernel.Events;

namespace TrainingWebStore.CrossCutting
{
    public static class DependencyRegister
    {
        public static void Register(UnityContainer container)
        {
            container.RegisterType<StoreDataContext, StoreDataContext>(new HierarchicalLifetimeManager());

            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());

            container.RegisterType<IUserRepository, UserRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ICategoryRepository, CategoryRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IProductRepository, ProductRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IOrderRepository, OrderRepository>(new HierarchicalLifetimeManager());

            container.RegisterType<IUserApplicationService, UserApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<ICategoryApplicationService, CategoryApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IProductApplicationService, ProductApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IOrderApplicationService, OrderApplicationService>(new HierarchicalLifetimeManager());

            container.RegisterType<IHandler<DomainNotification>, DomainNotificationHandler>(new HierarchicalLifetimeManager());
        }
    }
}