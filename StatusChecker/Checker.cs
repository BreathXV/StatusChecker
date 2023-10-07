using System;
using System.Net.NetworkInformation;

namespace StatusChecker {
    public class StatusGetter {
        private string GetServiceIP(string service) {
            string[,] serviceIPs = {
                {"Discord Bot", "DiscordIPA"},
                {"Emails", "EmailIPA"},
                {"Website", "WebsiteIPA"},
                {"DayZ Server", "DayZIPA"}
            };

            string serviceIP = string.Empty;

            for (int i = 0; i < serviceIPs.GetLength(0); i++) {
                if (service.Equals(serviceIPs[i, 0], StringComparison.OrdinalIgnoreCase)) {
                    serviceIP = serviceIPs[i, 1];
                    break;
                }
            }

            return serviceIP;
        }
        public string CheckServiceStatus(string service) {
            string serviceIP = GetServiceIP(service);
            string statusService = string.Empty;

            if (string.IsNullOrEmpty(serviceIP)) {
                statusService = "Service IP has not be parsed.";
                return statusService;
            }

            Ping ping = new Ping();

            PingReply reply = ping.Send(serviceIP);

            if (reply != null && reply.Status == IPStatus.Success) {
                statusService = $"Online {service}";
                return statusService;
            } else {
                statusService = $"Offline {service}";
                return statusService;
            }
        }
    }
}
