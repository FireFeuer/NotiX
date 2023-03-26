using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NotiX7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// Bkmz utq
    /// </summary>
    public partial class MainWindow : Window
    {
        bool post_note = false; // Если значение True то заметку можно разместить
        bool taking_note = false; // Возможность перемещения заметки
        Point _offsetPoint = new Point(0, 0);

        int size_note = 100;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Note_placement_button_Click(object sender, RoutedEventArgs e)
        {
            post_note = true;

        }

        private void Board_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (post_note)
            {
                // Заметка
                Border note = new Border
                {
                    Width = size_note,
                    Height = size_note,
                    Background = new SolidColorBrush(Color.FromRgb(59, 89, 152)), // Цвет заметки
                    BorderBrush = new SolidColorBrush(Colors.Black),
                    BorderThickness = new Thickness(1),
                    Padding = new Thickness(10),

                };

                //Grid с 3 строками
                Grid note_grid = new Grid();
                note_grid.RowDefinitions.Add(new RowDefinition());
                note_grid.RowDefinitions.Add(new RowDefinition());
                note_grid.RowDefinitions.Add(new RowDefinition());
                note_grid.RowDefinitions[0].Height = new GridLength(0.9, GridUnitType.Star);
                note_grid.RowDefinitions[1].Height = new GridLength(2, GridUnitType.Star);
                note_grid.RowDefinitions[2].Height = GridLength.Auto;

                //Дата
                TextBlock date = new TextBlock
                {
                    Text = DateTime.Now.ToString("d"),
                    Margin = new Thickness(0, 20, 0, 0),
                };


                //Контент, текст заметки
                Viewbox vb = new Viewbox
                {
                    Width = note.Width - 20,
                    //Height = note.Height - 20,
                };
                TextBox tb = new TextBox
                {
                    //Background = new SolidColorBrush(Colors.LightCoral),     // НЕ Правильный показатель               
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    BorderThickness = new Thickness(0),
                    TextWrapping = TextWrapping.Wrap,
                    MaxWidth = note.Width,
                    MaxLength = 170,
                    TextAlignment = TextAlignment.Center,
                    FontWeight = FontWeights.Light,
                    Background = new SolidColorBrush(Colors.Transparent),      // Правильный показатель               
                };
                //MessageBox.Show(vb.Width.ToString());


                //Заголовок
                Viewbox vb_Title = new Viewbox
                {
                    Width = note.Width - 20,
                    //Height = note.Height - 20,
                };
                TextBox tb_Title = new TextBox
                {
                    //Background = new SolidColorBrush(Colors.LightCoral),     // НЕ Правильный показатель    
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    BorderThickness = new Thickness(0, 0, 0, 1),
                    TextWrapping = TextWrapping.Wrap,


                    MaxWidth = note.Width,
                    MaxLength = 40,
                    TextAlignment = TextAlignment.Center,
                    Background = new SolidColorBrush(Colors.Transparent),      // Правильный показатель    
                    FontWeight = FontWeights.Bold,
                };


                note.Child = note_grid;

                // Добавление в grid заголовок, содержания и даты
                note_grid.Children.Add(vb);
                note_grid.Children.Add(vb_Title);
                note_grid.Children.Add(date);

                tb.MouseDown += TakeNote;

                Grid.SetRow(vb_Title, 0);
                Grid.SetRow(vb, 1);
                Grid.SetRow(date, 2);

                vb.Child = tb;
                vb_Title.Child = tb_Title;

                // Добавление на доску заметку
                Board.Children.Add(note);
                Canvas.SetLeft(note, Mouse.GetPosition(Board).X);
                Canvas.SetTop(note, Mouse.GetPosition(Board).Y);

                // Методы для перемещения заметки
                note.MouseDown += Take_a_note;
                note.MouseMove += Move_a_note;
                note.MouseUp += Drop_a_note;

                ContextMenu contextMenu = new ContextMenu();
                note.ContextMenu = contextMenu;
                MenuItem del = new MenuItem();
                del.Header = "Удалить";
                del.Click += Delete_a_note;
                MenuItem col = new MenuItem();
                col.Header = "Изменить цвет";
                MenuItem red = new MenuItem();
                red.Header = "";
                col.Items.Add(red);
                contextMenu.Items.Add(col);
                contextMenu.Items.Add(del);


                tb.Loaded += TextBox_Loaded;

                // Метод для изменения размера шрифта(не доделано)
                tb.TextChanged += Change_Font;

                post_note = false;
            }
        }

        private void TakeNote(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("asd");
        }

        //Взяли заметку
        private void Take_a_note(object sender, MouseButtonEventArgs e)
        {
            taking_note = true;
            post_note = false;

            Border note = sender as Border;

            Point posCursor = e.MouseDevice.GetPosition(this);
            _offsetPoint = new Point(
                    posCursor.X - Canvas.GetLeft(note),
                    posCursor.Y - Canvas.GetTop(note)
            );
            e.MouseDevice.Capture(note);
        }

        //Перемещяем заметку
        private void Move_a_note(object sender, MouseEventArgs e)
        {
            if (taking_note && e.LeftButton == MouseButtonState.Pressed)
            {
                Border note = sender as Border;
                Canvas.SetLeft(note, Mouse.GetPosition(this).X - _offsetPoint.X);
                Canvas.SetTop(note, Mouse.GetPosition(this).Y - _offsetPoint.Y);
            }
        }

        //Закрепляем заметку
        private void Drop_a_note(object sender, MouseButtonEventArgs e)
        {
            taking_note = false;
            e.MouseDevice.Capture(null);
        }

        private void TextBox_Loaded(object sender, RoutedEventArgs e)
        {
            Keyboard.Focus(sender as TextBox);
        }

        //Выбор размера заметки
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            if (menuItem.Header.ToString() == "S")
                size_note = 150;    // Маленький 
            else if (menuItem.Header.ToString() == "M")
                size_note = 200;    // Средний
            else if (menuItem.Header.ToString() == "L")
                size_note = 250;    // Большой

        }

        private void Delete_a_note(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            ContextMenu contextMenu = (ContextMenu)menuItem.Parent;

            Border note = (Border)contextMenu.PlacementTarget;
            Board.Children.Remove(note);

        }

        private void Change_Font(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            Viewbox viewbox = (Viewbox)tb.Parent;
            //MessageBox.Show(viewbox.Width.ToString());

            //if (tb.LineCount > 1)
            //{

            //}
        }

        private void HeaderTextBox_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //TextBox textBox = (TextBox)sender;
            //textBox.IsReadOnly = false;
            //textBox.Focus();
        }

        private void HeaderTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            //TextBox textBox = (TextBox)sender;
            //textBox.IsReadOnly= true;
        }

        private void TextBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("sadasd");

        }

    }
}
