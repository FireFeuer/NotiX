using System.Windows;
using System.Windows.Controls;

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

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(nameof(Title), typeof(string), typeof(TextBlock));
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        private void border_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {


        }

        private void expandCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            //CheckBox checkBox = sender as CheckBox;

            //int oldSize = (int)contentStackPanel.Height;

            //if (checkBox.IsChecked == true)
            //{
            //    contentStackPanel.Height = 0;
            //}
            //if (checkBox.IsChecked == false)
            //{
            //    contentStackPanel.Height = oldSize;
            //}
        }
    }
}
