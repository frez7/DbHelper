using DbHelper.DAL.Common;
using DbHelper.DAL.Entities.Enums;
using DbHelper.DAL.Entities.Identity;

namespace DbHelper.DAL.Entities.DbHelper
{
    public class ProjectTask : BaseEntity<int>
    {
        public string Name { get; set; }
        public Project Project { get; set; }
        public int ProjectId { get; set; }
        public Employee Owner { get; set; }
        public int OwnerId { get; set; }
        public Employee Executor { get; set; }
        public int ExecutorId { get; set; }
        public string Comment { get; set; }
        public TaskEnum Status { get; set; }
        public int Priority { get; set; }
    }
}
