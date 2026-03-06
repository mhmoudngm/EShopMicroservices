using FluentValidation;

namespace Basket.API.Basket.StoreBasket
{
    public class StoreBasketValidator : AbstractValidator<StoreBasketCommand>
    {
        public StoreBasketValidator()
        {
            RuleFor(i => i.card).NotNull().WithMessage("Cart can not be null");
            RuleFor(i => i.card.UserName).NotNull().NotEmpty().WithMessage("Username is required");
        }
    }
}
