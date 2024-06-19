using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<List<Product>> Get(int? minPrice, int? maxPrice, List<int>? categoryIds, String? description, String? sortBy)
        {
            return await _productRepository.Get(minPrice, maxPrice, categoryIds, description, sortBy);
        }
    }
}
