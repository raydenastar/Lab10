namespace YourProject.Domain.Services;
using YourProject.Domain.Entities;

public class Authenticator : IAuthenticator
{
    public bool Authenticate(User user)
    {
        return user.Username == "admin" && user.Password == "admin";
    }
}