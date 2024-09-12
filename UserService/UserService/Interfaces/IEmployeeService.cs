using UserService.Models.DTOModels;

namespace UserService.Interfaces
{
    public interface IEmployeeService
    {
        Task<EmployeeDTO> GetAsync(long id, CancellationToken cancellationToken = default);
        Task<List<EmployeeDTO>> GetAsync(CancellationToken cancellationToken = default);
        Task DeleteAsync(long id, CancellationToken cancellationToken = default);
        Task AddAsync(EmployeeDTO employee, CancellationToken cancellationToken = default);
        Task UpdateAsync(EmployeeDTO employee, CancellationToken cancellationToken = default);
    }
}
