using backend.Models;

namespace backend.Services
{
    public interface IQueueService
    {
        List<Queue> Get();
        Queue Get(string id);
        Queue Create(Queue queue);
        void Update(string id, Queue queue);
        void Remove(string id);
    }
}