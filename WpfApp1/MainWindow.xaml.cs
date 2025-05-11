using Microsoft.Win32;
using System.Data;
using System.Windows;

namespace WpfApp1
{

    public partial class MainWindow : Window
    {

        private string filePath = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Xml Files| *.xml";

            if (ofd.ShowDialog() == true)
            {
                fileName.Text = ofd.SafeFileName;
                filePath = ofd.FileName;
            }

        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            errorMessage.Text = "";
            dataGrid.Visibility = Visibility.Hidden;
            if (filePath.Length > 0)
            {
                if (calendarStart.calender.SelectedDate.HasValue && calendarEnd.calender.SelectedDate.HasValue)
                {
                    DataView? xmlData = XmlParser.GetXmlData(filePath, calendarStart.calender.SelectedDate.Value, calendarEnd.calender.SelectedDate.Value);
                    if (xmlData != null)
                    {
                        dataGrid.ItemsSource = xmlData;
                        dataGrid.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        errorMessage.Text = "Error: Špatné formátování souboru";
                    }
                }
                else
                {
                    errorMessage.Text = "Error: Nebylo zvoleno datum";
                }
                
            } 
            else
            {
                errorMessage.Text = "Error: Nebyl zvolen soubor";
            }
        }
    }
}