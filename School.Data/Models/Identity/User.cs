using Microsoft.AspNetCore.Identity;

namespace School.Data.Models.Identity
{
    public class User : IdentityUser<int>
    {
        public string Address { get; set; }
    }
}
