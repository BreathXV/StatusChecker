using System;
using System.Net.NetworkInformation;

namespace StatusChecker {
    public class StatusGetter {
        // Method to get the IP address of a service
        private string GetServiceIP(string service) {
            // Define a 2D array to store service names and corresponding IP addresses
            string[,] serviceIPs = {
                {"Discord Bot", "DiscordIPA"},
                {"Emails", "EmailIPA"},
                {"Website", "WebsiteIPA"},
                {"DayZ Server", "DayZIPA"}
            };

            // Initialize an empty string to store the service's IP address
            string serviceIP = string.Empty;

            // Loop through the array to find a match for the specified service
            for (int i = 0; i < serviceIPs.GetLength(0); i++) {
                // Compare service names (case-insensitive)
                if (service.Equals(serviceIPs[i, 0], StringComparison.OrdinalIgnoreCase)) {
                    // Assign the corresponding IP address if a match is found
                    serviceIP = serviceIPs[i, 1];
                    // Exit the loop since we found the service
                    break;
                }
            }

            // Return the service's IP address
            return serviceIP;
        }

        // Method to check the status of a service
        public string CheckServiceStatus(string service) {
            // Get the IP address of the specified service
            string serviceIP = GetServiceIP(service);
            string statusService = string.Empty;

            // Check if the IP address is not found
            if (string.IsNullOrEmpty(serviceIP)) {
                // Display a message indicating that the service was not found
                statusService = "Service IP has not be parsed.";
                return statusService;
            }

            // Create a Ping object to send ICMP echo request messages
            Ping ping = new Ping();

            // Send a ping request to the service's IP address
            PingReply reply = ping.Send(serviceIP);

            // Check if the ping was successful (service is online)
            if (reply != null && reply.Status == IPStatus.Success) {
                // Display a message indicating that the service is online
                statusService = $"Online {service}";
                return statusService;
            } else {
                // Display a message indicating that the service is offline
                statusService = $"Offline {service}";
                return statusService;
            }
        }
    }
}
