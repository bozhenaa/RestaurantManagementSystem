using RestaurantManagementSystem.Data.Entities;

namespace RestaurantManagementSystem.Repositories.IRepositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeById(int id);
        Task AddEmployee(Employee employee);
        Task UpdateEmployee (Employee employee);
        Task DeleteEmployeeById(Employee employee);
    }
}
