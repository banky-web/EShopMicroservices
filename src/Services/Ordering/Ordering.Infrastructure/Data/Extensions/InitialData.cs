
namespace Ordering.Infrastructure.Data.Extensions
{
    public class InitialData
    {
        public static IEnumerable<Customer> Customers =>
            new List<Customer>
            {
                Customer.Create(CustomerId.Of(new Guid("7CDAE8B6-AE88-4FCB-AF59-A04FFADD0EA0")),"mehmet","mehmet@gmail.com"),
                Customer.Create(CustomerId.Of(new Guid("A1E4335C-80F7-4685-9224-D6A6B01D89A7")), "john", "john@gmail.com"),
            };

        public static IEnumerable<Product> Products =>
            new List<Product>
            {
                Product.Create(ProductId.Of(new Guid("D1F7C3E2-8F4B-4D3A-9C6E-2B5F4E8C9A1B")), "IPhone X", 500),
                Product.Create(ProductId.Of(new Guid("E2A3B4C5-D6E7-F8A9-0B1C-2D3E4F5A6B7C")), "Samsung 10", 400),
                Product.Create(ProductId.Of(new Guid("F3B4C5D6-E7F8-9A0B-1C2D-3E4F5A6B7C8D")), "Huawei Plus", 650),
                Product.Create(ProductId.Of(new Guid("A4C5D6E7-F8A9-0B1C-2D3E-4F5A6B7C8D9E")), "Xiaomi Mi", 450),
            };

        public static IEnumerable<Order> OrdersWithItems
        {
            get
            {
                var address1 = Address.Of("mehmet", "ozkaya", "mehmet@gmail.com", "Bahcelievler No:4", "Turkey", "Istanbul", "38050");
                var address2 = Address.Of("john", "doe", "john@gmail.com", "Broadway No:1", "England", "Nottingham", "08050");

                var payment1 = Payment.Of("mehmet", "5555555555554444", "12/28", "355", 1);
                var payment2 = Payment.Of("john", "888888888884444", "06/30", "222", 2);

                var order1 = Order.Create(
                    OrderId.Of(Guid.NewGuid()),
                    CustomerId.Of(new Guid("7CDAE8B6-AE88-4FCB-AF59-A04FFADD0EA0")),
                    OrderName.Of("ORD_1"),
                    shippingAddress: address1,
                    billingAddress: address1,
                    payment1);
                order1.Add(ProductId.Of(new Guid("D1F7C3E2-8F4B-4D3A-9C6E-2B5F4E8C9A1B")), 2, 500);
                order1.Add(ProductId.Of(new Guid("E2A3B4C5-D6E7-F8A9-0B1C-2D3E4F5A6B7C")), 1, 400);

                var order2 = Order.Create(
                   OrderId.Of(Guid.NewGuid()),
                   CustomerId.Of(new Guid("A1E4335C-80F7-4685-9224-D6A6B01D89A7")),
                   OrderName.Of("ORD_2"),
                   shippingAddress: address2,
                   billingAddress: address2,
                   payment2);
                order2.Add(ProductId.Of(new Guid("F3B4C5D6-E7F8-9A0B-1C2D-3E4F5A6B7C8D")), 1, 650);
                order2.Add(ProductId.Of(new Guid("A4C5D6E7-F8A9-0B1C-2D3E-4F5A6B7C8D9E")), 2, 450);

                return new List<Order> { order1, order2 };
            }
        }
    }

}
