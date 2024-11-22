using MySql.Data.MySqlClient;

namespace DemoProject
{
    internal class DatabaseConnection
    {
        private const string CONNECTION_STRING =    // Connection string for MySQL connection
            "server=127.0.0.1;" +
            "database=exampledb;" +
            "uid=root";

        private MySqlConnection? _connection;

        /// <summary>
        /// Setup the DatabaseConnection
        /// </summary>
        private DatabaseConnection() { }

        #region Singleton Pattern
        private static DatabaseConnection _instance;
        
        /// <summary>
        /// Get the current instance of the Database Connection singleton
        /// </summary>
        public static DatabaseConnection Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DatabaseConnection();
                return _instance;
            }
            private set { }
        }
        #endregion

        #region Generic Commands

        /// <summary>
        /// Open the connection
        /// </summary>
        /// <returns>True if successful otherwise false</returns>
        public bool Open()
        {
            // Close connection if not already closed
            if (_connection != null)
            {
                Close();
            }

            // Try to open connection
            _connection = new MySqlConnection(CONNECTION_STRING);
            try
            {
                _connection.Open();
                if (!_connection.Ping())
                {
                    MessageBox.Show("Error: Connection unsuccessful!");
                    return false;
                }
                return true;
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error (" + e.Number + "): " + e.Message);
                return false;
            }
        }

        /// <summary>
        /// Close the connection
        /// </summary>
        public void Close()
        {
            if (_connection != null)
            {
                _connection.Close();
                _connection = null;
            }
        }

        /// <summary>
        /// Run a non-query MySQL command
        /// </summary>
        /// <param name="sql">Non-query MySQL command to run</param>
        public void NonQuery(string sql)
        {
            MySqlCommand cmd = new MySqlCommand(sql, _connection);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Run a MySQL query
        /// </summary>
        /// <param name="sql">MySQL Query to run</param>
        /// <returns>MySqlDataReader object containing results of query</returns>
        public MySqlDataReader Query(string sql)
        {
            MySqlCommand cmd = new MySqlCommand(sql, _connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        #endregion

        #region Used Queries
        /// <summary>
        /// Get all Students on a given course
        /// </summary>
        /// <param name="courseName">Course name to find students on</param>
        /// <returns>List of students on given course</returns>
        public List<Student> GetStudentsOnCourse(string courseName)
        {
            List<Student> students = new List<Student>();

            string sql = "SELECT Student.StudentID, Student.FirstName, Student.LastName FROM Enrolment " +
                         "INNER JOIN Course ON Enrolment.CourseID = Course.CourseID " +
                         "INNER JOIN Student ON Enrolment.StudentID = Student.StudentID " +
                         "WHERE Course.Name = '" + courseName + "';";

            MySqlDataReader result = Query(sql);

            while(result.Read())
            {
                int studentId = result.GetInt32(0);
                string firstName = result.GetString(1);
                string lastName = result.GetString(2);

                Student student = new Student(studentId, firstName, lastName);
                students.Add(student);
            }

            return students;
        }

        /// <summary>
        /// Get the names of every course
        /// </summary>
        /// <returns>List of names of every course</returns>
        public List<string> GetCourseNames()
        {
            List<string> courseNames = new List<string>();

            string sql = "SELECT Course.Name FROM Course ORDER BY Course.Name ASC";

            MySqlDataReader result = Query(sql);

            while (result.Read())
                courseNames.Add(result.GetString(0));

            return courseNames;
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

#region Unused Example Queries
/*
/// <summary>
/// Get all Students from the student table of the database
/// </summary>
/// <returns>List of Students</returns>
public List<Student> GetAllStudents()
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
    return students;
}

/// <summary>
/// Get all Lecturers from the lecturer table of the database
/// </summary>
/// <returns>List of lecturer</returns>
public List<Lecturer> GetAllLecturers()
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
public List<Course> GetAllCourses()
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
public List<Enrolment> GetAllEnrolment()
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
public List<Teaching> GetAllTeaching()
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
*/
#endregion
