namespace Sat.Recruitment.Application.Repositories.Dtos;

public class UserDto
{
    public UserDto(string name,
                   string email,
                   string phone,
                   string address,
                   string userType,
                   decimal originalMoney,
                   decimal giftedAmount)
    {
        Name = name;
        Email = email;
        Address = address;
        Phone = phone;
        UserType = userType;
        OriginalMoney = originalMoney;
        GiftedAmount = giftedAmount;
    }

    public string Name { get; }
    public string Email { get; }
    public string Address { get; }
    public string Phone { get; }
    public string UserType { get; }
    public decimal OriginalMoney { get; }
    public decimal GiftedAmount { get; }
}