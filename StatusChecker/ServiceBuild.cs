namespace StatusChecker
// WIP 
{
    public class ServiceBuild
    {
        // Properties to store service details
        public string Service { get; }
        public string IpAddress { get; }
        public string Status { get; }

        // Constructor
        public ServiceBuild(string service, string ipAddress, string status)
        {
            Service = service ?? throw new ArgumentNullException(nameof(service));
            IpAddress = ipAddress ?? throw new ArgumentNullException(nameof(ipAddress));
            Status = status ?? throw new ArgumentNullException(nameof(status));
        }
    }
}
