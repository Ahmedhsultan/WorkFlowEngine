using Database.Models;

namespace WorkFlowEngine.Models.Interfaces
{
    public interface ITokenServices
    {
        string GetToken(User user);
    }
}
