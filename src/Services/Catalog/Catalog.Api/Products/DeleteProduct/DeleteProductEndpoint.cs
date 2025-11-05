namespace Catalog.Api.Products.DeleteProduct
{
   // public record DeleteProductRequest(Guid Id);
    public record DeleteProductResponse(bool IsSuccess);
    public class DeleteProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/products/{id}", async (Guid id, ISender sender) =>
            {
              var result = await sender.Send( new DeleteProductCommand(id));
              var response = result.Adapt<DeleteProductResponse>();

                return Results.Ok(response);
            })
            .WithName("DeleteProduct")
            .Produces<DeleteProductResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Delete a product")
            .WithDescription("Deletes a product by its unique identifier.");
        }
    }
   
}
