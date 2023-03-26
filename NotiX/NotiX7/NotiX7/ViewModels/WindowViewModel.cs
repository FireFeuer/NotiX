using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace NotiX7.ViewModels
{
    public partial class WindowViewModel : ObservableObject
    {

        [ObservableProperty]
        private List<string> _items = new List<string>();

      


        public WindowViewModel()
        {
            Items= new List<string>() { "ewfwef"};
           
        }
    }
}
