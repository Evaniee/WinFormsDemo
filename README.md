An example Windows Forms Application demonstrating the ability to connect to a MySQL Server and to programatically create controls and handle events.
Server was hosted locally via [XAMPP](https://www.apachefriends.org/), see [MySQL Commands.sql](https://github.com/Evaniee/WinFormsDemo/blob/master/MySQL%20Commands.sql) for SQL commands to populate the database.

The database stores data on students, courses and lecturers.

```
Student 1:M Enrolment M:1 Course 1:M Teaching M:1 Lecturer
```

When running the program press the '*Refresh*' button to populate the combo box with the courses.  
Then you can select a course from the combo box, the students on the selected course will be displayed.  
Clicking any student displays their student ID.
