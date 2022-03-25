using System.IO;
using System.IO.IsolatedStorage;
using System.Windows;

namespace Task4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            IsolatedStorageFile userStorage = IsolatedStorageFile.GetUserStoreForAssembly();
            IsolatedStorageFileStream userStream = new IsolatedStorageFileStream("UserSettings.set", FileMode.OpenOrCreate, userStorage);
            StreamReader reader = new StreamReader(userStream);
            string savedColor = reader.ReadLine();
            reader.Close();
            if (savedColor != null)
            {
                this.colorName.Content = savedColor;
                this.colorName.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(savedColor));
            }
        }

        private void colorBorderPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            this.colorName.Content = colorPicker.SelectedColor.Value;
            this.colorName.Background = new SolidColorBrush(colorPicker.SelectedColor.Value);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IsolatedStorageFile userStorage = IsolatedStorageFile.GetUserStoreForAssembly();
            IsolatedStorageFileStream userStream = new IsolatedStorageFileStream("UserSettings.set", FileMode.OpenOrCreate, userStorage);
            StreamWriter writer = new StreamWriter(userStream);
            writer.WriteLine(colorPicker.SelectedColor.Value);
            writer.Close();
        }
    }
}
