using Proxima.Host.DTOs;
using Proxima.Host.Interfaces;

namespace Proxima.Host.Fakes
{
    public class FakeClusterService : IClusterService
    {
        public async Task<ClusterInfo> GetClusterInfo()
        {
            // Simulate asynchronous operation
            await Task.Delay(10);

            var clusterInfo = new ClusterInfo
            {
                Version = "v1.23.4",
                NodeCount = 2,
                Nodes = new List<NodeInfo>
        {
            new NodeInfo
            {
                Name = "node-1",
                Labels = new Dictionary<string, string>
                {
                    { "role", "worker" },
                    { "zone", "us-west" }
                },
                Conditions = new List<NodeCondition>
                {
                    new NodeCondition
                    {
                        Type = "Ready",
                        Status = "True",
                        Reason = "KubeletReady",
                        Message = "kubelet is ready",
                        LastTransitionTime = DateTime.UtcNow.AddHours(-1)
                    }
                },
                Capacity = new Dictionary<string, string>
                {
                    { "cpu", "4" },
                    { "memory", "16Gi" }
                },
                Allocatable = new Dictionary<string, string>
                {
                    { "cpu", "3" },
                    { "memory", "14Gi" }
                }
            },
            new NodeInfo
            {
                Name = "node-2",
                Labels = new Dictionary<string, string>
                {
                    { "role", "master" },
                    { "zone", "us-east" }
                },
                Conditions = new List<NodeCondition>
                {
                    new NodeCondition
                    {
                        Type = "Ready",
                        Status = "True",
                        Reason = "KubeletReady",
                        Message = "kubelet is ready",
                        LastTransitionTime = DateTime.UtcNow.AddHours(-2)
                    }
                },
                Capacity = new Dictionary<string, string>
                {
                    { "cpu", "2" },
                    { "memory", "8Gi" }
                },
                Allocatable = new Dictionary<string, string>
                {
                    { "cpu", "1" },
                    { "memory", "7Gi" }
                }
            }
        },
                Namespaces = new List<NamespaceInfo>
        {
            new NamespaceInfo
            {
                Name = "default",
                Status = "Active"
            },
            new NamespaceInfo
            {
                Name = "kube-system",
                Status = "Active"
            }
        }
            };

            return clusterInfo;
        }

    }
}
