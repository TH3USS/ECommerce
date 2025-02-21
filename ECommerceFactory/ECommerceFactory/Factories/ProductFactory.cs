using ECommerceFactory.Models;

namespace ECommerceFactory.Factories
{
    public interface IProductFactory
    {
        Product CreateProduct(string name, string description, decimal price);
    }

    public class ProductFactory : IProductFactory
    {
        public Product CreateProduct(string name, string description, decimal price)
        {
            return new Product
            {
                Name = name,
                Description = description,
                Price = price
            };
        }
    }

}
