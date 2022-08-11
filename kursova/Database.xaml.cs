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

            List.ItemsSource = data.ToList();
            editDataGrid.ItemsSource = data;
            data.ListChanged += BindingList_ListChanged;
            // Filtering
            FilterBy.ItemsSource = new string[] { "Processor Type", "Monitor Type", "Graphic Card Type", "Drive Size", "Keyboard Type", "Id Number", "Class Room Number", "IsRepairing", "CdRom", "Floppy" };
            //CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(List.ItemsSource);
            List.Items.Filter = GetFilter();
        }

        public Predicate<object> GetFilter()
        {
            switch (FilterBy.SelectedItem as string)
            {
                case "Processor Type":
                    return ProcessorTypeFilter;
                case "Monitor Type":
                    return MonitorTypeFilter;
                case "Graphic Card Type":
                    return GraphicCardTypeFilter;
                case "Drive Size":
                    return DriveSizeFilter;
                case "Keyboard Type":
                    return KeyboardTypeFilter;
                case "Id Number":
                    return IdNumberFilter;
                case "Class Room Number":
                    return ClassRoomNumberFilter;
                case "IsRepairing":
                    return IsRepairingFilter;
                case "CdRom":
                    return CdRomFilter;
                case "Floppy":
                    return FloppyFilter;
            }
            return new Predicate<object>(ProcessorTypeFilter);
        }

        private bool ProcessorTypeFilter(object obj)
        {
            if (obj == null)
            {
                MessageBox.Show("Enter variable to search");
            } 

            var FilterObj = obj as ComputerBase;
            return FilterObj.ProcessorType.Contains(FilterTextbox.Text, StringComparison.OrdinalIgnoreCase);
        }

        private bool MonitorTypeFilter(object obj)
        {
            if (obj == null)
            {
                MessageBox.Show("Enter variable to search");
            }

            var FilterObj = obj as ComputerBase;
            return FilterObj.MonitorType.Contains(FilterTextbox.Text, StringComparison.OrdinalIgnoreCase);
        }

        private bool GraphicCardTypeFilter(object obj)
        {
            if (obj == null)
            {
                MessageBox.Show("Enter variable to search");
            }

            var FilterObj = obj as ComputerBase;
            return FilterObj.GraphicCardType.Contains(FilterTextbox.Text, StringComparison.OrdinalIgnoreCase);
        }

        private bool DriveSizeFilter(object obj)
        {
            if (obj == null)
            {
                MessageBox.Show("Enter variable to search");
            }

            var FilterObj = obj as ComputerBase;
            return FilterObj.DriveSize.ToString().Contains(FilterTextbox.Text, StringComparison.OrdinalIgnoreCase);
        }

        private bool KeyboardTypeFilter(object obj)
        {
            if (obj == null)
            {
                MessageBox.Show("Enter variable to search");
            }

            var FilterObj = obj as ComputerBase;
            return FilterObj.KeyboardType.Contains(FilterTextbox.Text, StringComparison.OrdinalIgnoreCase);
        }

        private bool IdNumberFilter(object obj)
        {
            if (obj == null)
            {
                MessageBox.Show("Enter variable to search");
            }

            var FilterObj = obj as ComputerBase;
            return FilterObj.IdNumber.ToString().Contains(FilterTextbox.Text, StringComparison.OrdinalIgnoreCase);
        }

        private bool ClassRoomNumberFilter(object obj)
        {
            if (obj == null)
            {
                MessageBox.Show("Enter variable to search");
            }

            var FilterObj = obj as ComputerBase;
            return FilterObj.ClassRoomNumber.ToString().Contains(FilterTextbox.Text, StringComparison.OrdinalIgnoreCase);
        }

        private bool IsRepairingFilter(object obj)
        {
            if (obj == null)
            {
                MessageBox.Show("Enter variable to search");
            }

            var FilterObj = obj as ComputerBase;
            return FilterObj.IsRepairing.ToString().Contains(FilterTextbox.Text, StringComparison.OrdinalIgnoreCase);
        }

        private bool CdRomFilter(object obj)
        {
            if (obj == null)
            {
                MessageBox.Show("Enter variable to search");
            }

            var FilterObj = obj as ComputerBase;
            return FilterObj.CdRom.ToString().Contains(FilterTextbox.Text, StringComparison.OrdinalIgnoreCase);
        }

        private bool FloppyFilter(object obj)
        {
            if (obj == null)
            {
                MessageBox.Show("Enter variable to search");
            }

            var FilterObj = obj as ComputerBase;
            return FilterObj.Floppy.ToString().Contains(FilterTextbox.Text, StringComparison.OrdinalIgnoreCase);
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

        private void FilterTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FilterTextbox.Text == null)
            {
                List.Items.Filter = null;
            } 
            else
            {
                List.Items.Filter = GetFilter();
            }
        }

        private void FilterBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List.Items.Filter = GetFilter();
        }
    }
}
