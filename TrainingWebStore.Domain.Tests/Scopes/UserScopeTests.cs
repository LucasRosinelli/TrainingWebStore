using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingWebStore.Domain.Entities;
using TrainingWebStore.Domain.Scopes;
using TrainingWebStore.SharedKernel.Helpers;

namespace TrainingWebStore.Domain.Tests.Scopes
{
    [TestClass]
    public class UserScopeTests
    {
        private User validUser = new User("lucas.rosinelli@hotmail.com", "123", true);
        private User invalidUserPassword = new User("lucas.rosinelli@hotmail.com", "", true);
        private User invalidUserEmail = new User("", "123456", true);

        [TestMethod]
        [TestCategory("User Scopes")]
        public void ShouldRegisterUser()
        {
            Assert.AreEqual(true, UserScopes.RegisterUserScopeIsValid(this.validUser));
        }

        [TestMethod]
        [TestCategory("User Scopes")]
        public void ShouldNotRegisterUserWhenPasswordIsInvalid()
        {
            Assert.AreEqual(false, UserScopes.RegisterUserScopeIsValid(invalidUserPassword));
        }

        [TestMethod]
        [TestCategory("User Scopes")]
        public void ShouldNotRegisterUserWhenEmailIsInvalid()
        {
            Assert.AreEqual(false, UserScopes.RegisterUserScopeIsValid(invalidUserEmail));
        }

        [TestMethod]
        [TestCategory("User Scopes")]
        public void ShouldAuthenticateUser()
        {
            var isValid = UserScopes.AuthenticateUserScopeIsValid(this.validUser, "lucas.rosinelli@hotmail.com", StringHelper.Encrypt("123"));
            Assert.AreEqual(true, isValid);
        }

        [TestMethod]
        [TestCategory("User Scopes")]
        public void ShouldNotAuthenticateUser()
        {
            var isValid = UserScopes.AuthenticateUserScopeIsValid(this.validUser, "lucas.rosinelli@hotmail.com", "123");
            Assert.AreEqual(false, isValid);
        }
    }
}