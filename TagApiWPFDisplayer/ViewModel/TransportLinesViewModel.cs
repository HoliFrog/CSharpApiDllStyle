using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TagApiWPFDisplayer.Model;
using TagLibrary;

namespace TagApiWPFDisplayer.ViewModel
{
    class TransportLinesViewModel : INotifyPropertyChanged
    {
           public DataCallToDll mDataCallToDll = new DataCallToDll();
        public ObservableCollection<StationWithLinesAndDetails> mStationWithLinesAndDetails
        {
            get;
            set;
        }

        private ICommand _command;
        public ICommand Command
        {
             get
             {
                   return _command ?? (_command = new RelayCommand(
                   x =>
                   {
                       DoStuff();
                   }));
             } 
        }

        private RequestParameters _requestParameters;

        public RequestParameters ParametersForRequest
        {
            get { return _requestParameters; }
            set { _requestParameters = value; }
        }


        public TransportLinesViewModel()
        {
            _requestParameters = new RequestParameters();
            this.mStationWithLinesAndDetails = new ObservableCollection<StationWithLinesAndDetails>();
            FillObsevableDictionary();
        }

        
       private void FillObsevableDictionary()
        {
            this.mStationWithLinesAndDetails.Clear();
            foreach (var item in mDataCallToDll.CallToDll(ParametersForRequest.Long, ParametersForRequest.Lat, ParametersForRequest.Dist))
            {
                this.mStationWithLinesAndDetails.Add(new StationWithLinesAndDetails(item.Key, item.Value));
            }            
        }

        private void DoStuff()
        {
            FillObsevableDictionary();

        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
