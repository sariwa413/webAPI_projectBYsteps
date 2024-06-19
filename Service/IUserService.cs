using Entities;

namespace Service
{
    public interface IUserService
    {
        Task<User> GetUserById(int id);
        Task<User> Login(User userLgn);
        Task<User> Register(User user);
        Task<User> UpdateUser(int id, User UpdatedUserDetails);
    }
}