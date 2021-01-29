using ArchitectDevicesCR.DataInterfaces;
using ArchitectDevicesCR.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ArchitectDevicesCR.Services
{
    public class DeviceService : IDevice
    {
        private readonly DevicesContext _context;
        public DeviceService(DevicesContext context)
        {
            _context = context;
        }

        public void Add(Device newDevice)
        {
            _context.Add(newDevice);
            _context.SaveChanges();
        }

        public IEnumerable<Device> GetAll()
        {
            return _context.Devices
                .Include(dev => dev.Site)
                .Include(dev => dev.Status);
        }

        public Device GetById(int id)
        {
            return GetAll().FirstOrDefault(dev => dev.Id == id);
        }

        public string GetDescription(int id)
        {
            return _context.Devices.FirstOrDefault(dev => dev.Id == id).Description;
        }

        public string GetImageUrl(int id)
        {
            return _context.Devices.FirstOrDefault(dev => dev.Id == id).ImageUrl;
        }

        public string GetOS(int id)
        {
            return _context.Devices.FirstOrDefault(dev => dev.Id == id).OS;
        }

        public Site GetSite(int id)
        {
            return _context.Devices.FirstOrDefault(dev => dev.Id == id).Site;
        }

        public Status GetStatus(int id)
        {
            return _context.Devices.FirstOrDefault(dev => dev.Id == id).Status;
        }
    }
}
