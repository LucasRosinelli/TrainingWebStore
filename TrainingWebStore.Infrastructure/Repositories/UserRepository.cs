using System.Linq;
using TrainingWebStore.Domain.Entities;
using TrainingWebStore.Domain.Repositories;
using TrainingWebStore.Domain.Specs;
using TrainingWebStore.Infrastructure.Persistence.DataContexts;

namespace TrainingWebStore.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private StoreDataContext _context;

        public UserRepository(StoreDataContext context)
        {
            this._context = context;
        }

        public void Register(User user)
        {
            this._context.Users.Add(user);
        }

        public User Authenticate(string email, string password)
        {
            return this._context.Users
                .Where(UserSpecs.AuthenticateUser(email, password))
                .FirstOrDefault();
        }

        public User GetByEmail(string email)
        {
            return this._context.Users
                .Where(UserSpecs.GetByEmail(email))
                .FirstOrDefault();
        }
    }
}