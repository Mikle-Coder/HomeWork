using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.IO;
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

namespace Task_4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            button.Click += ButtonClick;
            colorPicker.SelectedColorChanged += ColorPick;
            this.Loaded += OnLoad;
        }

        private void ColorPick(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            string text = $"Выбран цвет '{colorPicker.SelectedColorText}'";
            ChangeLabel(text, (Color)e.NewValue);
        }

        private void ChangeLabel(string text,Color newColor)
        {
            label.Content = text;
            label.Background = new SolidColorBrush(newColor);
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            if (colorPicker.SelectedColor != null)
            {
                SaveColor();
            }
        }

        private void SaveColor()
        {
            IsolatedStorageFile userStorage = IsolatedStorageFile.GetUserStoreForAssembly();

            // Создание файлового потока с указанием: Имени файла, FileMode, объекта хранилища.
            IsolatedStorageFileStream userStream = new IsolatedStorageFileStream("UserSettings.set", FileMode.Create, userStorage);

            //   StreamWriter - запись данных в поток userStream.
            StreamWriter userWriter = new StreamWriter(userStream);
            userWriter.WriteLine(colorPicker.SelectedColor);
            userWriter.Close();
            userStream.Close();
            label.Content = string.Format("Я запонмил цвет '{0}'", colorPicker.SelectedColorText);
        }

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            IsolatedStorageFile userStorage = IsolatedStorageFile.GetUserStoreForAssembly();

            // Открытие файлового потока с указанием: Имени файла, FileMode, объекта хранилища.
            IsolatedStorageFileStream userStream = new IsolatedStorageFileStream("UserSettings.set", FileMode.OpenOrCreate, userStorage);

            // StreamWriter - чтение данных из потока userStream.
            StreamReader userReader = new StreamReader(userStream);

            string color = userReader.ReadToEnd();
            userReader.Close();
            userStream.Close();

            var bc = new BrushConverter();
            if (!string.IsNullOrEmpty(color))
            {
                label.Background = (Brush)bc.ConvertFromString(color);
            }
        }
    }
}
