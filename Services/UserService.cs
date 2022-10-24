using backend.Models;
using MongoDB.Driver;

namespace backend.Services
{
    public class UserService : IUserService
    {
        private readonly IMongoCollection<User> _users;

        public UserService(IUserStoreDatabseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _users = database.GetCollection<User>(settings.UsersCollectionName);
        }
        public User Create(User user)
        {
            _users.InsertOne(user);
            return user;
        }

        public List<User> Get()
        {
           return _users.Find(user => true).ToList();
        }

        public User Get(string id)
        {
            return _users.Find(user => user.id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
           _users.DeleteOne(user => user.id == id);
        }

        public void Update(string id, User user)
        {
            _users.ReplaceOne(user => user.id == id, user);
        }
    }
}