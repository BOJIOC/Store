using backendModuleA.API.Interfaces;
using backendModuleA.Domain.Entities;
using backendModuleA.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace backendModuleA.Infrastructure.Services;

public class EmployeeService : IEmployeeService
{
    private readonly AppDbContext _db;
    public EmployeeService(AppDbContext db) => _db = db;

    public async Task<List<Employee>> GetAllAsync() =>
        await _db.Employees.Include(e => e.Store).ToListAsync();

    public async Task<Employee?> GetByIdAsync(int id) =>
        await _db.Employees.Include(e => e.Store).FirstOrDefaultAsync(e => e.Id == id);

    public async Task<Employee> CreateAsync(Employee employee)
    {
        _db.Employees.Add(employee);
        await _db.SaveChangesAsync();
        return employee;
    }

    public async Task<Employee?> UpdateAsync(Employee employee)
    {
        var existing = await _db.Employees.FindAsync(employee.Id);
        if (existing == null) return null;

        existing.FullName = employee.FullName;
        existing.Position = employee.Position;
        existing.StoreId = employee.StoreId;
        await _db.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var employee = await _db.Employees.FindAsync(id);
        if (employee == null) return false;
        _db.Employees.Remove(employee);
        await _db.SaveChangesAsync();
        return true;
    }
}