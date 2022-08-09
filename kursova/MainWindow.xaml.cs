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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            DataProcessingService processingService = new CsvProcessingService();
            StringBuilder s = new StringBuilder();
            List<ComputerBase> list = processingService.ReadFromDatabase();

            string result = list[0].ToString() + list[1].ToString();

            var pc1 = new OldComputer("Asus", "Dell", "nvidia", 1500, "mechanical", 3, 304, true, false);

            processingService.WriteToDatabase(new List<ComputerBase> { pc1 });

            output.Text = result + pc1.ToString();
        }

        private void output_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
