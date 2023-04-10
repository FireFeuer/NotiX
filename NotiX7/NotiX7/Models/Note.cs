using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NotiX7.Data.DbEntities;

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
            //Debug.WriteLine(IsSelected.ToString());
        }

        [RelayCommand]
        private void Unselecting()
        {
            this.IsSelected = false;
            //Debug.WriteLine(IsSelected.ToString());
        }

    }
}