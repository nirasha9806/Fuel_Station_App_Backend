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
            var Queue = queueService.Get(id);

            if(Queue == null){
                return NotFound($"Queue with Id = {id} not found");
            }

            return Queue;
        }

        [HttpPost]
        public ActionResult<Queue> Post([FromBody] Queue Queue)
        {
             queueService.Create(Queue);

             return CreatedAtAction(nameof(Get), new {id = Queue.id}, Queue);
        }

        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Queue Queue)
        {
             var existingQueue = queueService.Get(id);

             if(existingQueue == null){
                return NotFound($"Queue with Id = {id} not found");
             }

             queueService.Update(id,Queue);

             return NoContent();
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