namespace Sat.Recruitment.Infrastructure.Dtos;

#nullable disable
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

    public UserDto() { }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string UserType { get; set; }
    public decimal OriginalMoney { get; set; }
    public decimal GiftedAmount { get; set; }
}