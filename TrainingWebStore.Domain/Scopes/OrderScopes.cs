using System.Linq;
using TrainingWebStore.Domain.Entities;
using TrainingWebStore.SharedKernel.Validation;

namespace TrainingWebStore.Domain.Scopes
{
    public static class OrderScopes
    {
        public static bool PlaceOrderScopeIsValid(this Order order)
        {
            return AssertionConcern.IsSatisfiedBy
                (
                    AssertionConcern.AssertIsGreaterThan(order.OrderItems.Count(), 0, "Nenhum produto pode estar sem itens.")
                );
        }
    }
}