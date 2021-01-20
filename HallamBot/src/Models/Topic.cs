using System;
using System.Collections.Generic;
using System.Text;

namespace HallamBot.Models
{
    public class Topic
    {
        public String Name { get; set; }
        public List<Assignment> Assignments { get; set; }

        public Topic(String name)
        {
            Name = name;
            Assignments = new List<Assignment>();
        }

        public void BuildAssignments()
        {
            if (Name.Equals("ALGORITHMS AND DATA STRUCTURES 2"))
            {
                Assignments.Add(
                    new Assignment(
                        "001 - Written Assignment",
                        Semester.FIRST,
                        40,
                        new DateTime(21, 1, 14),
                        new DateTime(21, 2, 4)));

                Assignments.Add(
                    new Assignment(
                        "002 - Written Assignment",
                        Semester.SECOND,
                        60,
                        new DateTime(21, 4, 20),
                        new DateTime(21, 5, 12)));
            }

            else if (Name.Equals("DATABASE SYSTEMS FOR SOFTWARE APPLICATIONS"))
            {
                Assignments.Add(
                    new Assignment(
                        "001 - Phase Test",
                        Semester.FIRST,
                        30,
                        new DateTime(20, 12, 10),
                        new DateTime(21, 1, 14)));

                Assignments.Add(
                    new Assignment(
                        "002 - Report",
                        Semester.SECOND,
                        40,
                        new DateTime(21, 3, 5),
                        new DateTime(21, 3, 26)));

                Assignments.Add(
                    new Assignment(
                        "003 - Exam",
                        Semester.SECOND,
                        30,
                        new DateTime(21, 6, 1),
                        new DateTime(21, 6, 1)));
            }

            else if (Name.Equals("FUNDAMENTALS OF PROGRAMMING LANGUAGES"))
            {
                Assignments.Add(
                    new Assignment(
                        "001 - Written Assignment",
                        Semester.FIRST,
                        40,
                        new DateTime(20, 12, 17),
                        new DateTime(21, 1, 21)));

                Assignments.Add(
                    new Assignment(
                        "002 - Written Assignment",
                        Semester.FIRST,
                        60,
                        new DateTime(21, 4, 15),
                        new DateTime(21, 5, 7)));
            }

            else if (Name.Equals("GROUP SOFTWARE DEVELOPMENT PROJECT"))
            {
                Assignments.Add(
                    new Assignment(
                        "001 - Reflective Account",
                        Semester.FIRST,
                        20,
                        new DateTime(20, 12, 17),
                        new DateTime(21, 1, 21)));

                Assignments.Add(
                    new Assignment(
                        "002 - Project",
                        Semester.SECOND,
                        80,
                        new DateTime(21, 3, 4),
                        new DateTime(21, 3, 25)));
            }

            else if (Name.Equals("OBJECT-ORIENTED PROGRAMMING FOR COMPUTER SCIENCE"))
            {
                Assignments.Add(
                    new Assignment(
                        "001 - Written Assignment",
                        Semester.FIRST,
                        30,
                        new DateTime(20, 12, 3),
                        new DateTime(21, 1, 7)));

                Assignments.Add(
                    new Assignment(
                        "002 - Written Assignment",
                        Semester.SECOND,
                        70,
                        new DateTime(21, 4, 15),
                        new DateTime(21, 5, 7)));
            }

            else if (Name.Equals("SOFTWARE ENGINEERING: CONCEPTS AND METHODS"))
            {
                Assignments.Add(
                    new Assignment(
                        "001 - Case Study",
                        Semester.FIRST,
                        40,
                        new DateTime(20, 12, 10),
                        new DateTime(21, 1, 14)));

                Assignments.Add(
                    new Assignment(
                        "002 - Case Study",
                        Semester.SECOND,
                        60,
                        new DateTime(21, 3, 18),
                        new DateTime(21, 4, 22)));

                Assignments.Add(
                    new Assignment(
                        "003 - Exam",
                        Semester.SECOND,
                        60,
                        new DateTime(21, 6, 1),
                        new DateTime(21, 6, 1)));
            }

        }
    }
}
