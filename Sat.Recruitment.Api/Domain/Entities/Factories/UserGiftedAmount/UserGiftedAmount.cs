namespace Sat.Recruitment.Api.Domain.Entities.Factories.UserGiftedAmount;

public abstract class UserGiftedAmount
{
    protected readonly decimal _originalAmount;

    protected UserGiftedAmount(decimal originalAmount)
    {
        _originalAmount = originalAmount;
    }

    public abstract decimal GetGiftedAmount();
}