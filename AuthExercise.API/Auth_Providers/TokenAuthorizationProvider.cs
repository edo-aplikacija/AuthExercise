using AuthExercise.BL.user.interfaces;
using AuthExercise.BL.user.repositories;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace AuthExercise.API.Auth_Providers
{
    public class TokenAuthorizationProvider : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // Resource owner userId credentials does not provide a client ID.
            if (context.ClientId == null)
            {
                context.Validated();
            }

            return Task.FromResult<object>(null);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            IAuthUser _repo = new AuthUserRepository();
            ITokenUserModel user = _repo.GetUserByEmailPassword(context.UserName, context.Password);

            if (user == null)
            {
                context.SetError("message", "Oops! Credentials are not valid!");
                return Task.FromResult<object>(null);
            }
            else if (user.Active == false || user.IsValidate == false)
            {
                context.SetError("message", "Oops! You must validate your account!");
                return Task.FromResult<object>(null);
            }
            else
            {
                // If the credentials are valid we'll create 'ClaimsIdentity' 
                // class and pass the authentication type to it, 
                // token will contain user id
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                identity.AddClaim(new Claim(ClaimTypes.Name, user.Name));
                identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
                identity.AddClaim(new Claim(ClaimTypes.Sid, user.ID.ToString()));

                // Now generating the token happens behind the scenes when we call 'context.Validated(identity)'.
                context.Validated(identity);

                return Task.FromResult<object>(null);
            }           
        }
    }
}