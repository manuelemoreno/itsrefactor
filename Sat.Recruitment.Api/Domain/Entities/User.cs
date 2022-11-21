using Sat.Recruitment.Api.Domain.Entities.Factories.UserGiftedAmount;
using Sat.Recruitment.Api.Domain.Enums;

namespace Sat.Recruitment.Api.Domain.Entities;

public class User
{
    private User(string name,
                 Email email,
                 string address,
                 string phone,
                 UserTypeEnum userType,
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
    public Email Email { get; }
    public string Address { get; }
    public string Phone { get; }
    public UserTypeEnum UserType { get; }
    public decimal OriginalMoney { get; }
    public decimal GiftedAmount { get; }

    public static User Create(string name,
                              string email,
                              string address,
                              string phone,
                              UserTypeEnum userType,
                              decimal originalMoney)
        => new(name, Email.Create(email), address, phone, userType, originalMoney,
            UserGiftedAmountFactory.Create(userType, originalMoney).GetGiftedAmount());
}