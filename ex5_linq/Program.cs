using System;
using System.Collections.Generic;
using System.Linq;

namespace ex5_linq
{
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
        public string Major { get; set; }
        public double Tuition { get; set; }
    }

    public class StudentClubs
    {
        public int StudentID { get; set; }
        public string ClubName { get; set; }
    }

    public class StudentGPA
    {
        public int StudentID { get; set; }
        public double GPA { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {

            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "Frank Furter", Age = 55, Major="Hospitality", Tuition=3500.00} ,
                new Student() { StudentID = 2, StudentName = "Gina Host", Age = 21, Major="Hospitality", Tuition=4500.00 } ,
                new Student() { StudentID = 3, StudentName = "Cookie Crumb",  Age = 21, Major="CIT", Tuition=2500.00 } ,
                new Student() { StudentID = 4, StudentName = "Ima Script",  Age = 48, Major="CIT", Tuition=5500.00 } ,
                new Student() { StudentID = 5, StudentName = "Cora Coder",  Age = 35, Major="CIT", Tuition=1500.00 } ,
                new Student() { StudentID = 6, StudentName = "Ura Goodchild" , Age = 40, Major="Marketing", Tuition=500.00} ,
                new Student() { StudentID = 7, StudentName = "Take Mewith" , Age = 29, Major="Aerospace Engineering", Tuition=5500.00 }
            };

            IList<StudentGPA> studentGPAList = new List<StudentGPA>() {
                new StudentGPA() { StudentID = 1,  GPA=4.0} ,
                new StudentGPA() { StudentID = 2,  GPA=3.5} ,
                new StudentGPA() { StudentID = 3,  GPA=2.0 } ,
                new StudentGPA() { StudentID = 4,  GPA=1.5 } ,
                new StudentGPA() { StudentID = 5,  GPA=4.0 } ,
                new StudentGPA() { StudentID = 6,  GPA=2.5} ,
                new StudentGPA() { StudentID = 7,  GPA=1.0 }
            };

            IList<StudentClubs> studentClubList = new List<StudentClubs>() {
                new StudentClubs() {StudentID=1, ClubName="Photography" },
                new StudentClubs() {StudentID=1, ClubName="Game" },
                new StudentClubs() {StudentID=2, ClubName="Game" },
                new StudentClubs() {StudentID=5, ClubName="Photography" },
                new StudentClubs() {StudentID=6, ClubName="Game" },
                new StudentClubs() {StudentID=7, ClubName="Photography" },
                new StudentClubs() {StudentID=3, ClubName="PTK" },
            };

            var query1 = studentGPAList.GroupBy(s => s.GPA)
            .Select(g => new { GPA = g.Key, StudentIDs = string.Join(", ", g.Select(s => s.StudentID)) });
            
            Console.WriteLine("Group by GPA and display the student's IDs:");
            foreach (var item in query1)
            {
            Console.WriteLine($"GPA: {item.GPA}, StudentIDs: {item.StudentIDs}");
            }

            
            var query2 = studentClubList.OrderBy(s => s.ClubName)
            .GroupBy(s => s.ClubName)
            .Select(g => new { ClubName = g.Key, StudentIDs = string.Join(", ", g.Select(s => s.StudentID)) });
            
            Console.WriteLine("\nSort by Club, then group by Club and display the student's IDs:");
            foreach (var item in query2)
            {
            Console.WriteLine($"ClubName: {item.ClubName}, StudentIDs: {item.StudentIDs}");
            }

            var query3 = studentGPAList.Count(s => s.GPA >= 2.5 && s.GPA <= 4.0);
            Console.WriteLine($"\nNumber of students with a GPA between 2.5 and 4.0: {query3}");

            var query4 = studentList.Average(s => s.Tuition);
            Console.WriteLine($"\nAverage all student's tuition: {query4}");

            var highestTuition = studentList.Max(s => s.Tuition);
            var highestTuitionStudent = studentList.FirstOrDefault(s => s.Tuition == highestTuition);
            Console.WriteLine($"\nStudent paying the most tuition:");
            Console.WriteLine($"Name: {highestTuitionStudent.StudentName}, Major: {highestTuitionStudent.Major}, Tuition: {highestTuitionStudent.Tuition}");


            var query5 = from s in studentList
            join g in studentGPAList on s.StudentID equals g.StudentID
            select new { s.StudentName, s.Major, g.GPA };

            Console.WriteLine("\nJoin the student list and student GPA list and display the student's name, major, and GPA:");
            foreach (var item in query5)
            {
            Console.WriteLine($"Name: {item.StudentName}, Major: {item.Major}, GPA: {item.GPA}");
            }

            var query6 = from s in studentList
            join c in studentClubList on s.StudentID equals c.StudentID
            where c.ClubName == "Game"
            select s.StudentName;

            Console.WriteLine("\nNames of students who are in the Game club:");
            foreach (var name in query6)
            {
                Console.WriteLine(name);
            }
        }
    }
}