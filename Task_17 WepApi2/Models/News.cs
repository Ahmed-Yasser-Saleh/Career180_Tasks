using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Task_17_WepApi2.Models;

public partial class News
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Brief { get; set; } = null!;

    public DateTime Dt { get; set; }

    public int CtgId { get; set; }

    public int AuthorId { get; set; }
    [JsonIgnore]
    public virtual Author? Author { get; set; } = null!;
    [JsonIgnore]
    public virtual Category? Ctg { get; set; } = null!;
}
