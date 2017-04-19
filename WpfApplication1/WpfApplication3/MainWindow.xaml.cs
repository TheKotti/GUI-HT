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
            try
            {
                InitializeComponent();
                IniMyStuff();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void IniMyStuff()
        {
            //tänne kootusti omien kontrollien alustukset
            try
            {
                List<string> locations = new List<string>();
                locations.Add("The Showstopper");
                locations.Add("World of Tomorrow");
                locations.Add("A Gilded Cage");
                locations.Add("Club 27");
                locations.Add("Freedom Fighters");
                locations.Add("Situs Inversus");
                cmbLocation.ItemsSource = locations;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
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
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //päivitetään datagridin sisältö
                BindingExpression expression = txtTitle.GetBindingExpression(TextBox.TextProperty);
                expression.UpdateSource();
                expression = cmbLocation.GetBindingExpression(ComboBox.TextProperty);
                expression.UpdateSource();
                expression = txtFullName.GetBindingExpression(TextBox.TextProperty);
                expression.UpdateSource();
                //valitaan päivitetty rivi
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
            try
            {
                btnDelete.IsEnabled = true;
                btnUpdate.IsEnabled = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddET addwindow = new AddET();
                addwindow.Owner = this;
                addwindow.ShowDialog();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void menuDownload_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ElusiveList.DownloadDB();
                txtStatus.Text = "Database backup downloaded.";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void menuRestore_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                dlg.Filter = "SQL|*.sql";
                Nullable<bool> result = dlg.ShowDialog();
                if (result == true)
                {
                    string filename = dlg.FileName;
                    var confirm = MessageBox.Show(string.Format("Are you sure you want to restore database from {0}?", filename.Substring(filename.LastIndexOf('\\') + 1)), "Restore?", MessageBoxButton.YesNo);
                    if (confirm == MessageBoxResult.Yes)
                    {
                        ElusiveList.RestoreDB(filename);
                        List<Elusive> ets = ElusiveList.GetETs();
                        dgElusives.DataContext = ets;
                        txtStatus.Text = "Database restored from backup.";
                    }
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
