using Entities;

namespace Service
{
    public interface IProductService
    {
        Task<List<Product>> Get(int? minPrice, int? maxPrice, List<int>? categoryIds, string? description, string? sortBy);
    }
}