using System;
using System.Collections.Generic;

namespace Task_13.Models;

public partial class Trainee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? Age { get; set; }

    public string? Grade { get; set; }

    public string? Address { get; set; }

    public int? Deptid { get; set; }

    public virtual Department? Dept { get; set; }

    public virtual ICollection<TraineeCourse> TraineeCourses { get; set; } = new List<TraineeCourse>();
    public override string ToString()
    {
        return $"Name: {Name} - ID: {Id} - Age: {Age}";
    }
}
