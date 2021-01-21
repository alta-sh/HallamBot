using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using Emzi0767.Utilities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HallamBot
{
    class Program
    {
        public static DateTime preStartUpTime;
        static void Main(string[] args)
        {
            preStartUpTime = DateTime.UtcNow;
            MainAsync().GetAwaiter().GetResult();
            Console.ReadKey();
        }

        static async Task MainAsync()
        {
            Init.Bot.Init();

            await Init.Bot.DiscordCtx.ConnectAsync();
            await Task.Delay(-1);
            Console.ReadKey();
        }
    }
}
