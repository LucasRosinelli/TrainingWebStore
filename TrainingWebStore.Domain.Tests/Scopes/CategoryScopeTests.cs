using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingWebStore.Domain.Entities;
using TrainingWebStore.Domain.Scopes;

namespace TrainingWebStore.Domain.Tests.Scopes
{
    [TestClass]
    public class CategoryScopeTests
    {
        [TestMethod]
        [TestCategory("Category Scopes")]
        public void ShouldRegisterCategory()
        {
            var category = new Category("Placa Mãe");
            Assert.AreEqual(true, CategoryScopes.CreateCategoryScopeIsValid(category));
        }

        [TestMethod]
        [TestCategory("Category Scopes")]
        public void ShouldUpdateCategoryTitle()
        {
            var category = new Category("Placa Mãe");
            Assert.AreEqual(true, CategoryScopes.UpdateCategoryScopeIsValid(category, "Motherboards"));
        }
    }
}