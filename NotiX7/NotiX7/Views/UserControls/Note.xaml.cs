using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

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
            CheckBox checkBox = sender as CheckBox;


            DoubleAnimation heightAnimation = new DoubleAnimation();
            heightAnimation.Duration = TimeSpan.FromMilliseconds(170);

            if (contentStackPanel.Height == 0)
            {
                heightAnimation.From = 0;
                heightAnimation.To = border.Width - 100;
                contentStackPanel.BeginAnimation(StackPanel.HeightProperty, heightAnimation);
                return;
            }
            if (contentStackPanel.Height > 0)
            {
                heightAnimation.From = contentStackPanel.Height;
                heightAnimation.To = 0;
                contentStackPanel.BeginAnimation(StackPanel.HeightProperty, heightAnimation);
                return;
            }




        }

        private void NoteUserControl_PreviewMouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.ContextMenu.IsOpen = true;
        }
    }
}
