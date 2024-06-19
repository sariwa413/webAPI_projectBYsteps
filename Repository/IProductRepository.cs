using Entities;

namespace Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> Get(int? minPrice, int? maxPrice, List<int>? categoryIds, string? description, string? sortBy);
    }
}