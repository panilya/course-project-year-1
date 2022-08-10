using System;
using System.Collections.Generic;
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
using kursova.fileProcessService;
using kursova.model;

namespace kursova
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void HomePanelButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Home();
        }

        private void DatabasePanelButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Database();
        }
    }
}
