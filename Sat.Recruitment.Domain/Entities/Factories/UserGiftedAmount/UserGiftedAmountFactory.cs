using Sat.Recruitment.Domain.Enums;

namespace Sat.Recruitment.Domain.Entities.Factories.UserGiftedAmount;

public class UserGiftedAmountFactory
{
    public static UserGiftedAmount Create(UserTypeEnum userType,
                                          decimal originalAmount)
    {
        //TODO: This could be changed for using Reflection 
        switch (userType)
        {
            case UserTypeEnum.Normal:
                return new NormalUserGiftedAmount(originalAmount);

            case UserTypeEnum.SuperUser:

                return new SuperUserGiftedAmount(originalAmount);

            case UserTypeEnum.Premium:

                return new PremiumUserGiftedAmount(originalAmount);

            default:
                throw new Exception("Unknown User Type");
        }
    }
}