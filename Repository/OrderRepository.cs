using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderRepository : IOrderRepository
    {
        private BabyStoreDbContext _babyStoreContext;
        public OrderRepository(BabyStoreDbContext babyStoreContext)
        {
            _babyStoreContext = babyStoreContext;
        }

        public async Task<Order> AddOrder(Order order)
        {
            await _babyStoreContext.Orders.AddAsync(order);
            await _babyStoreContext.SaveChangesAsync();
            return order;
        }
    }
}
