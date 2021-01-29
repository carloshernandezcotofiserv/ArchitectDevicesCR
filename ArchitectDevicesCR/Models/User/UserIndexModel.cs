using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArchitectDevicesCR.Models.User
{
    public class UserIndexModel
    {
        public IEnumerable<UserDetailModel> Users { get; set; }
    }
}
