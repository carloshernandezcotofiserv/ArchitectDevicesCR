using System.Security.Claims;
using System.Threading.Tasks;
using ArchitectDevicesCR.DataInterfaces;
using ArchitectDevicesCR.DataModels;
using Microsoft.AspNetCore.Authentication;
using System.Linq;

namespace ArchitectDevicesCR.Authentication
{
    public class ClaimsTransformer : IClaimsTransformation
    {
        private DevicesContext _context;

        public ClaimsTransformer(DevicesContext context)
        {
            _context = context;
        }
        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            var ci = (ClaimsIdentity)principal.Identity;
            var currentUser = _context.Users.FirstOrDefault(u => u.Username == ci.Name);
            if (currentUser != null)
            {
                var fullNameClaim = new Claim("FullName", currentUser.FirstName + " " + currentUser.LastName);
                ci.AddClaim(fullNameClaim);

                var usageAuthClaim = new Claim(ci.RoleClaimType, "CanUseApp");
                ci.AddClaim(usageAuthClaim);
                if (currentUser.IsAdmin)
                {
                    var adminClaim = new Claim(ci.RoleClaimType, "Admin");
                    ci.AddClaim(adminClaim);
                }
            }
            return Task.FromResult(principal);
        }
    }
}
