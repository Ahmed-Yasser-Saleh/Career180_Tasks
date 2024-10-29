using System;
using System.Collections.Generic;

namespace Task_13.Models;

public partial class Instructor
{
    public int InstructorId { get; set; }

    public string Name { get; set; } = null!;

    public int? Age { get; set; }

    public int? Salary { get; set; }

    public int? CourseId { get; set; }

    public int? Deptid { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Department? Dept { get; set; }
}
