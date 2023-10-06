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
            // For the sake of examples, we're going to load our Discord token from an environment variable.
            string? token = Environment.GetEnvironmentVariable("DISCORD_TOKEN");
            if (string.IsNullOrWhiteSpace(token))
            {
                Console.WriteLine("Please specify a token in the DISCORD_TOKEN environment variable.");
                Environment.Exit(1);

                // For the compiler's nullability, unreachable code.
                return;
            }

            // Next, we instantiate our client.
            DiscordConfiguration config = new()
            {
                Token = token,

                // We're asking for unprivileged intents, which means we won't receive any member or presence updates.
                // Privileged intents must be enabled in the Discord Developer Portal.

                // TODO: Enable the message content intent in the Discord Developer Portal.
                // The !ping command will not work without it.
                Intents = DiscordIntents.AllUnprivileged | DiscordIntents.MessageContents
            };
            DiscordClient client = new(config);

            DiscordActivity status;

            if (allServicesStatuses == true) {
                status = new("all services online!", ActivityType.Watching);
            } else {
                status = new("some service are unavailable!", ActivityType.Watching);
            }

            // Now we connect and log in.
            await client.ConnectAsync(status, UserStatus.Online);

            // And now we wait infinitely so that our bot actually stays connected.
            await Task.Delay(-1);
        }
    }
}