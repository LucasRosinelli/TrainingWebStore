using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using TrainingWebStore.Domain.Entities;
using TrainingWebStore.Domain.Specs;
using TrainingWebStore.SharedKernel.Helpers;

namespace TrainingWebStore.Domain.Tests.Specs
{
    [TestClass]
    public class UserSpecTests
    {
        private List<User> _users;

        public UserSpecTests()
        {
            this._users = new List<User>();
            this._users.Add(new User("lucas.rosinelli@hotmail.com", "123", true));
        }

        [TestMethod]
        [TestCategory("User Specs")]
        public void ShouldAuthenticateUser()
        {
            var exp = UserSpecs.AuthenticateUser("lucas.rosinelli@hotmail.com", "123");
            var user = this._users.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreNotEqual(null, user);
        }

        [TestMethod]
        [TestCategory("User Specs")]
        public void ShouldNotAuthenticateUserWhenEmailIsWrong()
        {
            var exp = UserSpecs.AuthenticateUser("lucas.rosinelli@gmail.com", "123");
            var user = this._users.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreEqual(null, user);
        }

        [TestMethod]
        [TestCategory("User Specs")]
        public void ShouldNotAuthenticateUserWhenPasswordIsWrong()
        {
            var exp = UserSpecs.AuthenticateUser("lucas.rosinelli@hotmail.com", "123456");
            var user = this._users.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreEqual(null, user);
        }
    }
}