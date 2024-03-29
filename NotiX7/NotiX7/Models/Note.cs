﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NotiX7.Data.DbEntities;
using NotiX7.Services;
using System;
using System.Windows;
using System.Windows.Controls;

namespace NotiX7.Models
{
    public partial class Note : NoteDB
    {
        [ObservableProperty]
        private bool _isSelected = false;

      

        [RelayCommand]
        private void Selecting()
        {
            this.IsSelected = true;
            Z = InformationTransportation.MaxZ+1;
            InformationTransportation.MaxZ = Z;
        }

        [RelayCommand]
        private void Unselecting()
        {
            this.IsSelected = false;
            //Debug.WriteLine(IsSelected.ToString());
            
        }

     

    }
}