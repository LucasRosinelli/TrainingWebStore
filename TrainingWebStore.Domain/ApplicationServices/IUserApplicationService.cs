using TrainingWebStore.Domain.Commands.UserCommands;
using TrainingWebStore.Domain.Entities;

namespace TrainingWebStore.Domain.ApplicationServices
{
    public interface IUserApplicationService
    {
        User Register(RegisterUserCommand command);
        User Authenticate(string email, string password);
    }
}