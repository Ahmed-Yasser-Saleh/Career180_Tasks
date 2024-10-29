using System;
using System.Collections.Generic;

namespace Task_13.Models;

public partial class Department
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();

    public virtual ICollection<Trainee> Trainees { get; set; } = new List<Trainee>();
}
