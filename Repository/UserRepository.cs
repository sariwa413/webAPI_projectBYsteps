




using Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;


namespace Repository
{
    public class UserRepository : IUserRepository
    {
        string pathFile = "./User.txt";

        BabyStoreDbContext _BabyStoreDbContext;
        public UserRepository(BabyStoreDbContext bsdbcon)
        {
            _BabyStoreDbContext = bsdbcon;
        }
        public async Task<User> Login(User userLgn)
        {
            return await _BabyStoreDbContext.Users.Where(usr=> usr.Email==userLgn.Email && usr.Password==userLgn.Password).FirstOrDefaultAsync(); 
        }

        public async Task<User> GetUserById(int id)
        {
            return await _BabyStoreDbContext.Users.FindAsync(id);

        }

        public async Task<User> Register(User user)
        {
            await _BabyStoreDbContext.Users.AddAsync(user);
            await _BabyStoreDbContext.SaveChangesAsync();
            return await GetUserById(user.UserId);


        }

        public async Task<User> UpdateUser(int id, User UpdatedUserDetails)
        {
            User foundUser = await GetUserById(id);
            if(foundUser!=null)
            {
                _BabyStoreDbContext.Entry(foundUser).CurrentValues.SetValues(UpdatedUserDetails);
                await _BabyStoreDbContext.SaveChangesAsync();
                return UpdatedUserDetails;
            }
            return null;



        }
    }
}

    

