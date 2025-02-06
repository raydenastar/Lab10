namespace YourProject.Domain.Services;
using YourProject.Domain.Entities;

public interface IAuthenticator
{
    bool Authenticate(User user);
}