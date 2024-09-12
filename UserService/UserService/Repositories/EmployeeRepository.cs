using AutoMapper;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using UserService.Interfaces;
using UserService.Models.DTOModels;
using AppContext = DataAccess.DatabaseContext.AppContext;

namespace UserService.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppContext dbContext;
        private readonly IMapper mapper;

        public EmployeeRepository(AppContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var employee = await dbContext.Employees.Where(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);

            if(employee != null)
            {
                dbContext.Employees.Remove(employee);
                await dbContext.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<List<EmployeeDTO>> GetAsync(CancellationToken cancellationToken = default)
        {
            var employees = await dbContext.Employees.ToListAsync(cancellationToken);

            if (employees != null)
            {
                return employees.Select(x => mapper.Map<EmployeeDTO>(x)).ToList();
            }

            return [];
        }

        public async Task<EmployeeDTO> GetByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            var employee = await dbContext.Employees.Where(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);

            if (employee != null)
            {
                return mapper.Map<EmployeeDTO>(employee);
            }

            return new EmployeeDTO();
        }

        public async Task AddAsync(EmployeeDTO employeeDTO, CancellationToken cancellationToken = default)
        {
            EmployeeEntity employee = new EmployeeEntity()
            {
                FirstName = employeeDTO.FirstName,
                LastName = employeeDTO.LastName,
                Age = employeeDTO.Age,
                Gender = employeeDTO.Gender
            };

            await dbContext.AddAsync(employee, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(EmployeeDTO employeeDTO, CancellationToken cancellationToken = default)
        {
            var employee = await dbContext.Employees.AsNoTracking().Where(x => x.Id == employeeDTO.Id).FirstOrDefaultAsync(cancellationToken);

            if (employee != null)
            {
                employee = mapper.Map<EmployeeEntity>(employeeDTO);

                dbContext.Employees.Update(employee);

                await dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
