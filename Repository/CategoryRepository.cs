using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private BabyStoreDbContext _babyStoreContext;

        public CategoryRepository(BabyStoreDbContext babyContext)
        {
            _babyStoreContext = babyContext;
        }

        public async Task<List<Category>> Get()
        {
            return await _babyStoreContext.Categories.ToListAsync();
        }
    }
}
