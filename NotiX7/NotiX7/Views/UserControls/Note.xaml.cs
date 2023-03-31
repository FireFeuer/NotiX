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

        private void StackPanel_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //expandCheckBox.IsChecked = !expandCheckBox.IsChecked;
        }

        public double X = 333;

        private void Border_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            Canvas.SetTop(this, Mouse.GetPosition(Application.Current.MainWindow).Y -100 );
            Canvas.SetLeft(this, Mouse.GetPosition(Application.Current.MainWindow).X -100);
        }
    }
}
