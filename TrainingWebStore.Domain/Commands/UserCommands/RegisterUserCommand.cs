namespace TrainingWebStore.Domain.Commands.UserCommands
{
    public class RegisterUserCommand
    {
        public RegisterUserCommand(string email, string password, bool isAdmin)
        {
            this.Email = email;
            this.Password = password;
            this.IsAdmin = isAdmin;
        }

        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}