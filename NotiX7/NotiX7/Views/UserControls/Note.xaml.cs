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

        private void StackPanel_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            expandCheckBox.IsChecked = !expandCheckBox.IsChecked;
        }
    }
}
