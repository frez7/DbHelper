using DbHelper.DAL.Entities.DbHelper;
using DbHelper.DAL.Entities.Identity;

namespace DbHelper.DAL.Entities.Requests.ProjectRequests
{
    public class CreateProjectRequest
    {
        public string Name { get; set; }
        public string CustomerName { get; set; }
        public string ExecutorName { get; set; }
        public int Priority { get; set; }

    }
}
