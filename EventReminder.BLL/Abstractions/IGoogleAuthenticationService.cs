namespace EventReminder.BLL.Abstractions
{
    public interface IGoogleAuthenticationService
    {
        string ValidateGoogleToken(string googleToken);
    }
}
