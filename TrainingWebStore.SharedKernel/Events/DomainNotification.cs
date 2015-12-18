using System;
using TrainingWebStore.SharedKernel.Events.Contracts;

namespace TrainingWebStore.SharedKernel.Events
{
    public class DomainNotification : IDomainEvent
    {
        public DomainNotification(string key, string value)
            : this(key, value, null, null)
        {
        }

        public DomainNotification(string key, string value, string description)
            : this(key, value, description, null)
        {
        }

        public DomainNotification(string key, string value, string description, Exception exception)
        {
            this.Key = key;
            this.Value = value;
            this.Description = description;
            this.Exception = exception;
            this.DateOccurred = DateTime.Now;
        }

        public string Key { get; private set; }
        public string Value { get; private set; }
        public string Description { get; private set; }
        public Exception Exception { get; private set; }
        public DateTime DateOccurred { get; private set; }
    }
}