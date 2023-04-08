using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;

namespace NotiX7.Data.DbEntities;

public partial class NoteDB : ObservableObject
{
    [ObservableProperty]
    private int id;

    [ObservableProperty]
    private string? title;

    [ObservableProperty]
    private string? text;

    [ObservableProperty]
    private string firstDate;

    [ObservableProperty]
    private string secondDate;

    [ObservableProperty]
    private int size;

    [ObservableProperty]
    private int color;

    [ObservableProperty]
    private int x;

    [ObservableProperty]
    private int y;

    [ObservableProperty]
    private int is_open;



    public virtual ColorsCategory ColorNavigation { get; set; } = null!;



}
