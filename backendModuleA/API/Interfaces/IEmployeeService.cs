using backendModuleA.Domain.Entities;

namespace backendModuleA.API.Interfaces;

public interface IEmployeeService
{
    Task<List<Employee>> GetAllAsync();
    Task<Employee?> GetByIdAsync(int id);
    Task<Employee> CreateAsync(Employee employee);
    Task<Employee?> UpdateAsync(Employee employee);
    Task<bool> DeleteAsync(int id);
}