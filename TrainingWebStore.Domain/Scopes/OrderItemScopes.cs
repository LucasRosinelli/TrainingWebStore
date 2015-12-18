using TrainingWebStore.Domain.Entities;
using TrainingWebStore.SharedKernel.Validation;

namespace TrainingWebStore.Domain.Scopes
{
    public static class OrderItemScopes
    {
        public static bool RegisterOrderItemScopeIsValid(this OrderItem orderItem)
        {
            return AssertionConcern.IsSatisfiedBy
                (
                    AssertionConcern.AssertIsGreaterThan(orderItem.Quantity, 0, "Quantidade inválida."),
                    AssertionConcern.AssertIsGreaterThan(orderItem.Price, 0.0M, "Preço inválido."),
                    AssertionConcern.AssertIsGreaterThan(orderItem.ProductId, 0, "Produto inválido.")
                );
        }

        public static bool AddProductScopeIsValid(this OrderItem orderItem, Product product, int quantity, decimal price)
        {
            return AssertionConcern.IsSatisfiedBy
                (
                    AssertionConcern.AssertIsGreaterThan((product.QuantityOnHand - quantity), 0, string.Concat("Produto fora de estoque: ", product.Title, ".")),
                    AssertionConcern.AssertIsGreaterThan(quantity, 0, "Quantidade deve ser maior que zero."),
                    AssertionConcern.AssertIsGreaterThan(price, 0.0M, "Preço deve ser maior que zero.")
                );
        }
    }
}