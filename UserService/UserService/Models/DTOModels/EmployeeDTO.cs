using DataAccess.Models.Enums;

namespace UserService.Models.DTOModels
{
    public class EmployeeDTO
    {
        public long Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
    }
}
