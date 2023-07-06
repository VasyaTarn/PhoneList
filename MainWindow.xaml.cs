using System.Windows;

namespace PhoneListMVVM
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new AppVM();
            // пример добавления элемента через команды: https://metanit.com/sharp/wpf/22.3.php
        }
    }
}