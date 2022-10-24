using backend.Models;
using MongoDB.Driver;

namespace backend.Services
{
    public class QueueService : IQueueService
    {
        private readonly IMongoCollection<Queue> _queue;

        public QueueService(IStoreDatabseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _queue = database.GetCollection<Queue>(settings.QueuesCollectionName);
        }
        public Queue Create(Queue queue)
        {
            _queue.InsertOne(queue);
            return queue;
        }

        public List<Queue> Get()
        {
           return _queue.Find(Queue => true).ToList();
        }

        public Queue Get(string id)
        {
            return _queue.Find(Queue => Queue.id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
           _queue.DeleteOne(Queue => Queue.id == id);
        }

        public void Update(string id, Queue queue)
        {
            _queue.ReplaceOne(Queue => Queue.id == id, queue);
        }
    }
}