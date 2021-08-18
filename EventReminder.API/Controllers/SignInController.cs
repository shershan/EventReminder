using EventReminder.API.Models;
using EventReminder.BLL.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace EventReminder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SignInController : BaseController
    {
        public SignInController(IServiceProvider provider) : base(provider) 
        {
        }

        [HttpGet("isAuthenticated")]
        public IActionResult IsAuthenticated()
        {
            return this.Ok(true);
        }

        [HttpPost("google")]
        [AllowAnonymous]
        public IActionResult GoogleSignIn([FromBody] TokenIdModel model)
        {
            if (model != null && !string.IsNullOrEmpty(model.TokenId))
            {
                var googleAuthService = _provider.GetService<IGoogleAuthenticationService>();
                var googleAuthResult = googleAuthService.ValidateGoogleToken(model.TokenId);
                if (googleAuthResult != null)
                {
                    var authenticationService = _provider.GetService<IAuthenticationService>();
                    authenticationService.CreateUserIfNotExist(googleAuthResult);
                    var token = authenticationService.CreateToken(googleAuthResult);

                    return this.Ok(token);
                }
            }
            return this.BadRequest();
        }
    }
}
