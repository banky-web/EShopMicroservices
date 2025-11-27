

namespace Basket.Api.Basket.GetBasket
{
    //public record GetBasketReequst(string UserName);
    public record GetBasketResponse(ShoppingCart Cart);

    public class GetBasketEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("basket/{userName}", async (string userName, ISender sender) =>
            {
                var result = await sender.Send(new GrtBasketQuery(userName));

                var response = result.Adapt<GetBasketResponse>();
                return Results.Ok(response);
            })
            .WithName("GetProductById")
            .Produces<GetBasketResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get basket by user name")
            .WithDescription("Gets the shopping cart for a specific user by their user name.");
        }
    }
}
