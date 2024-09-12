using UserService.Interfaces;
using UserService.Models.DTOModels;

namespace UserService.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public async Task<EmployeeDTO> GetAsync(long id, CancellationToken cancellationToken = default)
        {
            return await employeeRepository.GetByIdAsync(id, cancellationToken);
        }

        public async Task<List<EmployeeDTO>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await employeeRepository.GetAsync(cancellationToken);
        }

        public async Task DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            await employeeRepository.DeleteAsync(id, cancellationToken);
        }

        public async Task AddAsync(EmployeeDTO employee, CancellationToken cancellationToken = default)
        {
            await employeeRepository.AddAsync(employee, cancellationToken);
        }

        public async Task UpdateAsync(EmployeeDTO employee, CancellationToken cancellationToken = default)
        {
            await employeeRepository.UpdateAsync(employee, cancellationToken);
        }
    }
}
