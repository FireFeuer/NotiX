using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace NotiX7.Views.UserControls
{
    /// <summary>
    /// Логика взаимодействия для NOte.xaml
    /// </summary>
    public partial class NOte : UserControl
    {
        public NOte()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(nameof(Title),typeof(string),typeof(TextBlock)); 
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
       
    }
}
