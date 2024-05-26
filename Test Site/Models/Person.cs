using Microsoft.AspNetCore.Identity;
using Test_Site.Models.Enum;

namespace Test_Site.Models
{
    public class Person : IdentityUser
    {
        public UserRole Role { get; set; } = UserRole.User;
    }
}
