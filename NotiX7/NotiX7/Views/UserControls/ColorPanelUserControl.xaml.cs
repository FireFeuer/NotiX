using System.Windows.Controls;
using System.Windows.Input;

namespace NotiX7.Views.UserControls
{
    /// <summary>
    /// Логика взаимодействия для ColorPanelUserControl.xaml
    /// </summary>
    public partial class ColorPanelUserControl : UserControl
    {
        public ColorPanelUserControl()
        {
            InitializeComponent();





        }


        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void scrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta / 4);
            e.Handled = true;
        }
    }
}
