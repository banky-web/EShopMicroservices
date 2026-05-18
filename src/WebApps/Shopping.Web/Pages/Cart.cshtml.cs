namespace Shopping.Web.Pages
{
    public class CartModel(IBasketService basketService, ILogger<CartModel> logger)
        : PageModel
    {
        public ShoppingCartModel Cart { get; set; } = new ShoppingCartModel();
        public async Task<IActionResult> OnGetAsync()
        {
            logger.LogInformation("Cart page visitied");
            Cart = await basketService.LoadUserBasket();
            return Page();
        }

        public async Task<IActionResult> OnPostRemoveToCartAsync(Guid productId)
        {
            logger.LogInformation("Remove from cart button clicked");
            Cart = await basketService.LoadUserBasket();

            Cart.Items.RemoveAll(item => item.ProductId == productId);
            await basketService.StoreBasket(new StoreBasketRequest(Cart));

            return RedirectToPage();

        }
    }
}
