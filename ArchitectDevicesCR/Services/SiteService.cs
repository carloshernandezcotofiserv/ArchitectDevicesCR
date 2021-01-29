using ArchitectDevicesCR.DataInterfaces;
using ArchitectDevicesCR.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArchitectDevicesCR.Services
{
    public class SiteService : ISite
    {
        private DevicesContext _context;

        public SiteService(DevicesContext context)
        {
            _context = context;
        }

        public void Add(Site newSite)
        {
            _context.Add(newSite);
            _context.SaveChanges();
        }

        public Site Get(int siteId)
        {
            return GetAll().FirstOrDefault(s => s.Id == siteId);
        }

        public IEnumerable<Site> GetAll()
        {
            return _context.Sites
                .Include(s => s.Users)
                .Include(s => s.Devices);
        }

        public IEnumerable<Device> GetDevices(int siteId)
        {
            return _context.Sites
                .Include(s => s.Devices)
                .FirstOrDefault(s => s.Id == siteId)
                .Devices;
        }

        public IEnumerable<User> GetUsers(int siteId)
        {
            return _context.Sites
                .Include(s => s.Users)
                .FirstOrDefault(s => s.Id == siteId)
                .Users;
        }
    }
}
