using TaskManagementAPI.DTOs;
using TaskManagementAPI.Models;
using Task = TaskManagementAPI.Models.Task;

namespace TaskManagementAPI.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<Task>> GetAllTasks();
        Task<Task> AddTask(TaskDto taskDto);
        Task<Task> UpdateTask(int id, TaskDto taskDto);
        Task<bool> DeleteTask(int id);
    }
}
