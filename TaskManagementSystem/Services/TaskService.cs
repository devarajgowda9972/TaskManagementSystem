using TaskManagementAPI.DTOs;
using TaskManagementAPI.Models;
using TaskManagementAPI.Repositories;
using Task = TaskManagementAPI.Models.Task;
using TaskStatus = TaskManagementAPI.Models.TaskStatus;

namespace TaskManagementAPI.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<IEnumerable<Task>> GetAllTasks() => await _taskRepository.GetAllTasks();

        public async Task<Task> AddTask(TaskDto taskDto)
        {
            var task = new Task
            {
                Title = taskDto.Title,
                Description = taskDto.Description,
                DueDate = taskDto.DueDate,
                Status = Enum.Parse<TaskStatus>(taskDto.Status!)
            };
            return await _taskRepository.AddTask(task);
        }

        public async Task<Task> UpdateTask(int id, TaskDto taskDto)
        {
            var task = await _taskRepository.GetTaskById(id);
            if (task == null) return null!;

            task.Title = taskDto.Title;
            task.Description = taskDto.Description;
            task.DueDate = taskDto.DueDate;
            task.Status = Enum.Parse<TaskStatus>(taskDto.Status!);

            return await _taskRepository.UpdateTask(task);
        }

        public async Task<bool> DeleteTask(int id) => await _taskRepository.DeleteTask(id);
    }
}
