using System;

namespace TrainingWebStore.Infrastructure.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}