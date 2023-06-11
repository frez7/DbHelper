using DbHelper.DAL.Common;
using DbHelper.DAL.Entities.Identity;

namespace DbHelper.DAL.Entities.DbHelper
{
    public class ProjectEmployee
    {
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
