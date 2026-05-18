namespace Shopping.Web.Pages
{
    public class OrderListModel(IOrderingService orderingService, ILogger<OrderListModel> logger)
        : PageModel
    {
        public IEnumerable<OrderModel> Orders { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            var customerId = new Guid("7cdae8b6-ae88-4fcb-af59-a04ffadd0ea0");
            var response = await orderingService.GetOrdersByCustomerId(customerId);

            Orders = response.Orders;

            return Page();
        }
    }
}
