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

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Person> henkilot = new List<Person>();
        int counter = 0;

        public MainWindow()
        {
            InitializeComponent();
            CreatePeople();

        }

        private void CreatePeople() {
            Person eka = new Person();
            eka.FirstName = "Mendie";
            eka.LastName = "Tinha";
            Person toka = new WpfApplication2.Person { FirstName = "Ageing", LastName = "FPS" };
            henkilot.Add(eka);
            henkilot.Add(toka);
            txt1.Text = henkilot[counter].FullName();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            counter++;
            txt1.Text = henkilot[counter].FullName();
        }
        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            counter--;
            txt1.Text = henkilot[counter].FullName();
        }
    }
}
