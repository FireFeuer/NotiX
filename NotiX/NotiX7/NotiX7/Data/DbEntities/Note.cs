using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;

namespace NotiX7.Data.DbEntities;

public partial class Note : ObservableObject
{
    [ObservableProperty]
    private int id;

    [ObservableProperty]
    private string? title;

    [ObservableProperty]
    private string? text;

    [ObservableProperty]
    private DateTime firstDate;

    [ObservableProperty]
    private DateTime secondDate;

    [ObservableProperty]
    private int size;

    [ObservableProperty]
    private int color;

    [ObservableProperty]
    private int x;

    [ObservableProperty]
    private int y;



    public virtual ColorsCategory ColorNavigation { get; set; } = null!;
}
