using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;

namespace NotiX7.Models
{
    public partial class Note: ObservableObject
    {
        [ObservableProperty]
        private int id;

        [ObservableProperty]
        private string? title;

        [ObservableProperty]
        private string? content;

        [ObservableProperty]
        private DateTime firstDate;

        [ObservableProperty]
        private DateTime endDate;

        [ObservableProperty]
        private int size;

        [ObservableProperty]
        private int color;

        [ObservableProperty]
        private int x;

        [ObservableProperty]
        private int y;
    }
}