using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NotiX7.Data.DbEntities;
using NotiX7.Models;
using NotiX7.Services;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace NotiX7.ViewModels
{
    public partial class WindowViewModel : ObservableObject
    {
        private readonly NoteService _noteService;
        private readonly ColorService _colorService;

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

        [ObservableProperty]
        private ObservableCollection<ColorsCategory> _colors;


        public WindowViewModel(NoteService noteService, ColorService colorService)
        {
            _noteService = noteService;
            _colorService = colorService;


            Items = new ObservableCollection<Note>();
            Items = _noteService.LoadNotesFromDb();

            Colors = _colorService.LoadNotAllColorsFromDb();
        }



        //Закрепляем заметку
        //Отпускаем заметку, здесь делаем сохранение
        [RelayCommand]
        private async void DropNote()
        {
            await _noteService.ChangeUploadingNotesToTheDb(SelectedNote);
            SelectedNote = null;

            foreach (Note note in Items)
            {
                note.IsSelected = false;
            }
            _isSelecting = false;
        }


        [RelayCommand]
        private void AddNote()
        {
            post_note = true;
        }


        // Добавление новой заметки
        [RelayCommand]
        private async void BoardMouseDown()
        {
            if (post_note)
            {
                Note note = new Note
                {
                    Id = Items.Count + 1,
                    X = (int)Mouse.GetPosition(Application.Current.MainWindow).X - 30,
                    Y = (int)Mouse.GetPosition(Application.Current.MainWindow).Y - 10,
                    ColorNavigation = new ColorsCategory { Hex = "#A86540" },
                    Color = 1,
                    Title = "",
                    Text = "",
                    FirstDate = "",
                    SecondDate = ""
                };
                Items.Add(note);
                post_note = false;


                await _noteService.AddUploadingNotesToTheDb(note);
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

        //Движение заметки внутри Canvas 
        [RelayCommand]
        private void MoveNote()
        {

            if (SelectedNote == null)
            {
                GetSelectedNote();
                _cursorPosition = Mouse.GetPosition(Application.Current.MainWindow);

                if (SelectedNote != null)
                {
                    _offsetPoint = new Point(
                      _cursorPosition.X - SelectedNote.X,
                       _cursorPosition.Y - SelectedNote.Y
                    );
                }
            }

            if (Items.Count > 0 && SelectedNote != null && SelectedNote.IsSelected == true)
            {
                //Debug.WriteLine((int)_offsetPoint.Y);
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
