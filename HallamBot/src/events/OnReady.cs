using DSharpPlus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.Entities;
using System.Threading;
using HallamBot.Models;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using HallamBot.data;
using System.Linq;
using HallamBot.models;

namespace HallamBot.Events
{
    public static class OnReady
    {
        private static readonly DiscordClient ctx = Init.Bot.DiscordCtx;
        public static readonly string READ_WRITE_PATH = @"Directory.GetCurrentDirectory()" + @"..\..\..\..\..\src\data\";
        public static Timetable Timetable;
        public static Task OnTrigger(DiscordClient sender, DSharpPlus.EventArgs.ReadyEventArgs e)
        {
            Timetable = new Timetable();
            Task.Run(async () => await LectureNotification(new CancellationToken()));

            DateTime postStartUpTime = DateTime.UtcNow;

            PrintInit();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\n [Startup time: {(postStartUpTime - HallamBot.Program.preStartUpTime).TotalSeconds.ToString()} seconds] "); Console.BackgroundColor = ConsoleColor.Black;


            var status = new DiscordActivity("Hallam CS Activity", DSharpPlus.Entities.ActivityType.Watching);
            ctx.UpdateStatusAsync(status);
            

            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("\n--------------------- All Systems Online ---------------------"); Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Building Models...\n");
            BuildModels();
            if (Data.TopicData.CsTopics != null)
            {
                Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine(Data.TopicData.CsTopics.Subject.ToString() + " Data Model exists.");
            } else
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("COMPUTER SCIENCE Data Model does not exist.");
            }

            if (Data.TopicData.SoftEngTopics != null)
            {
                Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine(Data.TopicData.SoftEngTopics.Subject.ToString() + " Data Model exists.");
            } else
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("SOFTWARE ENGINEERING Data Model does not exist.");
            }

            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("Models successfully built!"); Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\nListening...\n");
            return Task.CompletedTask;
        }

        private static async void BuildModels()
        {
            Data.TopicData.CsTopics = new TopicList(Subject.COMPUTER_SCIENCE);
            if (!File.Exists(READ_WRITE_PATH + @"CsTopicData.json"))
            {
                Console.WriteLine("Json data does not exist... Generating the data now...");
                foreach(var topic in Data.TopicData.CsTopics.Topics)
                {
                    topic.BuildAssignments();
                }
                var s = JsonConvert.SerializeObject(Data.TopicData.CsTopics);
                await File.WriteAllTextAsync(READ_WRITE_PATH + @"CsTopicData.json", s);
                
                foreach (var module in Data.TopicData.CsTopics.Topics)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\n\t{module.Name}: ");

                    foreach (var assignment in module.Assignments)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"\t\t {assignment.AssignmentTitle} - {assignment.Percentage}% - [{assignment.Semester.ToString().ToUpper()} SEMESTER]\n" +
                            $"\t\t Deadline: {assignment.Deadline.ToShortDateString()} | Feedback {assignment.FeedbackReturn.ToShortDateString()}\n");
                    }
                }

                Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\n\nJson sample data successfully generated and saved.\n\n"); Console.ForegroundColor = ConsoleColor.White;
            } else
            {
                Console.WriteLine("Json file found for data... importing now... ");
                Data.TopicData.CsTopics = JsonConvert.DeserializeObject<TopicList>(File.ReadAllText(READ_WRITE_PATH + @"CsTopicData.json"));
                Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("All data has successfully been imported!"); Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private static bool messageSent = false;
        private static Lecture currentLecture;
        private static async Task LectureNotification(CancellationToken cancellationToken)
        {
            while (true)
            {
                Random rand = new Random();
                int recallTime = rand.Next(1500, 5000);
                if(!messageSent)
                {
                    foreach(var lecture in Timetable.Lectures)
                    {
                        if (lecture.Day.DayOfWeek == DateTime.Now.DayOfWeek)
                        {
                            if ((lecture.StartTime.Hours - 1) == DateTime.Now.Hour)
                            {
                                var minutesRemaining = (lecture.StartTime - DateTime.Now.TimeOfDay).Minutes;
                                if ((minutesRemaining) > 0 && (minutesRemaining) < 30)
                                {
                                    currentLecture = lecture;
                                    await ctx.GetChannelAsync(801191647274467328).Result.SendMessageAsync($"**{lecture.ModuleName}** is about to start in **{(lecture.StartTime - DateTime.Now.TimeOfDay).Minutes}** minutes!\n**Groups:** *{lecture.Groups}*\n**Lecturer:** *{lecture.Lecturer}* \n {(lecture.IsTutorial ? "** --- This is a tutorial ---**" : "**--- This is a lecture ---**")} \n_______________________________________________");
                                    messageSent = true;
                                }
                            }
                        }
                    } 
                } else
                {
                    var checkMinutes = (currentLecture.StartTime - DateTime.Now.TimeOfDay).Minutes;

                    if (checkMinutes <= 0)
                    {
                        messageSent = false;
                        currentLecture = null;
                    }
                }
                await Task.Delay(recallTime * 60, cancellationToken);
                if (cancellationToken.IsCancellationRequested)
                    break;
            }
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
