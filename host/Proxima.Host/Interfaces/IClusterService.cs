using Proxima.Host.DTOs;

namespace Proxima.Host.Interfaces
{
    public interface IClusterService
    {
        Task<ClusterInfo> GetClusterInfo();
    }
}
