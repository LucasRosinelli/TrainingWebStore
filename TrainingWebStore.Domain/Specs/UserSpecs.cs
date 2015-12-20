using System;
using System.Linq.Expressions;
using TrainingWebStore.Domain.Entities;
using TrainingWebStore.SharedKernel.Helpers;

namespace TrainingWebStore.Domain.Specs
{
    public static class UserSpecs
    {
        public static Expression<Func<User, bool>> AuthenticateUser(string email, string password)
        {
            string encryptedPassword = StringHelper.Encrypt(password);
            return x => x.Email == email && x.Password == encryptedPassword;
        }

        public static Expression<Func<User, bool>> GetByEmail(string email)
        {
            return x => x.Email == email;
        }
    }
}