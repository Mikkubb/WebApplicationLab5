using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationLab5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly TaskManager _taskManager;

        public TaskController()
        {
            _taskManager = new TaskManager();
        }

        // GET: api/Task
        [HttpGet]
        public ActionResult<List<Task>> GetAllTasks()
        {
            return _taskManager.GetTasks();
        }

        // GET: api/Task/5
        [HttpGet("{id}")]
        public ActionResult<Task> GetTaskById(int id)
        {
            var task = _taskManager.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }
            return task;
        }

        // POST: api/Task
        [HttpPost]
        public ActionResult<Task> CreateTask(Task task)
        {
            _taskManager.AddTask(task);
            return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, task);
        }

        // PUT: api/Task/5
        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, Task task)
        {
            if (id != task.Id)
            {
                return BadRequest();
            }

            var updated = _taskManager.UpdateTask(id, task);

            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Task/5
        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var deleted = _taskManager.DeleteTask(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
