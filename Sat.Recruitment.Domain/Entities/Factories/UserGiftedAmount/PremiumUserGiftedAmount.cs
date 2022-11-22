namespace Sat.Recruitment.Domain.Entities.Factories.UserGiftedAmount;

public class PremiumUserGiftedAmount : UserGiftedAmount
{
    public PremiumUserGiftedAmount(decimal originalAmount)
        : base(originalAmount) { }

    public override decimal GetGiftedAmount()
    {
        if (_originalAmount > 100)
        {
            var percentage = Convert.ToDecimal(2);
            return _originalAmount * percentage;
        }

        return 0;
    }
}