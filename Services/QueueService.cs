using backend.Models;
using MongoDB.Driver;

namespace backend.Services
{
    public class QueueService : IQueueService
    {
        private readonly IMongoCollection<Queue> _queues;

        public QueueService(IStoreDatabseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _queues = database.GetCollection<Queue>(settings.QueuesCollectionName);
        }
        public Queue Create(Queue queue)
        {
            _queues.InsertOne(queue);
            return queue;
        }

        public List<Queue> Get()
        {
           return _queues.Find(queue => true).ToList();
        }

        public Queue Get(string id)
        {
            return _queues.Find(queue => queue.id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
           _queues.DeleteOne(queue => queue.id == id);
        }

        public void Update(string id, Queue queue)
        {
            _queues.ReplaceOne(_queues => _queues.id == id, queue);
        }
    }
}