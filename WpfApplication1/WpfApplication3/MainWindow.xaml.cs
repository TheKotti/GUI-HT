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

namespace JAMK.IT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
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
        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            //testiETs
            //dgElusives.DataContext = ElusiveList.GetTestETs();
            try
            {
                List<Elusive> ets = ElusiveList.GetETs();
                dgElusives.DataContext = ets;
                txtStatus.Text = string.Format("Loaded {0} Elusives.", dgElusives.Items.Count);
                btnDelete.IsEnabled = false;
                btnUpdate.IsEnabled = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dgElusives_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Elusive current = (Elusive)dgElusives.SelectedItem;
                int year = Int32.Parse(txtDate.Text.Substring(6, 4));
                int month = Int32.Parse(txtDate.Text.Substring(3, 2));
                int day = Int32.Parse(txtDate.Text.Substring(0, 2));
                DateTime newdate = new DateTime(year, month, day);
                //lähetetään muutettavaksi
                ElusiveList.UpdateET(current, newdate);
                txtStatus.Text = string.Format("{0} updated.", current.Title);
                List<Elusive> ets = ElusiveList.GetETs();
                dgElusives.DataContext = ets;
                btnDelete.IsEnabled = false;
                btnUpdate.IsEnabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Elusive current = (Elusive)dgElusives.SelectedItem;
                var result = MessageBox.Show(string.Format("Are you sure you want to delete {0}?", current.Title.ToString()), "Delete?", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    ElusiveList.DeleteET(current);
                    txtStatus.Text = string.Format("{0} deleted.", current.Title);
                    List<Elusive> ets = ElusiveList.GetETs();
                    dgElusives.DataContext = ets;
                    btnDelete.IsEnabled = false;
                    btnUpdate.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dgElusives_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            btnDelete.IsEnabled = true;
            btnUpdate.IsEnabled = true;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddET addwindow = new AddET();
            addwindow.Owner = this;
            addwindow.ShowDialog();
        }
    }
}
