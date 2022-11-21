using System;

namespace Sat.Recruitment.Api.Domain.Entities.Factories.UserGiftedAmount;

public class SuperUserGiftedAmount : UserGiftedAmount
{
    public SuperUserGiftedAmount(decimal originalAmount)
        : base(originalAmount) { }

    public override decimal GetGiftedAmount()
    {
        if (_originalAmount > 100)
        {
            var percentage = Convert.ToDecimal(0.2);
            return _originalAmount * percentage;
        }

        return 0;
    }
}