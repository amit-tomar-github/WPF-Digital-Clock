using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Digital_Clock
{
    class DigitalClock : INotifyPropertyChanged
    {
        private int seconds;
        public int iSeconds 
        {
            get{return this.seconds;} 
            set
            {
                if (this.seconds != value)
                {
                    this.seconds = value;
                    this.NotifyPropertyChanged("iSeconds");
                }
            }
        }
        public int iMinutes { get; set; }
        public int iHours { get; set; }

        private string clocktime;
        public string ClockTime
        {
            get { return this.clocktime; }
            set
            {
                if (this.clocktime != value)
                {
                    this.clocktime = value;
                    this.NotifyPropertyChanged("ClockTime");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // Create the OnPropertyChanged method to raise the event
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
