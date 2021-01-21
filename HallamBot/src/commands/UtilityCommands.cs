using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HallamBot.Commands
{
    public class UtilityCommands : BaseCommandModule
    {
        [Command("ping")]
        [Description("Will test the response time of a request to the bot.")]
        [Cooldown(maxUses: 1, resetAfter: 3, bucketType: CooldownBucketType.User)]
        public async Task Ping(CommandContext ctx)
        {
            DateTime before = DateTime.UtcNow;
            await ctx.Channel.SendMessageAsync("Pong :ping_pong:");
            DateTime after = DateTime.UtcNow;
            await ctx.Channel.SendMessageAsync(((after - before).Milliseconds / 10).ToString() + "ms response time. :chart_with_upwards_trend:");
        }

        [Cooldown(maxUses: 1, resetAfter: 5, bucketType: CooldownBucketType.Channel)]
        [Aliases("commands", "github", "")]
        [Command("help")]
        public async Task Help(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("You can find all the commands on alta's github reposoitory: https://github.com/alta-sh/HallamBot");
        }
        
        [Command("date")]
        public async Task Date(CommandContext ctx)
        {
            TimeSpan timeSpan = new TimeSpan(DateTime.Now.TimeOfDay.Hours, DateTime.Now.TimeOfDay.Minutes, DateTime.Now.TimeOfDay.Seconds);
            DateTime dateinfo = DateTime.Today.Add(timeSpan);
            
            
            await ctx.Channel.SendMessageAsync($"The day is **{dateinfo.DayOfWeek}** (*{dateinfo.ToShortDateString()}*) and it is **{dateinfo.ToString("hh:mmtt")}**. :stopwatch:");
        }
    }
}
