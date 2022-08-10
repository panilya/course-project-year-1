using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    /// Interaction logic for Database.xaml
    /// </summary>
    public partial class Database : Page
    {

        private readonly CsvProcessingService csvProcessingService;

        private BindingList<ComputerBase> data;

        public Database()
        {
            InitializeComponent();
            csvProcessingService = new CsvProcessingService();

            data = new BindingList<ComputerBase>();

            try
            {
                data = csvProcessingService.ReadFromDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            List.ItemsSource = data;
            editDataGrid.ItemsSource = data;
            data.ListChanged += BindingList_ListChanged;
        }

        private void BindingList_ListChanged(object? sender, ListChangedEventArgs e)
        {

            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemChanged)
            {
                try
                {
                    csvProcessingService.WriteToDatabase(sender);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void DatabaseViewUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            List.ItemsSource = csvProcessingService.ReadFromDatabase();
        }

        private void DatabaseEdit_UpdateButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
