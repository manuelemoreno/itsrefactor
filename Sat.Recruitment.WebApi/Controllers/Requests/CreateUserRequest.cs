﻿using Sat.Recruitment.Domain.Enums;

namespace Sat.Recruitment.WebApi.Controllers.Requests;

public class CreateUserRequest
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public UserTypeEnum UserType { get; set; }
    public decimal Money { get; set; }
}