using DSharpPlus;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.Entities;
using DSharpPlus.CommandsNext;

namespace HallamBot.Init
{
    public static class Bot
    {
        public static DiscordClient DiscordCtx { get; private set; }
        public static CommandsNextExtension Commands { get; private set; }
        public static void Init()
        {
            var discord = new DiscordClient(new DiscordConfiguration()
            {
                Token = Environment.GetEnvironmentVariable("HallamBotToken", EnvironmentVariableTarget.User),
                TokenType = TokenType.Bot,
                MinimumLogLevel = LogLevel.Information
            });

            var CommandsConfig = new CommandsNextConfiguration
            {
                StringPrefixes = new string[] { "!hallambot", "!hb" },
                CaseSensitive = false,
                EnableDms = true,
                EnableMentionPrefix = true,
                DmHelp = false,
                EnableDefaultHelp = false
            };

            Commands = discord.UseCommandsNext(CommandsConfig);
            Commands.RegisterCommands<HallamBot.Commands.UtilityCommands>();


            DiscordCtx = discord;
            DiscordCtx.Ready += Events.OnReady.OnTrigger;
        }

        
    }
}
