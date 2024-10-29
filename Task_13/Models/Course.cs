using System;
using System.Collections.Generic;

namespace Task_13.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string Name { get; set; } = null!;

    public int? DeptId { get; set; }

    public virtual Department? Dept { get; set; }

    public virtual ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();

    public virtual ICollection<TraineeCourse> TraineeCourses { get; set; } = new List<TraineeCourse>();
}
