using DbHelper.DAL.Entities.Enums;

namespace DbHelper.DAL.Entities.DTOs
{
    public class TaskDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProjectId { get; set; }
        public int OwnerId { get; set; }
        public int ExecutorId { get; set; }
        public string Comment { get; set; }
        public TaskEnum Status { get; set; }
        public int Priority { get; set; }
    }
}
