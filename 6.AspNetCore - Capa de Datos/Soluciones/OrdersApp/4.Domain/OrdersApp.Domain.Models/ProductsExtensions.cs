using OrdersApp.Domain.Core;

namespace OrdersApp.Domain.Models
{
    public static class ProductsExtensions
    {
        public static ProductDto ToMapper(this Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }

        public static void UpdateProduct(this ProductDto productDto, Product product)
        {
            product.Update(
                productDto.Name,
                productDto.Price);
        }
    }
}
