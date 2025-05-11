using System.Windows.Controls;

namespace WpfApp1.View.UserControls
{
    /// <summary>
    /// Interakční logika pro UserControl1.xaml
    /// </summary>
    public partial class CalendarInfo : UserControl
    {
        public CalendarInfo()
        {
            InitializeComponent();
        }


        private string calendarText;

        public string CalendarText
        {
            get { return calendarText; }
            set { calendarText = value;
                calenderTextBlock.Text = calendarText;
            }
        }
    }
}
