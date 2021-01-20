using System;
using System.Collections.Generic;
using System.Text;

namespace HallamBot.Models
{
    public class Assignment
    {
        public string AssignmentTitle { get; set; }
        public Semester Semester { get; set; }
        public int Percentage { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime FeedbackReturn { get; set; }

        public Assignment(string title, Semester semester, int weight, DateTime deadline, DateTime feedback)
        {
            AssignmentTitle = title;
            Semester = semester;
            Percentage = weight;
            Deadline = deadline;
            FeedbackReturn = feedback;
        }
    }
}
