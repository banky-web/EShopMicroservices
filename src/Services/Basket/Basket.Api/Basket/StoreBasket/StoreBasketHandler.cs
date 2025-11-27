

using Discount.Grpc;

namespace Basket.Api.Basket.StoreBasket
{
    public record StoreBasketCommand(ShoppingCart Cart) : ICommand<StoreBasketResult>;
    public record StoreBasketResult(string UserName);

    public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
    {
        public StoreBasketCommandValidator()
        {
            RuleFor(x => x.Cart).NotNull().WithMessage("Shopping cart cannot be null.");
            RuleFor(x => x.Cart.UserName).NotEmpty().WithMessage("Shopping cart userName is required");
        }
    }

    public class StoreBasketCommandHandler (IBasketRepository basketRepo, DiscountProtoService.DiscountProtoServiceClient discountProto)
        : ICommandHandler<StoreBasketCommand, StoreBasketResult>
    {
        public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
        {

            await DeductDiscounts(command.Cart, cancellationToken);
            await basketRepo.StoreBasket(command.Cart, cancellationToken);

            return new StoreBasketResult(command.Cart.UserName);
        }

        private async Task DeductDiscounts(ShoppingCart cart, CancellationToken cancellationToken)
        {
            foreach (var item in cart.Items)
            {
                var discountRequest = new GetDiscountRequest { ProductName = item.ProductName };
                var coupon = await discountProto.GetDiscountAsync(discountRequest, cancellationToken: cancellationToken);
                item.Price -= coupon.Amount;
            }
            
        }
    }
}
