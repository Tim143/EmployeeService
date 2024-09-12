using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Interfaces;
using UserService.Models.DTOModels;
using UserService.Models.ResponseModels;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IEmployeeService employeeService;
        private readonly IMapper mapper;

        public UserController(IEmployeeService employeeService, IMapper mapper)
        {
            this.employeeService = employeeService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ICollection<EmployeeResponseModel>> GetAsync(CancellationToken cancellationToken = default)
        {
            List<EmployeeDTO> employees =  await employeeService.GetAsync(cancellationToken);

            return employees.Select(x => mapper.Map<EmployeeResponseModel>(x)).ToList();
        }

        [HttpGet("/{id}")]
        public async Task<EmployeeResponseModel> GetByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            EmployeeDTO employee = await employeeService.GetAsync(id, cancellationToken);

            return mapper.Map<EmployeeResponseModel>(employee);
        }

        [HttpPost]
        public async Task CreateAsync([FromBody] EmployeeDTO requestModel, CancellationToken cancellationToken = default)
        {
            await employeeService.AddAsync(requestModel, cancellationToken);
        }

        [HttpDelete]
        public async Task DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            await employeeService.DeleteAsync(id, cancellationToken);
        }

        [HttpPut]
        public async Task UpdateAsync([FromBody] EmployeeDTO requestModel, CancellationToken cancellationToken = default)
        {
            await employeeService.UpdateAsync(requestModel, cancellationToken);
        }
    }
}
