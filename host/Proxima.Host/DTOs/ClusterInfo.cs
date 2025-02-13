namespace Proxima.Host.DTOs
{
    public class ClusterInfo
    {
        public string Version { get; set; }
        public int NodeCount { get; set; }
        public List<NodeInfo> Nodes { get; set; }
        public List<NamespaceInfo> Namespaces { get; set; }
    }
}
