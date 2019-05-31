using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.ComponentModel;
namespace Digital_Clock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer tm = new DispatcherTimer();
        DigitalClock cls = new DigitalClock();
        int iTotalSeconds { get; set; }
      
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            if (btnStart.Content.ToString() == "Start")
            {
                tm.Start();
                btnStart.Content = "Stop";
            }
            else
            {
                tm.Stop();
                btnStart.Content = "Start";
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetDigitalClock();
            tm.Interval = TimeSpan.FromSeconds(1);
            tm.Tick += new EventHandler(tm_Tick);
        }

        void tm_Tick(object sender, EventArgs e)
        {
            iTotalSeconds++;
            cls.iSeconds = iTotalSeconds % 60 == 0 ? 0 : iTotalSeconds % 60;
            cls.iMinutes = cls.iMinutes > 59 ? 0 : (iTotalSeconds >= 60 ? iTotalSeconds / 60 : 0);
            cls.iHours = iTotalSeconds / 3600;
            SetDigitalClock();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            listBox1.Items.Add(txtValue.Text);
        }
        private void SetDigitalClock()
        {
            lblTime.Content = cls.iHours.ToString().PadLeft(2, '0').ToString() + ":" + cls.iMinutes.ToString().PadLeft(2, '0').ToString() + ":" + cls.iSeconds.ToString().PadLeft(2, '0').ToString();
        }
    }
}
