using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Windows;

namespace NotiX7.ViewModels
{
    public partial class WindowViewModel : ObservableObject
    {

        [ObservableProperty]
        private List<string> _items = new List<string>();




        public WindowViewModel()
        {
            Items = new List<string>() { "ewfwef" };

        }


        [RelayCommand]
        private void CloseWindow()
        {
            Application.Current.Shutdown();
        }

        [RelayCommand]
        private void MinimizeWindow()
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        [RelayCommand]
        private void MaximizeWindow()
        {

            Application.Current.MainWindow.WindowState = WindowState.Maximized;
        }

    }
}
