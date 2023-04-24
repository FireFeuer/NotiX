using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NotiX7.Data.DbEntities;
using NotiX7.Models;
using NotiX7.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using NotiX7.Views;
using Microsoft.Xaml.Behaviors.Core;

namespace NotiX7.ViewModels
{
    public partial class WindowViewModel : ObservableObject
    {
        private int items_count; // правильно считает id добавленной заметки с учётом всех удалённых заметок за сеанс

        private readonly NoteService _noteService;
        private readonly ColorService _colorService;

        bool post_note = false; // Если значение True то заметку можно разместить
        bool _isSelecting = false; // Возможность перемещения заметки
        Point _cursorPosition;
        Point _offsetPoint = new Point(0, 0);



        #region Свойства

        [ObservableProperty]
        private Note _selectedNote;


        [ObservableProperty]
        private ObservableCollection<Note> _items = new ObservableCollection<Note>();

        [ObservableProperty]
        private string _s = "S";

        [ObservableProperty]
        private ObservableCollection<ColorsCategory> _colors;

        [ObservableProperty]
        private ColorsCategory _selectedColor;

        [ObservableProperty]
        private Visibility createButtonMenuVisiblity = Visibility.Collapsed;

        [ObservableProperty]
        private Visibility _filterNotesMenuVisiblity = Visibility.Collapsed;

        [ObservableProperty]
        private int? _selectedNoteSize = null;

        [ObservableProperty]
        private ObservableCollection<ColorsCategory> _addedColors = new();

        [ObservableProperty]
        private ColorsCategory? _selectedFilterColor;

        #endregion



        public WindowViewModel(NoteService noteService, ColorService colorService)
        {
            _noteService = noteService;
            _colorService = colorService;


            Items = new ObservableCollection<Note>();
            Items = _noteService.LoadNotesFromDb();
            items_count = Items.Count;

            Colors = _colorService.LoadNotAllColorsFromDb();
            GetAddedColors();
        }


        #region Changed методы

        partial void OnSelectedFilterColorChanged(ColorsCategory? value)
        {
            UpdateItems();
            Debug.WriteLine("ABOBA");
        }



        #endregion



        #region Команды

        //Закрепляем заметку
        //Отпускаем заметку, здесь делаем сохранение
        [RelayCommand]
        private async void DropNote()
        {
            await _noteService.ChangeUploadingNotesToTheDb(SelectedNote);


            foreach (Note note in Items)
            {
                note.IsSelected = false;
            }
            _isSelecting = false;
        }


        [RelayCommand]
        private void AddNote()
        {
            if (post_note == false)
            {
                post_note = true;
                CreateButtonMenuVisiblity = Visibility.Visible;
                FilterNotesMenuVisiblity = Visibility.Collapsed;
                return;
            }
            else if (post_note == true)
            {
                post_note = false;
                CreateButtonMenuVisiblity = Visibility.Collapsed;
                return;
            }


        }


        // Добавление новой заметки
        [RelayCommand]
        private async void BoardMouseDown()
        {
            CreateButtonMenuVisiblity = Visibility.Collapsed;
            FilterNotesMenuVisiblity = Visibility.Collapsed;
            if (!post_note)
            {
                GetSelectedNote();
            }
            if (post_note && SelectedColor != null && SelectedNoteSize != null)
            {
                Note note = new Note
                {
                    Id = items_count + 1,
                    X = (int)Mouse.GetPosition(Application.Current.MainWindow).X - 30,
                    Y = (int)Mouse.GetPosition(Application.Current.MainWindow).Y - 10,
                    ColorNavigation = SelectedColor,
                    Title = "",
                    Text = "",
                    FirstDate = "",
                    SecondDate = "",
                    Z = InformationTransportation.MaxZ + 1,
                    Size = (int)SelectedNoteSize,
                    Is_delete = 0,
                };
                InformationTransportation.MaxZ = note.Z;
                Items.Add(note);
                post_note = false;
                await _noteService.AddUploadingNotesToTheDb(note);
                CreateButtonMenuVisiblity = Visibility.Collapsed;
                SelectedNoteSize = null;
                SelectedColor = null;
                GetAddedColors();
                items_count++;
            }
        }



        [RelayCommand]
        private void SelectSize1()
        {
            SelectedNoteSize = 170;
        }
        [RelayCommand]
        private void SelectSize2()
        {

            SelectedNoteSize = 235;
        }
        [RelayCommand]
        private void SelectSize3()
        {
            SelectedNoteSize = 320;
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

       

        [RelayCommand]
        private async void KeyUp()
        {
            MessageBox.Show("sad");
            if (SelectedNote != null)
            {
                NoteService noteService = new NoteService();
                await noteService.ChangeUploadingNotesToTheDb(SelectedNote);
            }
        }


        [RelayCommand]
        private void ClearFilterColor()
        {
            SelectedFilterColor = null;
        }


        [RelayCommand]
        private void FilterNotes()
        {
            FilterNotesMenuVisiblity = Visibility.Visible;
            CreateButtonMenuVisiblity = Visibility.Collapsed;
        }

        [RelayCommand]
        private async void DeleteNote()
        {
          
            NoteService noteService = new NoteService();
            await noteService.DeleteNotesFromTheDb(SelectedNote);
            Items.Remove(SelectedNote);
            GetAddedColors();
        }
       

        #endregion



        private void GetSelectedNote()
        {
            SelectedNote = Items.Where(i => i.IsSelected).SingleOrDefault();
        }

        private void GetAddedColors()
        {
            List<int> colorsIds = new List<int>();
            if (Items != null && Items.Count > 0 && Colors != null)
            {
                foreach (var item in Items)
                {
                    if (item != null)
                    {
                        colorsIds.Add(item.ColorNavigation.Id);
                    }

                }
            }

            List<int> uniqueColorsIds = colorsIds.Distinct().ToList();

            AddedColors.Clear();
            foreach (int item in uniqueColorsIds)
            {
                var color = Colors.Where(c => c.Id == item).SingleOrDefault();
                if (color != null)
                {
                    AddedColors.Add(color);
                }
            }
        }

        private void UpdateItems()
        {
            ObservableCollection<Note> notes = _noteService.LoadNotesFromDb();
            List<Note> filtredNotes = new List<Note>();

            if (SelectedFilterColor != null)
            {
                filtredNotes = notes.Where(n => n.ColorNavigation.Id == SelectedFilterColor.Id).ToList();
            }
            else
            {
                Items = _noteService.LoadNotesFromDb();
                return;
            }

            notes.Clear();

            foreach (Note note in filtredNotes)
            {
                notes.Add(note);
            }

            Items = notes;
        }

       
    }
}
