using DemoProject;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private List<Tuple<Student,Label>> _studentInfo; // Stores all labels of student info
        
        public Form1()
        {
            _studentInfo = new List<Tuple<Student,Label>>();
            InitializeComponent();
        }

        /// <summary>
        /// Refresh cmb_course's items on click
        /// </summary>
        private void btn_refresh_Click(object sender, EventArgs e)
        {
            // Clear combo boxes current options
            cmb_course.Items.Clear();
            
            // Exit if cannot connect
            if (!DatabaseConnection.Instance.Open())
                return;

            // Populate combo box
            cmb_course.Items.AddRange(DatabaseConnection.Instance.GetCourseNames().ToArray());
            
            // Close connection
            DatabaseConnection.Instance.Close();

            // Clear cmb_course
            cmb_course.Text = string.Empty;

            // Remove all existing student labels
            while (_studentInfo.Count > 0)
            {
                this.Controls.Remove(_studentInfo[0].Item2);
                _studentInfo.Remove(_studentInfo[0]);
            }
        }

        /// <summary>
        /// Show students on course when selected index of cmb_course is changed
        /// </summary>
        private void cmb_course_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Remove all existing student labels
            while (_studentInfo.Count > 0)
            {
                this.Controls.Remove(_studentInfo[0].Item2);
                _studentInfo.Remove(_studentInfo[0]);
            }

            // Exit if no selected item
            if (cmb_course.SelectedItem == null)
                return;

            // Exit if cannot connect
            if (!DatabaseConnection.Instance.Open())
                return;

            // Get students from DB
            string course = cmb_course.SelectedItem.ToString();
            List<Student> students = DatabaseConnection.Instance.GetStudentsOnCourse(course);

            // Populate form with a label for each student
            for(int i = 0; i < students.Count; i++)
            {
                Label studentLabel = new Label();
                studentLabel.AutoSize = true;
                studentLabel.Location = new Point(15, 75 + (23  * i));
                studentLabel.Text = students[i].FirstName + " " + students[i].LastName;
                Controls.Add(studentLabel);
                _studentInfo.Add(new Tuple<Student,Label>(students[i],studentLabel));
                studentLabel.Click += lbl_student_Click;
            }

            // Close Database Connection
            DatabaseConnection.Instance.Close();
        }
    
        /// <summary>
        /// Show students ID when student's label is clicked
        /// </summary>
        private void lbl_student_Click(object sender, EventArgs e)
        {
            // Find all items in _studentInfo that match sender
            IEnumerable<Tuple<Student, Label>> matches = _studentInfo.Where(x => x.Item2 == sender);

            // If unique match found
            if (matches.Count() == 1)
            {
                // Extract sender
                Tuple<Student, Label> info = matches.ElementAt(0);

                // Display sender's id
                MessageBox.Show(info.Item1.Id.ToString());
            }
        }
    }
}