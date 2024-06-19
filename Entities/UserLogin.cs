using System.ComponentModel.DataAnnotations;

namespace Entities

{
    public class UserLogin
    {
        [EmailAddress]
        public String Email { get; set; }
        public String Password { get; set; }
    }
}
