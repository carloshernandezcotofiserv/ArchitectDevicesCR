using ArchitectDevicesCR.DataModels;
using System.Collections.Generic;

namespace ArchitectDevicesCR.DataInterfaces
{
    public interface IDevice
    {
        IEnumerable<Device> GetAll();
        Device GetById(int id);
        void Add(Device newDevice);
        string GetDescription(int id);
        string GetOS(int id);
        Status GetStatus(int id);
        Site GetSite(int id);
        string GetImageUrl(int id);
    }
}
