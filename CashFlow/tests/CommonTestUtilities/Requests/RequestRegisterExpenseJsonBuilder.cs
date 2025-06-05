using Bogus;
using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;

namespace CommonTestUtilities.Requests;
public class RequestRegisterExpenseJsonBuilder
{
    public RequestRegisterExpenseJson Build()
    {
        return new Faker<RequestRegisterExpenseJson>()
                .RuleFor(x => x.Title, faker => faker.Commerce.ProductName())
                .RuleFor(x => x.Description, faker => faker.Commerce.ProductDescription())
                .RuleFor(x => x.Date, faker => faker.Date.Past())
                .RuleFor(x => x.PaymentType, faker => faker.PickRandom<PaymentsType>())
                .RuleFor(x => x.Amount, faker => faker.Random.Decimal(min: 1, max: 1000));
    }
}
