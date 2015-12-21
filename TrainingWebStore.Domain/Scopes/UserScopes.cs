using TrainingWebStore.Domain.Entities;
using TrainingWebStore.SharedKernel.Validation;

namespace TrainingWebStore.Domain.Scopes
{
    public static class UserScopes
    {
        public static bool RegisterUserScopeIsValid(this User user)
        {
            return AssertionConcern.IsSatisfiedBy
                (
                    AssertionConcern.AssertNotEmpty(user.Email, "O e-mail é obrigatório."),
                    AssertionConcern.AssertLength(user.Email, 0, 256, "Tamanho do e-mail inválido."),
                    AssertionConcern.AssertNotEmpty(user.Password, "A senha é obrigatória."),
                    AssertionConcern.AssertLength(user.Password, 0, 256, "Tamanho da senha inválida.")
                );
        }

        public static bool AuthenticateUserScopeIsValid(this User user, string email, string encryptedPassword)
        {
            return AssertionConcern.IsSatisfiedBy
                (
                    AssertionConcern.AssertNotEmpty(email, "O e-mail é obrigatório."),
                    AssertionConcern.AssertLength(email, 0, 256, "Tamanho do e-mail inválido."),
                    AssertionConcern.AssertNotEmpty(encryptedPassword, "A senha é obrigatória."),
                    AssertionConcern.AssertLength(encryptedPassword, 0, 256, "Tamanho da senha inválida."),
                    AssertionConcern.AssertAreEquals(user.Email, email, "Usuário ou senha inválidos."),
                    AssertionConcern.AssertAreEquals(user.Password, encryptedPassword, "Usuário ou senha inválidos.")
                );
        }
    }
}