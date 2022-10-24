using backend.Models;

namespace backend.Services
{
    public interface IUserService
    {
        List<User> Get();
        User Get(String id);
        User Create(User user);
        void Update(string id, User user);
        void Remove(string id);
    }
}