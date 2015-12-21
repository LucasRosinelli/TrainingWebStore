using TrainingWebStore.Infrastructure.Persistence;
using TrainingWebStore.SharedKernel;
using TrainingWebStore.SharedKernel.Events;

namespace TrainingWebStore.ApplicationService
{
    public class ApplicationServiceBase
    {
        private IUnitOfWork _unitOfWork;
        private IHandler<DomainNotification> _notifications;

        public ApplicationServiceBase(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this._notifications = DomainEvent.Container.GetService<IHandler<DomainNotification>>();
        }

        public bool Commit()
        {
            if (this._notifications.HasNotifications())
            {
                return false;
            }

            this._unitOfWork.Commit();
            return true;
        }
    }
}