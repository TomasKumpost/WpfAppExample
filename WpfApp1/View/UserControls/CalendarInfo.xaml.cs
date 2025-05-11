using System.Windows.Controls;

namespace WpfApp1.View.UserControls
{
    public partial class CalendarInfo : UserControl
    {
        public CalendarInfo()
        {
            InitializeComponent();
        }


        private string calendarText = "Placeholder";

        public string CalendarText
        {
            get { return calendarText; }
            set { calendarText = value;
                calenderTextBlock.Text = calendarText;
            }
        }
    }
}
