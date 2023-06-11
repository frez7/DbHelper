using DbHelper.DAL.Common;
using DbHelper.DAL.Entities.Identity;

namespace DbHelper.DAL.Entities.DbHelper
{
    public class Project : BaseEntity<int>
    {
        public string Name { get; set; }
        public string CustomerName { get; set; }
        public string ExecutorName { get; set; }
        public List<ProjectEmployee>? ProjectEmployees { get; set; }
        public Employee Owner { get; set; }
        public int OwnerId { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime? CompletedAt {  get; set; }
        public int Priority { get;set; }

    }
}
