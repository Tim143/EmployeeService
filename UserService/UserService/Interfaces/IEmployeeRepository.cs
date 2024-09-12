using UserService.Models.DTOModels;

namespace UserService.Interfaces
{
    public interface IEmployeeRepository
    {
        Task DeleteAsync(long id, CancellationToken cancellationToken = default);
        Task<List<EmployeeDTO>> GetAsync(CancellationToken cancellationToken = default);
        Task<EmployeeDTO> GetByIdAsync(long id, CancellationToken cancellationToken = default);
        Task AddAsync(EmployeeDTO employeeDTO, CancellationToken cancellationToken = default);
        Task UpdateAsync(EmployeeDTO employeeDTO, CancellationToken cancellationToken = default);
    }
}