using TaskManagementAPI.Models;
using Task = TaskManagementAPI.Models.Task;

namespace TaskManagementAPI.Repositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<Task>> GetAllTasks();
        Task<Task> GetTaskById(int id);
        Task<Task> AddTask(Task task);
        Task<Task> UpdateTask(Task task);
        Task<bool> DeleteTask(int id);
    }
}
