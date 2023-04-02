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
using System.Diagnostics;
using NotiX7.Models;
using NotiX7.Data.DbEntities;
using NotiX7.Services;
using NotiX7.Data;

namespace NotiX7.ViewModels
{
    public partial class WindowViewModel : ObservableObject
    {

        bool post_note = false; // Если значение True то заметку можно разместить
        bool _isSelecting = false; // Возможность перемещения заметки
        Point _cursorPosition;
        Point _offsetPoint = new Point(0, 0);
        int size_note = 150;

        [ObservableProperty]
        private Note _selectedNote;


        [ObservableProperty]
        private ObservableCollection<Note> _items = new ObservableCollection<Note>();

        [ObservableProperty]
        private string _s = "S";


        public WindowViewModel()
        {
            
            using(NotixDbContext db = new NotixDbContext())
            {
                Items = new ObservableCollection<Note>();
                
                Microsoft.EntityFrameworkCore.DbSet<NoteDB> notes = db.Notes;

                //LoadFromDb_Class loadFromDb_Class = new LoadFromDb_Class();
                //notes = loadFromDb_Class.LoadFromDb_Method();
                Debug.WriteLine(notes.Count());
                foreach (NoteDB note in notes)
                {
                    Note addedNote = new Note
                    {
                        X = note.X,
                        Y = note.Y,
                        Title = note.Title,
                        Text = note.Text,
                        FirstDate = note.FirstDate,
                        SecondDate = note.SecondDate,
                        ColorNavigation = new ColorsCategory { Hex = "#0600D6" }
                    };
                    Debug.WriteLine("sdaaaaa212");
                    Items.Add(addedNote);
                }
            }
            
        }

        //Взяли заметку
        [RelayCommand]
        private void Take_a_note()
        {
            
            post_note = false;        
        }



        //Закрепляем заметку
        [RelayCommand]
        private void Drop_a_note()
        {
            SelectedNote = null;   
            _isSelecting = false;
        }


        [RelayCommand]
        private void AddNote()
        {
            post_note = true;
        }

        [RelayCommand]
        private void BoardMouseDown()
        {
            
            if (Items.Count > 0)
            {
                Debug.WriteLine(Items[0].IsSelected.ToString());
            }
            if (post_note)
            {
                Note note = new Note { X = (int)Mouse.GetPosition(Application.Current.MainWindow).X - 30,
                    Y = (int)Mouse.GetPosition(Application.Current.MainWindow).Y - 10,
                    Title = "Какая то хрень",
                    Text = $"ДАААААААААААА\nЭТО ГОВНО НАКОНЕЦ ТО\nРАБОТАЕТ СУКА",
                    FirstDate = DateTime.Now.ToString(),
                    SecondDate = DateTime.Now.AddDays(12).ToString(),
                    ColorNavigation = new ColorsCategory { Hex = "#0600D6" }
                };
                

                Items.Add(note);
               

                post_note = false;
            }
        }

        private void ChangeText(object sender, MouseButtonEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Focus();
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


        //Движение заметки внутри Canvas 
        [RelayCommand]
        private void MoveNote()
        {
            
            if (SelectedNote == null)
            {
                GetSelectedNote();
                _cursorPosition = Mouse.GetPosition(Application.Current.MainWindow);

                if(SelectedNote!= null)
                {
                    _offsetPoint = new Point(
                      _cursorPosition.X - SelectedNote.X,
                       _cursorPosition.Y - SelectedNote.Y
               );
                }
               
            }

            if (Items.Count > 0 && SelectedNote != null && SelectedNote.IsSelected == true)
            {

                Debug.WriteLine((int)_offsetPoint.Y);
                SelectedNote.Y = (int)Mouse.GetPosition(Application.Current.MainWindow).Y - (int)_offsetPoint.Y;
                SelectedNote.X = (int)Mouse.GetPosition(Application.Current.MainWindow).X - (int)_offsetPoint.X;
              
            }
            
        }

        private void GetSelectedNote()
        {
            SelectedNote = Items.Where(i => i.IsSelected).SingleOrDefault();
        }
    }
}
