using DSharpPlus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HallamBot
{
    public static class Events
    {
        public static Task DiscordCtx_Ready(DiscordClient sender, DSharpPlus.EventArgs.ReadyEventArgs e)
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

            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("\n--------------------- All Systems Online ---------------------"); Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\nListening...\n");
            return Task.CompletedTask;
        }
    }
}
