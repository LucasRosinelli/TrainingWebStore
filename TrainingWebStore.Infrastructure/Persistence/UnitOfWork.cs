using TrainingWebStore.Infrastructure.Persistence.DataContexts;

namespace TrainingWebStore.Infrastructure.Persistence
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private StoreDataContext _context;

        public UnitOfWork(StoreDataContext context)
        {
            this._context = context;
        }

        public void Commit()
        {
            this._context.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this._context != null)
                {
                    this._context.Dispose();
                    this._context = null;
                }
            }
        }
    }
}