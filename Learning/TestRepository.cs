namespace MyFirstApi.Learning
{
    public class TestRepository : IProductRepository
    {
        public int AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public string GetName()
        {
            return "Name from Testrepository";
        }
    }
}
