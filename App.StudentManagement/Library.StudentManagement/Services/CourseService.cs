using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.StudentManagement.Models;

namespace Library.StudentManagement.Services
{
    public class CourseService
    {
        public List<Course> courseList = new List<Course>();

        private static CourseService? _instance;

        public static CourseService Current
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CourseService();
                }

                return _instance;
            }
        }

        private CourseService()
        {
            courseList = new List<Course>();
        }

        public void Add(Course course)
        {
            courseList.Add(course);
        }

        public List<Course> Courses
        {
            get { return courseList; }
        }

        public IEnumerable<Course> Search(string query)
        {
            return courseList.Where(s => s.Code.ToUpper().Contains(query.ToUpper())
                             || s.Name.ToUpper().Contains(query.ToUpper()));
        }

    }
}
