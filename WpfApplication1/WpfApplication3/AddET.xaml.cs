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
using System.Windows.Shapes;

namespace JAMK.IT
{
    /// <summary>
    /// Interaction logic for AddET.xaml
    /// </summary>
    public partial class AddET : Window
    {
        public AddET()
        {
            InitializeComponent();
            IniMyStuff();
        }
        private void IniMyStuff()
        {
            //tänne kootusti omien kontrollien alustukset
            List<string> locations = new List<string>();
            locations.Add("The Showstopper");
            locations.Add("World of Tomorrow");
            locations.Add("A Gilded Cage");
            locations.Add("Club 27");
            locations.Add("Freedom Fighters");
            locations.Add("Situs Inversus");
            cmbLocation.ItemsSource = locations;
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Luodaan uusi olio
                Elusive newET = new Elusive();
                newET.Title = txtNewTitle.Text;
                newET.Location = cmbLocation.SelectedItem.ToString();
                newET.FullName = txtNewFullName.Text;
                int year = Int32.Parse(txtNewDate.Text.Substring(6, 4));
                int month = Int32.Parse(txtNewDate.Text.Substring(3, 2));
                int day = Int32.Parse(txtNewDate.Text.Substring(0, 2));
                DateTime newdate = new DateTime(year, month, day);
                newET.Date = newdate;
                //Lähetetään uusi olio eteenpäin
                ElusiveList.AddET(newET);
                //päivitetään pääikkuna
                MainWindow mainwindow = Owner as MainWindow;
                mainwindow.txtStatus.Text = newET.Title + " added.";
                List<Elusive> ets = ElusiveList.GetETs();
                mainwindow.dgElusives.DataContext = ets;
                mainwindow.btnDelete.IsEnabled = false;
                mainwindow.btnUpdate.IsEnabled = false;
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
