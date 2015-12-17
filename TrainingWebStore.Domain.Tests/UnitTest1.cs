using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingWebStore.Domain.Entities;
using System.Collections.Generic;

namespace TrainingWebStore.Domain.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var category = new Category("Placa Mãe");
            var product = new Product("Processador", "Intel i7", 1200, 5, 1);
            var order = new Order(new List<OrderItem>(), 1);
            order.OrderItems.Add(new OrderItem());

            // Save category!
        }
    }
}
