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
        public ObservableCollection<Escalation> Escalations
        {
            get;
            set;
        }
        string sql;
        public void LoadContractsFromMysql(string type)
        {
            
            try
            {
                if (type == "System.Windows.Controls.Button: Contracts")
                {
                    sql = "SELECT ContractTitle, UserName, ContractLocation, ContractPC, ContractPS4, ContractX1, AVG(RatingScore) FROM Contracts INNER JOIN Users on Users.UserId = Contracts.UserId INNER JOIN Ratings ON Ratings.ContractId = Contracts.ContractId GROUP BY Contracts.ContractId";
                } else if (type == "System.Windows.Controls.Button: Escalations")
                {
                    sql = "SELECT EscalationTitle, EscalationLocation, AVG(RatingScore) FROM Escalations LEFT OUTER JOIN EscalationRatings ON Escalations.EscalationId = EscalationRatings.EscalationId GROUP BY Escalations.EscalationId";
                }
                ObservableCollection<Contract> contracts = new ObservableCollection<Contract>();
                ObservableCollection<Escalation> escalations = new ObservableCollection<Escalation>();
                //luodaan yhteys labranetin mysql-palvelimelle
                string connStr = GetMysqlConnectionString();
                    
                    using (MySqlConnection conn = new MySqlConnection(connStr))
                    {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (type == "System.Windows.Controls.Button: Contracts")
                            {
                                WpfApplication1.Model.Contract s = new Model.Contract();
                                s.ContractTitle = reader.GetString(0);
                                s.UserName = reader.GetString(1);
                                s.ContractLocation = reader.GetString(2);
                                s.ContractPC = reader.GetString(3);
                                s.ContractPS4 = reader.GetString(4);
                                s.ContractX1 = reader.GetString(5);
                                s.AVGRating = reader.GetString(6);
                                contracts.Add(s);
                                Contracts = contracts;
                            } else if (type == "System.Windows.Controls.Button: Escalations")
                            {
                                WpfApplication1.Model.Escalation e = new Model.Escalation();
                                e.EscalationTitle = reader.GetString(0);
                                e.EscalationLocation = reader.GetString(1);
                                e.AVGRating = reader.GetString(2);
                                escalations.Add(e);
                                Escalations = escalations;

                            }
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public void AddContractToDB(string title, string location)
        {
            string connStr = GetMysqlConnectionString();
            string sql = string.Format("INSERT INTO Contracts (ContractTitle, ContractLocation, UserId, GameId) VALUES ('{0}', '{1}', 4, 6)", title, location);
            
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                MySqlCommand insert = conn.CreateCommand();
                insert.CommandText = sql;
                conn.Open();
                insert.ExecuteNonQuery();
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