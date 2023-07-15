using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace lab5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskManager _taskManager;

        public TaskController()
        {
            _taskManager = new TaskManager();
        }

        // POST: api/Task
        [HttpPost]
        public ActionResult<Task> CreateTask(Task task)
        {
            _taskManager.AddTask(task);
            return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, task);
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

        // PUT: api/Task/5
        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, Task task)
        {
            if (id != task.Id)
            {
                return BadRequest();
            }

            var result = _taskManager.UpdateTask(id, task);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Task/5
        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var result = _taskManager.DeleteTask(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
