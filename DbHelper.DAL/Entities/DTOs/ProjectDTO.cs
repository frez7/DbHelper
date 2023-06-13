using DbHelper.DAL.Entities.DbHelper;
using DbHelper.DAL.Entities.Identity;

namespace DbHelper.DAL.Entities.DTOs
{
    public class ProjectDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CustomerName { get; set; }
        public string ExecutorName { get; set; }
        public int OwnerId { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public int Priority { get; set; }

    }
}
