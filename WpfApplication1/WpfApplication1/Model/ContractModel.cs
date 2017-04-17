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

        private string username;
        public string UserName
        {
            get { return username; }
            set
            {
                if (username != value)
                {
                    username = value;
                    RaisePropertyChanged("UserName");
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
                    RaisePropertyChanged("ContractLocation");
                }
            }
        }
        private string contractpc;
        public string ContractPC
        {
            get { return contractpc; }
            set
            {
                if (contractpc != value)
                {
                    contractpc = value;
                    RaisePropertyChanged("ContractPC");
                }
            }
        }
        private string contractps4;
        public string ContractPS4
        {
            get { return contractps4; }
            set
            {
                if (contractps4 != value)
                {
                    contractps4 = value;
                    RaisePropertyChanged("ContractPS4");
                }
            }
        }
        private string contractx1;
        public string ContractX1
        {
            get { return contractx1; }
            set
            {
                if (contractx1 != value)
                {
                    contractx1 = value;
                    RaisePropertyChanged("ContractX1");
                }
            }
        }
        private string avgrating;
        public string AVGRating
        {
            get { return avgrating; }
            set
            {
                if (avgrating != value)
                {
                    avgrating = value;
                    RaisePropertyChanged("AVGRating");
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

    public class Escalation : INotifyPropertyChanged
    {
        //properties
        private string escalationtitle;
        public string EscalationTitle
        {
            get { return escalationtitle; }
            set
            {
                if (escalationtitle != value)
                {
                    escalationtitle = value;
                    RaisePropertyChanged("EscalationTitle");
                }
            }
        }
        private string escalationlocation;
        public string EscalationLocation
        {
            get { return escalationlocation; }
            set
            {
                if (escalationlocation != value)
                {
                    escalationlocation = value;
                    RaisePropertyChanged("EscalationLocation");
                }
            }
        }
        private string avgrating;
        public string AVGRating
        {
            get { return avgrating; }
            set
            {
                if (avgrating != value)
                {
                    avgrating = value;
                    RaisePropertyChanged("AVGRating");
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