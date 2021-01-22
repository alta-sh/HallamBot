using System;
using System.Collections.Generic;
using System.Text;

namespace HallamBot.Models
{
    public class Lecture
    {
        public string ModuleName { get; set; }
        public string Lecturer { get; set; }
        public DateTime Day { get; set; }
        public TimeSpan StartTime { get; set; }
        public bool IsDropIn { get; set; }
        public bool IsTutorial { get; set; }
        public string Groups { get; set; }
    }
}
