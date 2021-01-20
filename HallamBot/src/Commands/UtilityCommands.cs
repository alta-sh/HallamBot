using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HallamBot.Commands
{
    class UtilityCommands : BaseCommandModule
    {
       [Command("ping")]
        public async Task Ping(CommandContext ctx)
        {
            DateTime before = DateTime.UtcNow;
            await ctx.Channel.SendMessageAsync("Pong");
            DateTime after = DateTime.UtcNow;
            await ctx.Channel.SendMessageAsync(((after - before).Milliseconds / 10).ToString() + "ms response time.");
        }
    }
}
