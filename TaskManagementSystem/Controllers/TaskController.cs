using Microsoft.AspNetCore.Mvc;
using TaskManagementAPI.DTOs;
using TaskManagementAPI.Services;

namespace TaskManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks() => Ok(await _taskService.GetAllTasks());

        [HttpPost]
        public async Task<IActionResult> AddTask([FromBody] TaskDto taskDto)
        {
            var task = await _taskService.AddTask(taskDto);
            return CreatedAtAction(nameof(GetAllTasks), new { id = task.TaskId }, task);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] TaskDto taskDto)
        {
            var task = await _taskService.UpdateTask(id, taskDto);
            if (task == null) return NotFound();
            return Ok(task);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var deleted = await _taskService.DeleteTask(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
