using Microsoft.AspNetCore.Identity;

namespace LoginDemoDay64.Data
{
    public class ApplicationIdentityUser:IdentityUser
    {
        public int Age { get; set; }
    }
}
