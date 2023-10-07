namespace StatusChecker
{
    using DSharpPlus.Entities;
    using DSharpPlus;
    using System.Threading.Tasks;
    using System.Diagnostics;

    public class Discord
    {
        public static async Task StartBotAndStatus(bool allServicesStatuses)
        {
            string? token = Environment.GetEnvironmentVariable("DISCORD_TOKEN");
            if (string.IsNullOrWhiteSpace(token))
            {
                Console.WriteLine("Please specify a token in the DISCORD_TOKEN environment variable.");
                Environment.Exit(1);

                return;
            }

            DiscordConfiguration config = new()
            {
                Token = token,
                Intents = DiscordIntents.AllUnprivileged | DiscordIntents.MessageContents
            };
            DiscordClient client = new(config);

            DiscordActivity status;

            if (allServicesStatuses == true) {
                status = new("all services online!", ActivityType.Watching);
            } else {
                status = new("some service are unavailable!", ActivityType.Watching);
            }

            await client.ConnectAsync(status, UserStatus.Online);

            await Task.Delay(-1);
        }
    }
}