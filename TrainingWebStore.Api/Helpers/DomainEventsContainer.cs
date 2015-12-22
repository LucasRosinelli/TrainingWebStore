using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using TrainingWebStore.SharedKernel;

namespace TrainingWebStore.Api.Helpers
{
    public class DomainEventsContainer : IContainer
    {
        private IDependencyResolver _resolver;

        public DomainEventsContainer(IDependencyResolver resolver)
        {
            this._resolver = resolver;
        }

        public object GetService(Type serviceType)
        {
            return this._resolver.GetService(serviceType);
        }

        public T GetService<T>()
        {
            return (T)this._resolver.GetService(typeof(T));
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this._resolver.GetServices(serviceType);
        }

        public IEnumerable<T> GetServices<T>()
        {
            return (IEnumerable<T>)this._resolver.GetServices(typeof(T));
        }
    }
}