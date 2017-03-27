using System;
using System.Collections.Generic;
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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WpfApplication1.ViewModel.ContractViewModel svmo = new ViewModel.ContractViewModel();
        public MainWindow()
        {
            InitializeComponent();
            //kovakoodatut oppilaat
            //svmo.LoadStudents();
            //tietokannasta
            try
            {
                svmo.LoadContractsFromMysql();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void ContractViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            ContractViewControl.DataContext = svmo;
        }

        private void dgContracts_Loaded(object sender, RoutedEventArgs e)
        {
            dgContracts.DataContext = svmo.Contracts;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //luodaan uusi Student-olio observablecolllectioniin
            WpfApplication1.Model.Contract uusi = new Model.Contract();
            uusi.ContractTitle = txtContractTitle.Text;
            uusi.ContractLocation = txtContractLocation.Text;
            svmo.Contracts.Add(uusi);
            txtContractTitle.Text = "";
            txtContractLocation.Text = "";
        }
    }
}