using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        private BabyStoreDbContext _babyStoreContext;
        public ProductRepository(BabyStoreDbContext babyStoreContext)
        {
            _babyStoreContext = babyStoreContext;
        }

        public async Task<List<Product>> Get(int? minPrice, int? maxPrice, List<int>? categoryIds, String? description, String? sortBy)
        {
            return await _babyStoreContext.Products.Include(category => category.Category).ToListAsync();
        }
    }
}
