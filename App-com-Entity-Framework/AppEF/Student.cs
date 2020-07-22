using Microsoft.EntityFrameworkCore;
using System;

public class Student
{
    
    public int StudentId { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime BirthDate { get; set; }

    public int CourseId { get; set; }
    public Course Course { get; set; }

    public override string ToString()
    {
        return "Student Name: " + Name + " Phone Number: " + PhoneNumber + " Birth Date: " + BirthDate;
    }
}

