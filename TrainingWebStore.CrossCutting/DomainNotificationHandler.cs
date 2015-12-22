using System.Collections.Generic;
using TrainingWebStore.SharedKernel;
using TrainingWebStore.SharedKernel.Events;

namespace TrainingWebStore.CrossCutting
{
    public class DomainNotificationHandler : IHandler<DomainNotification>
    {
        private List<DomainNotification> _notifications;

        public DomainNotificationHandler()
        {
            this._notifications = new List<DomainNotification>();
        }

        public void Handle(DomainNotification args)
        {
            this._notifications.Add(args);
        }

        public IEnumerable<DomainNotification> Notify()
        {
            return this.GetValue();
        }

        private List<DomainNotification> GetValue()
        {
            return this._notifications;
        }

        public bool HasNotifications()
        {
            return this.GetValue().Count > 0;
        }

        public void Dispose()
        {
            this._notifications = new List<DomainNotification>();
        }
    }
}