using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HallamBot.models
{
    public class Timetable
    {
        public List<Lecture> Lectures { get; set; }

        public Timetable()
        {
            Lectures = new List<Lecture>();
            BuildTimetable();
        }
        public List<Lecture> GetLecturesToday()
        {
            DateTime currentDate = DateTime.Now;
            List<Lecture> lecturesToday = new List<Lecture>();

            foreach (var lecture in Lectures.Where(l => l.Day.DayOfWeek == currentDate.DayOfWeek))
            {
                lecturesToday.Add(lecture);
            }

            return lecturesToday;
        }

        private void BuildTimetable()
        {
            Lectures.Add(new Lecture
            {
                ModuleName = "OBJECT-ORIENTED PROGRAMMING FOR COMPUTER SCIENCE",
                Lecturer = "Mike Meredith",
                Groups = "All",
                IsDropIn = true,
                Day = new DateTime(21, 01, 18),
                StartTime = new TimeSpan(15, 0, 0)
            });

            Lectures.Add(new Lecture
            {
                ModuleName = "SOFTWARE ENGINEERING: CONCEPTS AND METHODS",
                Lecturer = "Babak Khazaei",
                Groups = "All",
                IsDropIn = false,
                Day = new DateTime(21, 01, 19),
                StartTime = new TimeSpan(10, 0, 0)
            });

            Lectures.Add(new Lecture
            {
                ModuleName = "DATABASE SYSTEMS FOR SOFTWARE APPLICATIONS",
                Lecturer = "Laurie Hirsch",
                Groups = "All",
                IsDropIn = false,
                Day = new DateTime(21, 01, 19),
                StartTime = new TimeSpan(14, 0, 0)
            });

            Lectures.Add(new Lecture
            {
                ModuleName = "FUNDAMENTALS OF PROGRAMMING LANGUAGES",
                Lecturer = "Christopher Bates",
                Groups = "All",
                IsDropIn = false,
                Day = new DateTime(21, 01, 20),
                StartTime = new TimeSpan(10, 0, 0)
            });

            Lectures.Add(new Lecture
            {
                ModuleName = "ALGORITHMS AND DATA STRUCTURES 2",
                Lecturer = "Jing Wang",
                Groups = "All",
                IsDropIn = false,
                Day = new DateTime(21, 01, 21),
                StartTime = new TimeSpan(10, 0, 0)
            });

            Lectures.Add(new Lecture
            {
                ModuleName = "OBJECT-ORIENTED PROGRAMMING FOR COMPUTER SCIENCE",
                Lecturer = "Mike Meredith",
                Groups = "1, 2 and 3",
                IsDropIn = false,
                IsTutorial = true,
                Day = new DateTime(21, 01, 21),
                StartTime = new TimeSpan(14, 0, 0)
            });

            Lectures.Add(new Lecture
            {
                ModuleName = "OBJECT-ORIENTED PROGRAMMING FOR COMPUTER SCIENCE",
                Lecturer = "Mike Meredith",
                Groups = "4, 5 and 6",
                IsDropIn = false,
                IsTutorial = true,
                Day = new DateTime(21, 01, 21),
                StartTime = new TimeSpan(16, 0, 0)
            });

            Lectures.Add(new Lecture
            {
                ModuleName = "FUNDAMENTALS OF PROGRAMMING LANGUAGES",
                Lecturer = "Chris Bates",
                Groups = "1, 2 and 3",
                IsDropIn = false,
                IsTutorial = true,
                Day = new DateTime(21, 01, 22),
                StartTime = new TimeSpan(9, 30, 0)
            });

            Lectures.Add(new Lecture
            {
                ModuleName = "SOFTWARE ENGINEERING: CONCEPTS AND METHODS",
                Lecturer = "Babak Khazaei",
                Groups = "1, 2 and 3",
                IsDropIn = false,
                IsTutorial = true,
                Day = new DateTime(21, 01, 22),
                StartTime = new TimeSpan(10, 30, 0)
            });

            Lectures.Add(new Lecture
            {
                ModuleName = "ALGORITHMS AND DATA STRUCTURES 2",
                Lecturer = "Jing Wang",
                Groups = "1, 2 and 3",
                IsDropIn = false,
                IsTutorial = true,
                Day = new DateTime(21, 01, 22),
                StartTime = new TimeSpan(11, 30, 0)
            });

            Lectures.Add(new Lecture
            {
                ModuleName = "DATABASE SYSTEMS FOR SOFTWARE APPLICATIONS",
                Lecturer = "Laurie Hirsch",
                Groups = "1, 2 and 3",
                IsDropIn = false,
                IsTutorial = true,
                Day = new DateTime(21, 01, 22),
                StartTime = new TimeSpan(12, 30, 0)
            });

            // Other friday section

            Lectures.Add(new Lecture
            {
                ModuleName = "FUNDAMENTALS OF PROGRAMMING LANGUAGES",
                Lecturer = "Chris Bates",
                Groups = "4, 5 and 6",
                IsDropIn = false,
                IsTutorial = true,
                Day = new DateTime(21, 01, 22),
                StartTime = new TimeSpan(13, 30, 0)
            });

            Lectures.Add(new Lecture
            {
                ModuleName = "SOFTWARE ENGINEERING: CONCEPTS AND METHODS",
                Lecturer = "Babak Khazaei",
                Groups = "4, 5 and 6",
                IsDropIn = false,
                IsTutorial = true,
                Day = new DateTime(21, 01, 22),
                StartTime = new TimeSpan(14, 30, 0)
            });

            Lectures.Add(new Lecture
            {
                ModuleName = "ALGORITHMS AND DATA STRUCTURES 2",
                Lecturer = "Jing Wang",
                Groups = "4, 5 and 6",
                IsDropIn = false,
                IsTutorial = true,
                Day = new DateTime(21, 01, 22),
                StartTime = new TimeSpan(15, 30, 0)
            });

            Lectures.Add(new Lecture
            {
                ModuleName = "DATABASE SYSTEMS FOR SOFTWARE APPLICATIONS",
                Lecturer = "Laurie Hirsch",
                Groups = "4, 5 and 6",
                IsDropIn = false,
                IsTutorial = true,
                Day = new DateTime(21, 01, 22),
                StartTime = new TimeSpan(16, 30, 0)
            });

        }

        public TimeSpan GetCurrentTime()
        {
            return new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
        }

    }
}
