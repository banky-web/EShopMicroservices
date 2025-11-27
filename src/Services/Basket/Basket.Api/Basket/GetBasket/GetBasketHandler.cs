
namespace Basket.Api.Basket.GetBasket
{
    public record GrtBasketQuery(string UserName) : IQuery<GetBasketResult>;
    public record GetBasketResult(ShoppingCart Cart);

    public class GetBasketQueryHandler(IBasketRepository basketRepo)
        : IQueryHandler<GrtBasketQuery, GetBasketResult>
    {
        public async Task<GetBasketResult> Handle(GrtBasketQuery query, CancellationToken cancellationToken)
        {
          var basket = await basketRepo.GetBasket(query.UserName);
            return new GetBasketResult(basket);
        }
    }
}
