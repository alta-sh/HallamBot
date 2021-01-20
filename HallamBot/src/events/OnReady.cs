using DSharpPlus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.Entities;
using System.Threading;

namespace HallamBot.Events
{
    public static class OnReady
    {
        private static readonly DiscordClient ctx = Init.Bot.DiscordCtx;
        public static Task OnTrigger(DiscordClient sender, DSharpPlus.EventArgs.ReadyEventArgs e)
        {
            DateTime postStartUpTime = DateTime.UtcNow;

            PrintInit();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\n [Startup time: {(postStartUpTime - HallamBot.Program.preStartUpTime).TotalSeconds.ToString()} seconds] "); Console.BackgroundColor = ConsoleColor.Black;


            var status = new DiscordActivity("Hallam CS Activity", DSharpPlus.Entities.ActivityType.Watching);
            ctx.UpdateStatusAsync(status);
            

            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("\n--------------------- All Systems Online ---------------------"); Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\n\nListening...\n");
            return Task.CompletedTask;
        }

        private static void PrintInit()
        {
            string onLoadGreeting = @"
                             | |  | |     | | |               |  _ \      | |  
                             | |__| | __ _| | | __ _ _ __ ___ | |_) | ___ | |_ 
                             |  __  |/ _` | | |/ _` | '_ ` _ \|  _ < / _ \| __|
                             | |  | | (_| | | | (_| | | | | | | |_) | (_) | |_ 
                             |_|  |_|\__,_|_|_|\__,_|_| |_| |_|____/ \___/ \__|
                             
                             ";

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(onLoadGreeting);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Made with <3 by Alta"); Console.ForegroundColor = ConsoleColor.White; Console.Write(" | ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"https://github.com/alta-sh"); Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
