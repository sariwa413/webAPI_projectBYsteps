using Entities;
using Repository;
using System.Text.Json;

namespace Service
{
    public class UserService : IUserService
    {
        private IUserRepository repos; 
        public UserService(IUserRepository userRep)
        {
            repos = userRep;
        }
        public async Task<User> Login(User userLgn)
        {
            return await repos.Login(userLgn);

        }

        public async Task<User> GetUserById(int id)
        {
            return await  repos.GetUserById(id);
        }

        public async Task<User> Register(User user)
        {
            return await repos.Register(user);
        }

        public async Task<User> UpdateUser(int id, User UpdatedUserDetails)
        {

            return await repos.UpdateUser(id, UpdatedUserDetails);

        }
    }
}
