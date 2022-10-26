using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueueController : ControllerBase
    {
        private readonly IQueueService queueService;

        public QueueController(IQueueService queueService)
        {
            this.queueService = queueService;
        }

        [HttpGet]
        public ActionResult<List<Queue>> Get()
        {
            return queueService.Get();
        }

        [HttpGet("{id}")]
        public ActionResult<Queue> Get(string id)
        {
            var queue = queueService.Get(id);

            if(queue == null){
                return NotFound($"Queue with Id = {id} not found");
            }

            return queue;
        }

        [HttpPost]
        public ActionResult<Queue> Post([FromBody] Queue queue)
        {
             queueService.Create(queue);

             return CreatedAtAction(nameof(Get), new {id = queue.id}, queue);
        }

        [HttpPut("update-depart-time/{id}")]
        public ActionResult<Queue> Put(string id, [FromBody] Queue queue)
        {
             var existingQueue = queueService.Get(id);

             if(existingQueue == null){
                return NotFound($"Queue with Id = {id} not found");
             }

             queueService.Update(id,queue);

             return queue;
        }

         [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
             var existingQueue = queueService.Get(id);

             if(existingQueue == null){
                return NotFound($"Queue with Id = {id} not found");
             }

             queueService.Remove(id);

             return Ok($"Queue with Id = {id} deleted");
        }
    }
}