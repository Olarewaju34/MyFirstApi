namespace MyFirstApi.Learning
{
    public interface IProductRepository
    {
        int AddProduct(Product product);
        List<Product> GetAllProducts();
        string GetName();
    }
}