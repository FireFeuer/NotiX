﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;

namespace NotiX7.Models
{
    public partial class Note: NoteDB
    {
        [ObservableProperty]
        private bool _isSelected = false;


        [RelayCommand]
        private void Selecting()
        {
            this.IsSelected= true;
            Debug.WriteLine(IsSelected.ToString());
        }

        [RelayCommand]
        private void Unselecting()
        {
            IsSelected =false;
            Debug.WriteLine(IsSelected.ToString());
        }

    }
}