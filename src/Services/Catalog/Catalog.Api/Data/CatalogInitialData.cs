using Marten.Schema;
using System.Xml.Linq;

namespace Catalog.Api.Data
{
    public class CatalogInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session = store.LightweightSession();
            if (await session.Query<Product>().AnyAsync())
                return;

            //Marten UPSERT will cater for existing record
            session.Store<Product>(GetPreconfiguredProducts());
            await session.SaveChangesAsync(cancellation);
        }

        private static IEnumerable<Product> GetPreconfiguredProducts() => new List<Product>()
        {
                new Product()
                {
                    Id = new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61"),
                    Name = "IPhone X",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-1.png",
                    Price = 950.00M,
                    Category = new List<string>{ "Smart Phone"}
                },
                new Product()
                {
                    Id = new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff62"),
                    Name = "Samsung 10",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-2.png",
                    Price = 955.00M,
                    Category = new List<string>{ "Smart Phone"}
                },
                new Product()
                {
                    Id = new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff63"),
                    Name = "Nokia",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-3.png",
                    Price = 840.00M,
                    Category = new List<string>{ "Smart Phone"}
                },
                new Product()
                {
                    Id = new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff64"),
                    Name = "Huawei Plus",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-.4png",
                    Price = 650.00M,
                    Category = new List<string>{ "White Appliances" }
                },
                  new Product()
                {
                    Id = new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff65"),
                    Name = "IPhone X1",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-5.png",
                    Price = 950.00M,
                    Category = new List<string>{ "Smart Phone"}
                },
                new Product()
                {
                    Id = new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff67"),
                    Name = "Samsung 10pro",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-6.png",
                    Price = 955.00M,
                    Category = new List<string>{ "Smart Phone"}
                },
                new Product()
                {
                    Id = new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff68"),
                    Name = "Nokia Asha",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-7.png",
                    Price = 840.00M,
                    Category = new List<string>{ "Smart Phone"}
                },
                new Product()
                {
                    Id = new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff69"),
                    Name = "Huawei ",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-9.png",
                    Price = 650.00M,
                    Category = new List<string>{ "White Appliances" }
                },
                  new Product()
                {
                    Id = new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff71"),
                    Name = "IPhone XP",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-10.png",
                    Price = 950.00M,
                    Category = new List<string>{ "Smart Phone"}
                },
                new Product()
                {
                    Id = new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff72"),
                    Name = "Samsung 20",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-12.png",
                    Price = 955.00M,
                    Category = new List<string>{ "Smart Phone"}
                },
                new Product()
                {
                    Id = new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff73"),
                    Name = "Nokia plus",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-13.png",
                    Price = 840.00M,
                    Category = new List<string>{ "Smart Phone"}
                },
                new Product()
                {
                    Id = new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff74"),
                    Name = "Huawei",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-.14png",
                    Price = 650.00M,
                    Category = new List<string>{ "White Appliances" }
                },
                  new Product()
                {
                    Id = new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff75"),
                    Name = "IPhone XX",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-15.png",
                    Price = 950.00M,
                    Category = new List<string>{ "Smart Phone"}
                },
                new Product()
                {
                    Id = new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff76"),
                    Name = "Samsung 30",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-2.png",
                    Price = 955.00M,
                    Category = new List<string>{ "Smart Phone"}
                },
                new Product()
                {
                    Id = new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff77"),
                    Name = "Nokia 3310",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-33.png",
                    Price = 840.00M,
                    Category = new List<string>{ "Smart Phone"}
                },
                new Product()
                {
                    Id = new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff78"),
                    Name = "Huawei XP",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-.34png",
                    Price = 650.00M,
                    Category = new List<string>{ "White Appliances" }
                }


        };
    }
}
