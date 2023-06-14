using DbHelper.DAL.Entities.DbHelper;
using DbHelper.DAL.Entities.Enums;
using DbHelper.DAL.Entities.Identity;

namespace DbHelper.DAL.Entities.Requests.ProjectRequests
{
    public class CreateTaskRequest
    {
        public string Name { get; set; }
        public int ProjectId { get; set; }
        public int ExecutorId { get; set; }
        public string Comment { get; set; }
        public int Status { get; set; }
        public int Priority { get; set; }
    }
}
