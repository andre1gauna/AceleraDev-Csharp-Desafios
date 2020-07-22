using System.Collections.Generic;
public class Course
{
    
    public int CourseId { get; set; }
    public string CourseName { get; set; }

    public virtual ICollection<Student> Students { get; set; }

    public override string ToString()
    {
        return "Course Name: " + CourseName;
    }

}