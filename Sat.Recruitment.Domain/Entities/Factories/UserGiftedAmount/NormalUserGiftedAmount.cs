namespace Sat.Recruitment.Domain.Entities.Factories.UserGiftedAmount;

public class NormalUserGiftedAmount : UserGiftedAmount
{
    public NormalUserGiftedAmount(decimal originalAmount)
        : base(originalAmount) { }

    public override decimal GetGiftedAmount()
    {
        if (_originalAmount > 10 && _originalAmount < 100)
        {
            var percentage = Convert.ToDecimal(0.8);
            return _originalAmount * percentage;
        }

        if (_originalAmount > 100)
        {
            var percentage = Convert.ToDecimal(0.12);
            return _originalAmount * percentage;
        }

        return 0;
    }
}