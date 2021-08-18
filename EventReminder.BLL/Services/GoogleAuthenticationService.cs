using EventReminder.BLL.Abstractions;
using Google.Apis.Auth;

namespace EventReminder.BLL.Services
{
    internal class GoogleAuthenticationService : IGoogleAuthenticationService
    {
        public string ValidateGoogleToken(string googleToken)
        {
            try
            {
                return GoogleJsonWebSignature.ValidateAsync(googleToken, new GoogleJsonWebSignature.ValidationSettings()).Result.Email;
            }
            catch
            {
                return null;
            }
        }
    }
}
