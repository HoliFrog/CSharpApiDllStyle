using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagApiWPFDisplayer.Model
{
    public class RequestParameters : INotifyPropertyChanged
    {
        private string _long;
        private string _lat;
        private string _dist;

        public RequestParameters()
        {
            _long = "5.728221";
            _lat = "45.185692";
            _dist = "550";
        }

        public string Long
        {
            get { return _long; }
            set
            {
                if (_long != value)
                {
                    _long = value;
                    RaisePropertyChanged("Long");
                }
            }
        }

        public string Lat
        {
            get { return _lat; }
            set
            {
                if (_lat != value)
                {
                    _lat = value;
                    RaisePropertyChanged("Lat");
                }
            }
        }

        public string Dist
        {
            get { return _dist; }
            set
            {
                if (_dist != value)
                {
                    _dist = value;
                    RaisePropertyChanged("Dist");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
