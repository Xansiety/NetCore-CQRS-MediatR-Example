using CQRSMediatRExample.Entities;

namespace CQRSMediatRExample.Context
{
    public class FakeDataStore
    {
        private static List<Product> _products;

        public FakeDataStore()
        {
            _products = new List<Product>()
            {
                new Product{ Id = 1, Name = "Test Product 1" },
                new Product{ Id = 2, Name = "Test Product 2" },
                new Product{ Id = 3, Name = "Test Product 3"},
                new Product{ Id = 4, Name = "Test Product 4"},
                new Product{ Id = 5, Name = "Test Product 5"},
            };
        }

        public async Task AddProduct(Product product)
        {
            _products.Add(product);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Product>> GetAllProducts() => await Task.FromResult(_products);

        public async Task<Product> GetProductById(int Id) => await Task.FromResult(_products.Single<Product>(p => p.Id == Id));

        public async Task EventOccured(Product product, string evnt)
        {
            _products.Single(p => p.Id == product.Id).Name = $"{product.Name} event: {evnt}";
            await Task.CompletedTask;
        }
    }
}
