using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Input;

namespace NotiX7.Views.UserControls
{
    /// <summary>
    /// Логика взаимодействия для Note.xaml
    /// </summary>
    public partial class Note : UserControl
    {
        public Note()
        {
            InitializeComponent();
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("fefwefw");
        }
    }
}
