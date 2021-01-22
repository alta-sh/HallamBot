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
        public async Task Test(CommandContext ctx, string param = null, string param2 = null)
        {
            switch (param.ToLower())
            {
                case "lecturealert":
                    if (param2.ToLower() == "resolve")
                        await LectureAlertTestResolve(ctx);
                    else
                        await LectureAlertTestCreate(ctx);
                    break;
                case null:
                    await ctx.Channel.SendMessageAsync("This is a developer command for testing purposes.");
                    break;
            }
        }

        private async Task LectureAlertTestResolve(CommandContext ctx)
        {
            var testLecture = TimetableData.Timetable.Lectures.Find(l => l.ModuleName.Equals("Test module"));
            TimetableData.Timetable.Lectures.Remove(testLecture);

            await ctx.Channel.SendMessageAsync($"Successfully removed {testLecture.ToString()}.");
        }

        private async Task LectureAlertTestCreate(CommandContext ctx)
        {
            Models.Lecture testLecture = new Models.Lecture()
            {
                Day = DateTime.Now,
                IsDropIn = false,
                Groups = "Test group data",
                IsTutorial = false,
                Lecturer = "Dr Test",
                ModuleName = "Test module",
                StartTime = DateTime.Now.TimeOfDay.Add(new TimeSpan(0, 30, 0))
            };
            TimetableData.Timetable.Lectures.Add(testLecture);
            await ctx.Channel.SendMessageAsync("Generating a test lecture for testing purposes... will ping a Lecture Alert when ready.\nDon't forget to remove this test lecture once pinged with `LectureAlert Resovle`");
        }
    }
}
