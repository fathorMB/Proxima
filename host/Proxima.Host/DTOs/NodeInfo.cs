using k8s.Models;

namespace Proxima.Host.DTOs
{
    public class NodeInfo
    {
        public string Name { get; set; }
        public IDictionary<string, string> Labels { get; set; }
        // The type of Conditions depends on your Kubernetes client model.
        // Here, we assume it's a list of a placeholder NodeCondition class.
        public IList<NodeCondition> Conditions { get; set; }
        public IDictionary<string, string> Capacity { get; set; }
        public IDictionary<string, string> Allocatable { get; set; }
    }
}
