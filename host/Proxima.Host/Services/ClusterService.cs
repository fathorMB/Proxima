using k8s;
using Proxima.Host.DTOs;
using Proxima.Host.Interfaces;

namespace Proxima.Host.Services
{
    public class ClusterService : IClusterService
    {
        private readonly Kubernetes _k8sClient;

        public ClusterService()
        {
            // In-cluster configuration (this will work only when deployed in a Kubernetes cluster)
            var config = KubernetesClientConfiguration.InClusterConfig();
            _k8sClient = new Kubernetes(config);
        }

        public async Task<ClusterInfo> GetClusterInfo()
        {
            // Retrieve the Kubernetes version info using GetCodeAsync()
            var versionInfo = await _k8sClient.GetCodeAsync();

            // Retrieve nodes information.
            var nodesList = await _k8sClient.ListNodeAsync();
            var nodes = new List<NodeInfo>();
            foreach (var node in nodesList.Items)
            {
                nodes.Add(new NodeInfo
                {
                    Name = node.Metadata.Name,
                    Labels = node.Metadata.Labels,
                    Conditions = node.Status?.Conditions?
                        .Select(c => new NodeCondition
                        {
                            Type = c.Type,
                            Status = c.Status,
                            Reason = c.Reason,
                            Message = c.Message,
                            LastTransitionTime = c.LastTransitionTime
                        }).ToList(),
                    Capacity = node.Status?.Capacity?.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.ToString()),
                    Allocatable = node.Status?.Allocatable?.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.ToString())
                });
            }

            // Retrieve namespaces.
            var namespacesList = await _k8sClient.ListNamespaceAsync();
            var namespaces = new List<NamespaceInfo>();
            foreach (var ns in namespacesList.Items)
            {
                namespaces.Add(new NamespaceInfo
                {
                    Name = ns.Metadata.Name,
                    Status = ns.Status?.Phase
                });
            }

            // Compile and return the cluster information.
            var clusterInfo = new ClusterInfo
            {
                Version = versionInfo.GitVersion,
                NodeCount = nodesList.Items.Count,
                Nodes = nodes,
                Namespaces = namespaces
            };

            return clusterInfo;
        }
    }
}
