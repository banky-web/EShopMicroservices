
namespace Basket.Api.Basket.StoreBasket
{
    public record StoreBasketRequest(ShoppingCart Cart);

    public record StoreBasketResponse(string UserName);

    public class StoreBasketEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/basket", async (StoreBasketRequest request, ISender send) =>
            {
                var command = request.Adapt<StoreBasketCommand>();
                var result = await send.Send(command);

                var response = result.Adapt<StoreBasketResponse>();

                return Results.Created( $"/basket/{response.UserName}", response);
            })
             .WithName("CreatedProduct")
             .Produces<StoreBasketResponse>(StatusCodes.Status201Created)
             .ProducesProblem(StatusCodes.Status400BadRequest)
             .WithSummary("Create Product")
             .WithDescription("Create Product");
        }
    }
}
