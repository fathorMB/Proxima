namespace Proxima.Host.DTOs
{
    // A placeholder class for node conditions.
    // Replace or extend this with the actual model if available.
    public class NodeCondition
    {
        public string Type { get; set; }
        public string Status { get; set; }
        public string Reason { get; set; }
        public string Message { get; set; }
        public DateTime? LastTransitionTime { get; set; }
    }
}
