﻿using CommunityToolkit.Mvvm.ComponentModel;

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

    [ObservableProperty]
    private int is_delete;

    [ObservableProperty]
    private int z;


    public virtual ColorsCategory ColorNavigation { get; set; } = null!;



}
