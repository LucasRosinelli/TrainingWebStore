using TrainingWebStore.Domain.ApplicationServices;
using TrainingWebStore.Domain.Commands.UserCommands;
using TrainingWebStore.Domain.Entities;
using TrainingWebStore.Domain.Repositories;
using TrainingWebStore.Infrastructure.Persistence;

namespace TrainingWebStore.ApplicationService
{
    public class UserApplicationService : ApplicationServiceBase, IUserApplicationService
    {
        private IUserRepository _repository;

        public UserApplicationService(IUserRepository repository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this._repository = repository;
        }

        public User Register(RegisterUserCommand command)
        {
            var user = new User(command.Email, command.Password, command.IsAdmin);
            user.Register();
            this._repository.Register(user);

            if (this.Commit())
            {
                return user;
            }

            return null;
        }

        public User Authenticate(string email, string password)
        {
            return this._repository.Authenticate(email, password);
        }
    }
}