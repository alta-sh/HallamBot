using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HallamBot.Data;

namespace HallamBot.Commands
{
    public class TestCommands : BaseCommandModule
    {
        [Command("test")]
        public async Task Test(CommandContext ctx, string param)
        {
            switch (param.ToLower())
            {
                case "LectureAlert":
                    await LectureAlertTest(ctx);
                    break;

                default:
                    await ctx.Channel.SendMessageAsync("This is a developer command for testing purposes.");
                    break;
            }
        }

        private async Task LectureAlertTest(CommandContext ctx)
        {
            Models.Lecture testLecture = new Models.Lecture()
            {
                Day = DateTime.Now,
                IsDropIn = false,
                Groups = "Test group data",
                IsTutorial = false,
                Lecturer = "Dr Test",
                ModuleName = "Test module",
                StartTime = DateTime.Now.TimeOfDay.Add(new TimeSpan(0, 31, 0))
            };
            TimetableData.Timetable.Lectures.Add(testLecture);
            await ctx.Channel.SendMessageAsync("Generating a test lecture for testing purposes... will ping a Lecture Alert when ready.");

            
        }
    }
}
