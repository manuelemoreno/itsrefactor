using Sat.Recruitment.Api.Domain.Enums;

namespace Sat.Recruitment.Api.Services.User;

public class UserServiceRequest
{
    public UserServiceRequest(string name,
                              string email,
                              string address,
                              string phone,
                              UserTypeEnum userType,
                              decimal originalMoney)
    {
        Name = name;
        Email = email;
        Address = address;
        Phone = phone;
        UserType = userType;
        OriginalMoney = originalMoney;
    }

    public string Name { get; }
    public string Email { get; }
    public string Address { get; }
    public string Phone { get; }
    public UserTypeEnum UserType { get; }
    public decimal OriginalMoney { get; }
}