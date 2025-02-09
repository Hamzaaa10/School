using Microsoft.AspNetCore.Identity;

namespace School.Data.Models.Identity
{
    public class user : IdentityUser<int>
    {
        public string Address { get; set; }
    }
}
