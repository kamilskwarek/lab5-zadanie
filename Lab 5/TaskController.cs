using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using static Lab_5.TaskMenager;

namespace Lab_5.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TaskController : ControllerBase
    {
        private readonly TaskManager _taskManager;

        public TaskController(TaskManager taskManager)
        {
            _taskManager = taskManager;
        }

        [HttpGet]
        public ActionResult<List<Task>> GetAllTasks()
        {
            List<Task> tasks = _taskManager.GetTasks();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public ActionResult<Task> GetTaskById(int id)
        {
            Task task = _taskManager.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPost]
        public ActionResult<Task> CreateTask(Task task)
        {
            _taskManager.AddTask(task);
            return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateTask(int id, Task updatedTask)
        {
            bool success = _taskManager.UpdateTask(id, updatedTask);
            if (success)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpPatch("{id}/complete")]
        public ActionResult MarkTaskAsCompleted(int id)
        {
            bool success = _taskManager.MarkTaskAsCompleted(id);
            if (success)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTask(int id)
        {
            bool success = _taskManager.DeleteTask(id);
            if (success)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
