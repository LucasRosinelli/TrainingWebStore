using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TrainingWebStore.SharedKernel;
using TrainingWebStore.SharedKernel.Events;

namespace TrainingWebStore.SharedKernel.Validation
{
    public static class AssertionConcern
    {
        public static bool IsSatisfiedBy(params DomainNotification[] validations)
        {
            var notificationsNotNull = validations.Where(validation => validation != null);
            NotifyAll(notificationsNotNull);

            return notificationsNotNull.Count().Equals(0);
        }

        private static void NotifyAll(IEnumerable<DomainNotification> notifications)
        {
            notifications.ToList().ForEach(validation =>
            {
                DomainEvent.Raise<DomainNotification>(validation);
            });
        }

        public static DomainNotification AssertLength(string value, int minimum, int maximum, string message)
        {
            int length = string.IsNullOrEmpty(value) ? 0 : value.Trim().Length;

            if (length < minimum || length > maximum)
            {
                return new DomainNotification(Constants.AssertArgumentLength, message);
            }

            return null;
        }

        public static DomainNotification AssertMatches(string pattern, string value, string message)
        {
            Regex regex = new Regex(pattern);

            if (!regex.IsMatch(value))
            {
                return new DomainNotification(Constants.AssertArgumentMatches, message);
            }

            return null;
        }

        public static DomainNotification AssertNotEmpty(string value, string message)
        {
            if (string.IsNullOrEmpty(value))
            {
                return new DomainNotification(Constants.AssertArgumentNotEmpty, message);
            }

            return null;
        }

        public static DomainNotification AssertNotNull(object object1, string message)
        {
            if (object1 == null)
            {
                return new DomainNotification(Constants.AssertArgumentNotNull, message);
            }

            return null;
        }

        public static DomainNotification AssertTrue(bool value, string message)
        {
            if (!value)
            {
                return new DomainNotification(Constants.AssertArgumentTrue, message);
            }

            return null;
        }

        public static DomainNotification AssertAreEquals(string value, string match, string message)
        {
            if (!(value == match))
            {
                return new DomainNotification(Constants.AssertArgumentAreEquals, message);
            }

            return null;
        }

        public static DomainNotification AssertIsGreaterThan(int value1, int value2, string message)
        {
            if (!(value1 > value2))
            {
                return new DomainNotification(Constants.AssertArgumentIsGreaterThan, message);
            }

            return null;
        }

        public static DomainNotification AssertIsGreaterThan(decimal value1, decimal value2, string message)
        {
            if (!(value1 > value2))
            {
                return new DomainNotification(Constants.AssertArgumentIsGreaterThan, message);
            }

            return null;
        }

        public static DomainNotification AssertIsGreaterOrEqualThan(int value1, int value2, string message)
        {
            if (!(value1 >= value2))
            {
                return new DomainNotification(Constants.AssertArgumentIsGreaterOrEqualThan, message);
            }

            return null;
        }

        public static DomainNotification AssertIsGreaterOrEqualThan(decimal value1, decimal value2, string message)
        {
            if (!(value1 >= value2))
            {
                return new DomainNotification(Constants.AssertArgumentIsGreaterOrEqualThan, message);
            }

            return null;
        }
    }
}