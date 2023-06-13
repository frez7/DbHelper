using DbHelper.DAL.Entities.DbHelper;
using DbHelper.WebApi.AuthBL.Data;

namespace DbHelper.DAL.Data
{
    public class ProjectEmployeeRepository : Repository<ProjectEmployee>
    {
        private readonly AppDbContext _context;
        public ProjectEmployeeRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public ProjectEmployee GetProjectEmployee(int projectId, int employeeId)
        {
            var projectEmployee = _context.ProjectEmployees
                .FirstOrDefault(pe => pe.ProjectId == projectId && pe.EmployeeId == employeeId);
            if (projectEmployee == null)
            {
                throw new Exception("Сущность с такими полями не найдена!");
            }
            return projectEmployee;
        }
        public async Task DeleteProjectEmployee(int projectId, int employeeId)
        {
            var projectEmployee = GetProjectEmployee(projectId, employeeId);
            _context.Remove(projectEmployee);
            await _context.SaveChangesAsync();
        }
    }
}
