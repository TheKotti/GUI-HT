using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT
{
    public class DBElusives
    {
        public static DataTable GetETsFromDB(string connstring)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connstring))
                {
                    string sql = "SELECT ElusiveId, ElusiveTitle, ElusiveLocation, ElusiveFullName, ElusiveDate FROM Elusives";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable("Elusives");
                            da.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void UpdateETinDB(string connstring, int id, string title, string location, string fullname, DateTime newdate)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connstring))
                {
                    conn.Open();
                    string sql = string.Format("UPDATE Elusives SET ElusiveTitle=@Title, ElusiveLocation=@Location, ElusiveFullName=@FullName, ElusiveDate=@NewDate WHERE ElusiveId={0}", id);
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        //lisätään parametrit
                        MySqlParameter sp;
                        sp = new MySqlParameter("Title", MySqlDbType.VarChar);
                        sp.Value = title;
                        cmd.Parameters.Add(sp);
                        sp = new MySqlParameter("Location", MySqlDbType.VarChar);
                        sp.Value = location;
                        cmd.Parameters.Add(sp);
                        sp = new MySqlParameter("FullName", MySqlDbType.VarChar);
                        sp.Value = fullname;
                        cmd.Parameters.Add(sp);
                        sp = new MySqlParameter("NewDate", MySqlDbType.DateTime);
                        sp.Value = newdate;
                        cmd.Parameters.Add(sp);
                        int lkm = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void DeleteETFromDB(string connstring, int id)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connstring))
                {
                    conn.Open();
                    string sql = string.Format("DELETE FROM ElusiveRatings Where ElusiveId={0}", id);
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    sql = string.Format("DELETE FROM Elusives Where ElusiveId={0}", id);
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void AddETToDB(string connstring, string title, string location, string fullname, DateTime date)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connstring))
                {
                    conn.Open();
                    string sql = string.Format("INSERT INTO Elusives (ElusiveTitle, ElusiveLocation, ElusiveFullName, ElusiveDate, GameId) VALUES (@Title, @Location, @FullName, @Date, 6)");
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        //lisätään parametrit
                        MySqlParameter sp;
                        sp = new MySqlParameter("Title", MySqlDbType.VarChar);
                        sp.Value = title;
                        cmd.Parameters.Add(sp);
                        sp = new MySqlParameter("Location", MySqlDbType.VarChar);
                        sp.Value = location;
                        cmd.Parameters.Add(sp);
                        sp = new MySqlParameter("FullName", MySqlDbType.VarChar);
                        sp.Value = fullname;
                        cmd.Parameters.Add(sp);
                        sp = new MySqlParameter("Date", MySqlDbType.DateTime);
                        sp.Value = date;
                        cmd.Parameters.Add(sp);
                        int lkm = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
