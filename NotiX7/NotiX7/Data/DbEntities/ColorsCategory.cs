using System;
using System.Collections.Generic;

namespace NotiX7;

public partial class ColorsCategory
{
    public long Id { get; set; }

    public string? Text { get; set; }

    public string? Hex { get; set; }

    public virtual ICollection<Note> Notes { get; } = new List<Note>();
}
