using System;
using System.Collections.Generic;

namespace Task_17_WepApi2.Models;

public partial class Author
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Brief { get; set; } = null!;

    public virtual ICollection<News> News { get; set; } = new List<News>();
}
