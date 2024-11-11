﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Task_18_WebApi3.testdb.Models;

[Index("Author_id", Name = "IX_News_Author_id")]
[Index("ctg_id", Name = "IX_News_ctg_id")]
public partial class News
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string title { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public string brief { get; set; }

    public DateTime Dt { get; set; }

    public int ctg_id { get; set; }

    public int Author_id { get; set; }

    [ForeignKey("Author_id")]
    [InverseProperty("News")]
    public virtual Author Author { get; set; }

    [ForeignKey("ctg_id")]
    [InverseProperty("News")]
    public virtual Category ctg { get; set; }
}