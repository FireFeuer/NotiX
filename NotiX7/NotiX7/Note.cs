using System;
using System.Collections.Generic;

namespace NotiX7;

public partial class Note
{
    public Note(long color, string? title, string? text, string? firstDate, string? secondDate, double x, double y, long size)
    {  
        Color = color;
        Title = title;
        Text = text;
        FirstDate = firstDate;
        SecondDate = secondDate;
        X = x;
        Y = y;
        Size = size;
    }

    public long Id { get; set; }

    public long Color { get; set; }

    public string? Title { get; set; }

    public string? Text { get; set; }

    public string? FirstDate { get; set; }

    public string? SecondDate { get; set; }

    public double X { get; set; }

    public double Y { get; set; }

    public long Size { get; set; }

   
}
