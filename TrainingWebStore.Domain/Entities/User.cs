using TrainingWebStore.Domain.Scopes;
using TrainingWebStore.SharedKernel.Helpers;

namespace TrainingWebStore.Domain.Entities
{
    public class User
    {
        public User(string email, string password, bool isAdmin)
        {
            this.Email = email;
            this.Password = StringHelper.Encrypt(password);
            this.IsAdmin = isAdmin;
        }

        public int Id { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public bool IsAdmin { get; private set; }

        public void Register()
        {
            this.RegisterUserScopeIsValid();
        }

        public void Authenticate(string email, string encryptedPassword)
        {
            this.AuthenticateUserScopeIsValid(email, encryptedPassword);
        }

        public void GrantAdmin()
        {
            this.IsAdmin = true;
        }

        public void RevokeAdmin()
        {
            this.IsAdmin = false;
        }
    }
}