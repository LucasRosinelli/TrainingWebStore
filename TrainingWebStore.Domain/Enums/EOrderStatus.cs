using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingWebStore.Domain.Enums
{
    public enum EOrderStatus
    {
        Created = 1,
        Paid = 2,
        Delivered = 3,
        Canceled = 4
    }
}