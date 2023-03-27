using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NotiX7.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Collections.ObjectModel;

namespace NotiX7.ViewModels
{
    public partial class WindowViewModel : ObservableObject
    {

        bool post_note = false; // Если значение True то заметку можно разместить
        bool taking_note = false; // Возможность перемещения заметки
        Point _offsetPoint = new Point(0, 0);
        int size_note = 150;


        [ObservableProperty]
        private ObservableCollection<NOte> _items = new ObservableCollection<NOte>();

        [ObservableProperty]
        private string _s = "S";


        public WindowViewModel()
        {
            Items = new ObservableCollection<NOte>();

            NOte note = new NOte();


            note.PreviewMouseDown += Take_a_note;
            note.PreviewMouseMove += Move_a_note;
            note.PreviewMouseUp += Drop_a_note;

        }

        //Взяли заметку
        private void Take_a_note(object sender, MouseButtonEventArgs e)
        {
            taking_note = true;
            post_note = false;

            NOte note = (NOte)sender;
            Point posCursor = e.MouseDevice.GetPosition(Application.Current.MainWindow);
            _offsetPoint = new Point(
                    posCursor.X - Canvas.GetLeft(note),
                    posCursor.Y - Canvas.GetTop(note)
            );
            e.MouseDevice.Capture(note);
        }

        //Перемещяем заметку
        private void Move_a_note(object sender, MouseEventArgs e)
        {
            if (taking_note && e.LeftButton == MouseButtonState.Pressed)
            {
                Canvas.SetLeft(sender as NOte, Mouse.GetPosition(Application.Current.MainWindow).X - _offsetPoint.X);
                Canvas.SetTop(sender as NOte, Mouse.GetPosition(Application.Current.MainWindow).Y - _offsetPoint.Y);
            }
        }

        //Закрепляем заметку
        private void Drop_a_note(object sender, MouseButtonEventArgs e)
        {
            taking_note = false;
            e.MouseDevice.Capture(null);
        }

        [RelayCommand]
        private void AddNote()
        {
            post_note = true;
        }

        [RelayCommand]
        private void BoardMouseDown()
        {
            if (post_note)
            {
                NOte note = new NOte();
                //note.Width = size_note;
                //note.Height = size_note;

                Items.Add(note);
                Canvas.SetLeft(note, Mouse.GetPosition(Application.Current.MainWindow).X);
                Canvas.SetTop(note, Mouse.GetPosition(Application.Current.MainWindow).Y);


                note.PreviewMouseDown += Take_a_note;
                note.PreviewMouseMove += Move_a_note;
                note.PreviewMouseUp += Drop_a_note;



                post_note = false;
            }
        }
        [RelayCommand]
        private void SelectSize1()
        {
            size_note = 150;
        }
        [RelayCommand]
        private void SelectSize2()
        {
            MessageBox.Show(size_note.ToString());
            size_note = 200;
        }
        [RelayCommand]
        private void SelectSize3()
        {
            size_note = 250;
        }
    }
}
