using System.ComponentModel.DataAnnotations;

namespace TaskManagementAPI.Models
{
    public enum TaskStatus
    {
        Pending,
        InProgress,
        Completed
    }

    public class Task
    {
        [Key]
        public int TaskId { get; set; }

        [Required]
        public string? Title { get; set; }

        public string? Description { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public TaskStatus Status { get; set; }
    }
}
