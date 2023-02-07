﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.StudentManagement.Models;
using Library.StudentManagement.Services;

namespace App.StudentManagement.Helpers
{
    public class CourseHelper
    {
        private CourseService courseService = new CourseService();
        private StudentService studentService;

        public CourseHelper()
        {
            this.studentService = StudentService.Current;
        }

        public List<Person> Persons
        {
            get
            {
                return studentService.studentList.ToList();
            }
        }

        public void CreateCourse(Course? selectedCourse = null)
        {

            Console.WriteLine("Enter the course name:");
            var name = Console.ReadLine();
            Console.WriteLine("Enter the course description:");
            var classification = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Enter the course code:");
            var courseCode = Console.ReadLine() ?? string.Empty;
            while (courseService.Courses.Any(c => c.Code == courseCode))
            {
                Console.WriteLine("Please re-enter a unique course code:");
                classification = Console.ReadLine() ?? string.Empty;
            }

            var roster = new List<Person>();
            Console.WriteLine("Which students should be entrolled in this course? (Enter numeric ID || Q to exit)");
            bool contAdd = true;
            while (contAdd)
            {
                studentService.studentList.ToList().Where(s => !roster.Any(s2 => s2.Id == s.Id)).ToList().ForEach(Console.WriteLine);
                var selection = Console.ReadLine() ?? string.Empty;

                if (selection == "q" || selection == "Q")
                {
                    contAdd = false;
                }
                else
                {
                    var selectedID = int.Parse(selection);
                    var selectedStudent = studentService.Students.FirstOrDefault(s => s.Id == selectedID);

                    if (selectedStudent != null)
                    {
                        roster.Add(selectedStudent);
                    }
                }
            }

            bool isCreated = false;
            if (selectedCourse == null)
            {
                selectedCourse = new Course();
                isCreated = true;
            };

            selectedCourse.Name = name ?? string.Empty;
            selectedCourse.Description = classification;
            selectedCourse.Code = courseCode;
            selectedCourse.Roster = new List<Person>();
            selectedCourse.Roster.AddRange(roster);

            if (isCreated)
            {
                courseService.Add(selectedCourse);
            }

        }

        public void ListAllCourses()
        {
            courseService.Courses.ForEach(Console.WriteLine);
        }

        public void SearchCourse()
        {
            Console.WriteLine("Enter a query:");
            var query = Console.ReadLine() ?? string.Empty;

            foreach (var course in courseService.Search(query))
            {
                Console.WriteLine(course);
                Console.WriteLine("Roster:");
                foreach (var person in course.Roster)
                {
                    Console.WriteLine("  " + person);
                }
            }
        }

        public void UpdateCourse()
        {
            Console.WriteLine("Now listing all course:");
            courseService.Courses.ForEach(Console.WriteLine);
            Console.WriteLine("Please enter the code for the course you'd like to update (numeric values only):");

            var selection = Console.ReadLine();

            if (int.TryParse(selection, out int selectionInt))
            {
                var selectedCourse = courseService.Courses.FirstOrDefault(s => s.Code == selectionInt.ToString());
                if (selectedCourse != null)
                {
                    CreateCourse(selectedCourse);
                }
            }

        }

        public void RemoveStudent()
        {
            Console.WriteLine("Now listing all courses:");
            courseService.Courses.ForEach(Console.WriteLine);
            Console.WriteLine("Please enter the code for the course from which you'd like to remove a student (numeric values only):");

            var courseSelection = Console.ReadLine();

            if (int.TryParse(courseSelection, out int courseSelectionInt))
            {
                var selectedCourse = courseService.Courses.FirstOrDefault(c => c.Code == courseSelectionInt.ToString());
                if (selectedCourse != null)
                {
                    Console.WriteLine("Now listing all students enrolled in this course:");
                    selectedCourse.Roster.ForEach(Console.WriteLine);
                    Console.WriteLine("Please enter the ID of the student you'd like to remove (numeric values only):");

                    var studentSelection = Console.ReadLine();

                    if (int.TryParse(studentSelection, out int studentSelectionInt))
                    {
                        var selectedStudent = studentService.Students.FirstOrDefault(s => s.Id == studentSelectionInt);
                        if (selectedStudent != null)
                        {
                            selectedCourse.Roster.Remove(selectedStudent);
                            Console.WriteLine("Student successfully removed from the course.");
                        }
                        else
                        {
                            Console.WriteLine("Student not found.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Course not found.");
                }
            }
        }

    }
}

