﻿using DataAccess.Models.Enums;

namespace UserService.Models.ResponseModels
{
    public class EmployeeResponseModel
    {
        public long Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }
        public string? Gender { get; set; }
    }
}
