using System;
using System.Collections.Generic;
using System.Text;

namespace HallamBot.Models
{
    public class Topic
    {
        public Subject Subject { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
    }
}
