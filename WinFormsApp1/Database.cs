using MySql.Data.MySqlClient;
using System.Data;
using System.Reflection.PortableExecutable;
using System.Linq;
using System.Diagnostics;

namespace DemoProject
{
    internal class Database
    {
        private List<Student> _students;
        private List<Lecturer> _lecturers;
        private List<Course> _courses;
        private List<Enrolment> _enrolments;
        private List<Teaching> _teachings;

        public Database()
        {
            GetAllTables();
        }

        #region Convert contents of Database tables to Structs
        public void GetAllTables()
        {
            _students = GetStudents();
            _lecturers = GetLecturers();
            _courses = GetCourses();
            _enrolments = GetEnrolment();
            _teachings = GetTeaching();
        }

        /// <summary>
        /// Get all Students from the student table of the database
        /// </summary>
        /// <returns>List of Students</returns>
        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            MySqlDataReader reader = DatabaseConnection.Instance.Query("SELECT * FROM student;");
            while (reader.Read())
            {
                // Make sure all fields are not null
                if (reader.IsDBNull(0) || reader.IsDBNull(1) || reader.IsDBNull(2))
                    continue;

                int id = reader.GetInt32(0);
                string firstName = reader.GetString(1);
                string lastName = reader.GetString(2);

                Student student = new Student(id, firstName, lastName);
                students.Add(student);
            }
            return _students;
        }

        /// <summary>
        /// Get all Lecturers from the lecturer table of the database
        /// </summary>
        /// <returns>List of lecturer</returns>
        public List<Lecturer> GetLecturers()
        {
            List<Lecturer> lecturers = new List<Lecturer>();
            MySqlDataReader reader = DatabaseConnection.Instance.Query("SELECT * FROM lecturer;");
            while (reader.Read())
            {
                // Make sure all fields are not null
                if (reader.IsDBNull(0) || reader.IsDBNull(1) || reader.IsDBNull(2))
                    continue;

                int id = reader.GetInt32(0);
                string firstName = reader.GetString(1);
                string lastName = reader.GetString(2);

                Lecturer lecturer = new Lecturer(id, firstName, lastName);
                lecturers.Add(lecturer);
            }
            return lecturers;
        }

        /// <summary>
        /// Get all Courses from the course table of the database
        /// </summary>
        /// <returns>List of Courses</returns>
        public List<Course> GetCourses()
        {
            List<Course> courses = new List<Course>();
            MySqlDataReader reader = DatabaseConnection.Instance.Query("SELECT * FROM course;");
            while (reader.Read())
            {
                // Make sure all fields are not null
                if (reader.IsDBNull(0) || reader.IsDBNull(1) || reader.IsDBNull(2))
                    continue;

                int id = reader.GetInt32(0);
                string name = reader.GetString(1);

                Course course = new Course(id, name);
                courses.Add(course);
            }
            return courses;
        }
    
        /// <summary>
        /// Get all Enrolments from the enrolment table of the database
        /// </summary>
        /// <returns>List of Enrolments</returns>
        public List<Enrolment> GetEnrolment()
        {
            List<Enrolment> enrolments = new List<Enrolment>();
            MySqlDataReader reader = DatabaseConnection.Instance.Query("SELECT * FROM enrolment;");
            while (reader.Read())
            {
                // Make sure all fields are not null
                if (reader.IsDBNull(0) || reader.IsDBNull(1) || reader.IsDBNull(2))
                    continue;

                int enrolmentId = reader.GetInt32(0);
                int studentId = reader.GetInt32(1);
                int courseId = reader.GetInt32(2);

                Enrolment enrolment = new Enrolment(enrolmentId, studentId, courseId);
                enrolments.Add(enrolment);
            }
            return enrolments;
        }

        /// <summary>
        /// Get all Teachings from the teaching table of the database
        /// </summary>
        /// <returns>List of Teachings</returns>
        public List<Teaching> GetTeaching()
        {
            List<Teaching> teachings = new List<Teaching>();
            MySqlDataReader reader = DatabaseConnection.Instance.Query("SELECT * FROM teaching;");
            while (reader.Read())
            {
                // Make sure all fields are not null
                if (reader.IsDBNull(0) || reader.IsDBNull(1) || reader.IsDBNull(2))
                    continue;

                int teachingId = reader.GetInt32(0);
                int lecturerId = reader.GetInt32(1);
                int courseId = reader.GetInt32(2);

                Teaching teaching = new Teaching(teachingId, lecturerId, courseId);
                teachings.Add(teaching);
            }
            return teachings;
        }
        #endregion
    }

    #region Database tables as Structs
    public struct Student
    {
        public int Id;
        public string FirstName;
        public string LastName;

        public Student(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
    }

    public struct Lecturer
    {
        public int Id;
        public string FirstName;
        public string LastName;

        public Lecturer(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
    }

    public struct Course
    {
        public int Id;
        public string Name;

        public Course(int id, string firstName)
        {
            Id = id;
            Name = firstName;
        }
    }

    public struct Enrolment
    {
        public int EnrolmentId;
        public int StudentId;
        public int CourseId;

        public Enrolment(int enrolmentId, int studentId, int courseId)
        {
            EnrolmentId = enrolmentId;
            StudentId = studentId;
            CourseId = courseId;
        }
    }

    public struct Teaching
    {
        public int TeachingId;
        public int LecturerId;
        public int CourseId;

        public Teaching(int teachingId, int lecturerId, int courseId)
        {
            TeachingId = teachingId;
            LecturerId = lecturerId;
            CourseId = courseId;
        }
    }
    #endregion
}