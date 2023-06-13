using DbHelper.DAL.Entities.DbHelper;
using DbHelper.DAL.Entities.DTOs;
using DbHelper.DAL.Entities.Identity;
using DbHelper.WebApi.AuthBL.Data;
using Microsoft.EntityFrameworkCore;

namespace DbHelper.DAL.Data
{
    public class ProjectRepository : Repository<Project>
    {
        private readonly AppDbContext _context;
        public ProjectRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<Project>> GetEmployeeProjects(int employeeId)
        {
            var projects = _context.Employees
                .Where(e => e.Id == employeeId)
                .SelectMany(e => e.ProjectEmployees)
                .Select(pe => pe.Project)
                .ToList();
            return projects;
        }
        public async Task<List<Project>> GetOwningProject(int ownerId)
        {
            var projects = _context.Projects
                .Where(o => o.OwnerId == ownerId).ToList();
            return projects;
        }
        public async Task<List<Employee>> GetProjectEmployees(int projectId)
        {
            var employees = _context.Projects
            .Where(p => p.Id == projectId)
            .SelectMany(p => p.ProjectEmployees)
            .Select(pe => pe.Employee)
            .ToList();
            return employees;
        }
    }
}
