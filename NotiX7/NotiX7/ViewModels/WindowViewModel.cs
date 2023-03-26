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


        [ObservableProperty]
        private ObservableCollection<NOte> _items = new ObservableCollection<NOte>();

      


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
            Point posCursor = e.MouseDevice.GetPosition(note);
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
                Canvas.SetLeft(sender as NOte, Mouse.GetPosition(sender as NOte).X - _offsetPoint.X);
                Canvas.SetTop(sender as NOte, Mouse.GetPosition(sender as NOte).Y - _offsetPoint.Y);
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
                Items.Add(note);
                Canvas.SetLeft(note, 300);
                Canvas.SetTop(note, 60);


                note.PreviewMouseDown += Take_a_note;
                note.PreviewMouseMove += Move_a_note;
                note.PreviewMouseUp += Drop_a_note;



                post_note = false;
            }
        }
    }
}
