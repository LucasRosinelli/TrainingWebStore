using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using TrainingWebStore.Domain.ApplicationServices;
using TrainingWebStore.SharedKernel;

namespace TrainingWebStore.Api.Security
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private IUserApplicationService _service;

        public SimpleAuthorizationServerProvider(IUserApplicationService service)
        {
            this._service = service;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            var user = this._service.Authenticate(context.UserName, context.Password);
            if (user == null)
            {
                context.SetError("invalid_grant", "Usuário ou senha inválidos.");
                return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Name, user.Email));
            identity.AddClaim(new Claim(ClaimTypes.Role, user.IsAdmin ? Constants.RoleAdmin : string.Empty));

            GenericPrincipal principal = new GenericPrincipal(identity, new string[] { user.IsAdmin ? Constants.RoleAdmin : string.Empty });
            Thread.CurrentPrincipal = principal;

            context.Validated(identity);
        }
    }
}