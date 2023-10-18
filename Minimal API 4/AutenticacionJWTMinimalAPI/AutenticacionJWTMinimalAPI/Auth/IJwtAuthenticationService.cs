namespace AutenticacionJWTMinimalAPI.Auth
{
    public interface IJwtAuthenticationService
    {
        string Authenticate(string userName);
    }
}
