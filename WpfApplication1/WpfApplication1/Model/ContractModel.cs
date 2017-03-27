using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.Model
{
    public class Contract : INotifyPropertyChanged
    {
        //properties
        private string contracttitle;
        public string ContractTitle
        {
            get { return contracttitle; }
            set
            {
                if (contracttitle != value)
                {
                    contracttitle = value;
                    RaisePropertyChanged("ContractTitle");
                }
            }
        }

        private string contractlocation;
        public string ContractLocation
        {
            get { return contractlocation; }
            set
            {
                if (contractlocation != value)
                {
                    contractlocation = value;
                    RaisePropertyChanged("LastName");
                }
            }
        }

        //contrcutors
        //methods
        //events
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