using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT
{
    public class Elusive
    {
        #region PROPERTIES

        private int id;
        public int Id
        { get { return id; } }

        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string location;
        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        private string fullname;
        public string FullName
        {
            get { return fullname; }
            set { fullname = value; }
        }

        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        #endregion
        #region CONSTUCTORS
        public Elusive()
        {
        }
        public Elusive(int id)
        {
            this.id = id;
        }
        public Elusive(int id, string title, string location, string fullname, DateTime date)
        {
            this.id = id;
            this.title = title;
            this.location = location;
            this.fullname = fullname;
            this.date = date;
        }
        #endregion
        #region METHODS

        public override string ToString()
        {
            return title;
        }
        #endregion
    }

    public static class ElusiveList
    {
        private static string connstring = WpfApplication3.Properties.Settings.Default.Connection;
        public static List<Elusive> GetTestETs()
        {
            List<Elusive> temp = new List<Elusive>();
            temp.Add(new Elusive(1, "The Tester", "The Showstopper", "Some Dude", new DateTime(2016, 12, 5)));
            temp.Add(new Elusive(2, "The Other Dude", "World of Tomorrow", "Other Dyde", new DateTime(2017, 10, 25)));
            return temp;
        }
        public static List<Elusive> GetETs()
        {
            DataTable dt;
            List<Elusive> temp = new List<Elusive>();
            dt = DBElusives.GetETsFromDB(connstring);
            //ORM ?????
            Elusive et;
            foreach (DataRow dr in dt.Rows)
            {
                et = new Elusive((int)dr[0]);
                et.Title = dr["ElusiveTitle"].ToString();
                et.Location = dr["ElusiveLocation"].ToString();
                et.FullName = dr["ElusiveFullName"].ToString();
                et.Date = (DateTime)dr["ElusiveDate"];
                temp.Add(et);
            }
            return temp;
        }
        public static void UpdateET(Elusive et, DateTime newdate)
        {
            try
            {
                JAMK.IT.DBElusives.UpdateETinDB(connstring, et.Id, et.Title, et.Location, et.FullName, newdate);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void DeleteET(Elusive et)
        {
            try
            {
                JAMK.IT.DBElusives.DeleteETFromDB(connstring, et.Id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void AddET(Elusive et)
        {
            try
            {
                JAMK.IT.DBElusives.AddETToDB(connstring, et.Title, et.Location, et.FullName, et.Date);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void DownloadDB()
        {
            try
            {
                DBElusives.DownloadBackupofDB(connstring);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void RestoreDB(string filename)
        {
            try
            {
                DBElusives.RestoreDBFromBackup(connstring, filename);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
