using DbHelper.BL.OtherServices;
using DbHelper.DAL.Common;
using DbHelper.DAL.Common.ProjectResponses;
using DbHelper.DAL.Data;
using DbHelper.DAL.Entities.DTOs;
using DbHelper.DAL.Entities.Identity;
using DbHelper.DAL.Entities.Requests.ProjectRequests;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace DbHelper.BL.ProjectBL
{
    public class EmployeeManager
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<IdentityUserRole<int>> _identityUserRoleRepository;
        private readonly UserManager<Employee> _userManager;
        private readonly GetUserService _getUserService;

        public EmployeeManager(IRepository<Employee> employeeRepository, 
            IRepository<IdentityUserRole<int>> identityUserRoleRepository, 
            UserManager<Employee> userManager, GetUserService getUserService)
        {
            _employeeRepository = employeeRepository;
            _identityUserRoleRepository = identityUserRoleRepository;
            _userManager = userManager;
            _getUserService = getUserService;
        }
        public async Task<EmployeeResponse> Create(CreateEmployeeRequest request)
        {
            var hasher = new PasswordHasher<Employee>();
            var employee = new Employee
            {
                UserName = request.Email,
                NormalizedUserName = request.Email.ToUpper(),
                Email = request.Email,
                NormalizedEmail = request.Email.ToUpper(),
                PasswordHash = hasher.HashPassword(null, request.Password),
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                FatherName = request.FatherName

            };
            await _employeeRepository.AddAsync(employee);
            var userRole = new IdentityUserRole<int>
            {
                UserId = employee.Id,
                RoleId = 1
            };
            await _identityUserRoleRepository.AddAsync(userRole);
            return new EmployeeResponse(200, true, "Вы успешно создали новый профиль для сотрудника!", employee.Id, request.Email, request.Password);
        }
        public async Task<EmployeeDTOResponse> GetCurrentEmployee()
        {
            var userId = await _getUserService.GetCurrentUserId();
            var response = await GetById(userId);
            return response;
        }
        public async Task<EmployeeDTOResponse> GetById(int employeeId)
        {
            var employee = await _employeeRepository.GetByIdAsync(employeeId);
            if (employee == null)
            {
                throw new Exception("Аккаунт с таким айди не найден!");
            }
            var roles = await _userManager.GetRolesAsync(employee);
            var employeeDTO = new EmployeeDTO
            {
                Email = employee.Email,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                FatherName = employee.FatherName,
                Id = employee.Id,
                Roles = roles.ToList()
            };
            return new EmployeeDTOResponse(200, true, null, employeeDTO);
        }
        public async Task<EmployeeDTOsResponse> GetAllEmployees()
        {
            List<Employee> employees = (List<Employee>)await _employeeRepository.GetAllAsync();
            var employeeDTOs = new List<EmployeeDTO>();
            for (int i = 0; i < employees.Count; i++)
            {
                var roles = await _userManager.GetRolesAsync(employees[i]);
                var employeeDTO = new EmployeeDTO
                {
                    Email = employees[i].Email,
                    FirstName = employees[i].FirstName,
                    LastName = employees[i].LastName,
                    FatherName = employees[i].FatherName,
                    Id = employees[i].Id,
                    Roles = roles.ToList()
                };
                employeeDTOs.Add(employeeDTO);
            }
            return new EmployeeDTOsResponse(200, true, null, employeeDTOs);
        }
        public async Task<EmployeeDTOsResponse> GetAllManagers()
        {
            var response = await GetAllEmployees();
            List<EmployeeDTO> employees = response.EmployeeDTOs.Where(e => e.Roles.Contains("Manager")).ToList();
            return new EmployeeDTOsResponse(200, true, null, employees);
        }
        public async Task<Response> Update(UpdateEmployeeRequest request)
        {
            var hasher = new PasswordHasher<Employee>();
            var user = await _employeeRepository.GetByIdAsync(request.Id);
            if (user == null)
            {
                throw new Exception("Аккаунт с таким айди не найден!");
            }
            var roles = await _userManager.GetRolesAsync(user);
            if (roles.Contains("Admin"))
            {
                throw new Exception("Вы не можете редактировать аккаунт администратора!");
            }
            user.Email = request.Email;
            user.PasswordHash = hasher.HashPassword(user, request.Password);
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.FatherName = request.FatherName;
            await _employeeRepository.UpdateAsync(user);
            return new Response(200, true, "Вы успешно обновили профиль данного пользователя!");
        }
        public async Task<Response> UpdateToEmployeeRole(int employeeId)
        {
            var user = await _employeeRepository.GetByIdAsync(employeeId);
            if (user == null)
            {
                throw new Exception("Аккаунт с таким айди не найден!");
            }
            var roles = await _userManager.GetRolesAsync(user);
            if (roles.Contains("Employee"))
            {
                throw new Exception("Данный пользователь уже является сотрудником!");
            }
            else if (roles.Contains("Admin"))
            {
                throw new Exception("Вы не можете поменять роль у администратора!");
            }
            await _userManager.RemoveFromRolesAsync(user, roles);
            await _userManager.AddToRoleAsync(user, "Employee");
            return new Response(200, true, "Вы успешно установили на аккаунт роль сотрудника");
        }
        public async Task<Response> UpdateToManagerRole(int employeeId)
        {
            var user = await _employeeRepository.GetByIdAsync(employeeId);
            if (user == null)
            {
                throw new Exception("Аккаунт с таким айди не найден!");
            }
            var roles = await _userManager.GetRolesAsync(user);
            if (roles.Contains("Manager"))
            {
                throw new Exception("Данный пользователь уже является менеджером!");
            }
            else if (roles.Contains("Admin"))
            {
                throw new Exception("Вы не можете поменять роль у администратора!");
            }
            await _userManager.RemoveFromRolesAsync(user, roles);
            await _userManager.AddToRoleAsync(user, "Manager");
            return new Response(200, true, "Вы успешно установили на аккаунт роль менеджера!");
        }
        public async Task<Response> UpdateToAdminRole(int employeeId)
        {
            var user = await _employeeRepository.GetByIdAsync(employeeId);
            if (user == null)
            {
                throw new Exception("Аккаунт с таким айди не найден!");
            }
            var roles = await _userManager.GetRolesAsync(user);
            if (roles.Contains("Admin"))
            {
                throw new Exception("Данный пользователь уже является админом!");
            }
            await _userManager.RemoveFromRolesAsync(user, roles);
            await _userManager.AddToRoleAsync(user, "Admin");
            return new Response(200, true, "Вы успешно установили на аккаунт роль администратора!");
        }
        public async Task<Response> Delete(int employeeId)
        {
            var user = await _employeeRepository.GetByIdAsync(employeeId);
            
            if (user == null)
            {
                throw new Exception("Аккаунт с таким айди не найден!");
            }
            var roles = await _userManager.GetRolesAsync(user);
            if (roles.Contains("Admin"))
            {
                throw new Exception("Вы не можете удалить аккаунт администратора!");
            }
            await _userManager.DeleteAsync(user);
            return new Response(200, true, "Аккаунт успешно удален!");
        }
        
    }
}
