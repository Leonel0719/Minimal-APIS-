namespace LADCH202309011.Auth
{
    public interface IJwtAuthenticationService
    {
        string Authenticate(string userName);
    }
}
