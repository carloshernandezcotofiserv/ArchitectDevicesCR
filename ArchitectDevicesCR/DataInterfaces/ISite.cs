using ArchitectDevicesCR.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArchitectDevicesCR.DataInterfaces
{
    public interface ISite
    {
        IEnumerable<Site> GetAll();
        IEnumerable<User> GetUsers(int siteId);
        IEnumerable<Device> GetDevices(int siteId);
        Site Get(int siteId);
        void Add(Site newSite);
    }
}
