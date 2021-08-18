namespace EventReminder.BLL.Abstractions
{
    public interface IAuthenticationService
    {
        void CreateUserIfNotExist(string email);

        string CreateToken(string email);
    }
}
