﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Task_18_WebApi3.Models.Course;

[Table("Course")]
public partial class Course
{
    [Key]
    public int ID { get; set; }

    [StringLength(50)]
    public string Name { get; set; }

    [StringLength(150)]
    public string Description { get; set; }

    public int? Duration { get; set; }
}