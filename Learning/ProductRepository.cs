namespace MyFirstApi.Learning
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> _products = new List<Product>();
        public int AddProduct(Product product)
        {
            product.Id = _products.Count + 1;
            _products.Add(product);
            return product.Id;
        }
        public List<Product> GetAllProducts()
        {
            return _products;
        }

        public string GetName()
        {
            return "Name from ProductRepository";
        }
    }
}
