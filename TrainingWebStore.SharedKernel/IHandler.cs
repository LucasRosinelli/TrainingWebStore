using System;
using System.Collections.Generic;
using TrainingWebStore.SharedKernel.Events.Contracts;

namespace TrainingWebStore.SharedKernel
{
    public interface IHandler<T> : IDisposable
        where T : IDomainEvent
    {
        void Handle(T args);
        IEnumerable<T> Notify();
        bool HasNotifications();
    }
}