using System;
using System.Collections.Generic;
using System.Text;

namespace HallamBot.Models
{
    public class TopicList
    {
        public List<Topic> Topics { get; set; }
        public Subject Subject { get; set; }
        public TopicList(Subject subject)
        {
            Subject = subject;
            Topics = new List<Topic>();

            if(subject == Subject.COMPUTER_SCIENCE)
            {
                var tempTopics = new List<string>() { "ALGORITHMS AND DATA STRUCTURES 2", "DATABASE SYSTEMS FOR SOFTWARE APPLICATIONS", "FUNDAMENTALS OF PROGRAMMING LANGUAGES", "GROUP SOFTWARE DEVELOPMENT PROJECT", "OBJECT-ORIENTED PROGRAMMING FOR COMPUTER SCIENCE", "SOFTWARE ENGINEERING: CONCEPTS AND METHODS" };
                for (int i = 0; i < tempTopics.Count; i++)
                {
                    Topics.Add(new Topic(tempTopics[i]));
                }
            }
        }
    }
}
