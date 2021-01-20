using DSharpPlus;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HallamBot
{
    public static class Bot
    {
        public static DiscordClient DiscordCtx;
        public static void Init()
        {
            var discord = new DiscordClient(new DiscordConfiguration()
            {
                Token = Environment.GetEnvironmentVariable("HallamBotToken", EnvironmentVariableTarget.User),
                TokenType = TokenType.Bot,
                MinimumLogLevel = LogLevel.Information
            });

            DiscordCtx = discord;
            DiscordCtx.Ready += Events.DiscordCtx_Ready;
        }

        
    }
}
