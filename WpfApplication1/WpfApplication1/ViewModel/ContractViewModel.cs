using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using WpfApplication1.Model;

namespace WpfApplication1.ViewModel
{
    public class ContractViewModel
    {
        public ObservableCollection<Contract> Contracts
        {
            get;
            set;
        }
        //public void LoadStudents()
        //{
        //    ObservableCollection<Student> students = new ObservableCollection<Student>();
        //    //lisätään esimerkin vuoksi muutama opiskelija, oikeassa sovelluksessa tulisivat vaikka tietokannasta
        //    students.Add(new Student { FirstName = "Kalle", LastName = "Jalkanen", AsioId = "1234543" });
        //    students.Add(new Student { FirstName = "Teppo", LastName = "Testaaja", AsioId = "rewqwerewq" });
        //    students.Add(new Student { FirstName = "Tomi", LastName = "Töttersätänst", AsioId = "fdsasdfdwsa" });
        //    students.Add(new Student { FirstName = "Anni", LastName = "Anjolkainen", AsioId = "bvcdzxcv" });
        //    Students = students;
        //}
        //metodi StudentViewModeliin jolla haetaan oppilastiedot mysql-palvemilta
        public void LoadContractsFromMysql()
        {
            try
            {
                ObservableCollection<Contract> contracts = new ObservableCollection<Contract>();
                //luodaan yhteys labranetin mysql-palvelimelle
                string connStr = GetMysqlConnectionString();
                string sql = "SELECT ContractTitle, ContractLocation FROM Contracts";
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            WpfApplication1.Model.Contract s = new Model.Contract();
                            s.ContractTitle = reader.GetString(0);
                            s.ContractLocation = reader.GetString(1);
                            contracts.Add(s);
                        }
                        Contracts = contracts;
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        private string GetMysqlConnectionString()
        {
            //string pw = WPFMVVMDemo.Properties.Settings.Default.passu;
            string pw = "";
            //haetaan salasana App.Config-tiedostosta  ^
            //initial catalog == tietokannan nimi  v
            return string.Format("Data source=localhost; Initial Catalog=HitmanDB; user=root; password={0}", pw);
        }
    }
}