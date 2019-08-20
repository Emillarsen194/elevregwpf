using elevregwpf.Properties;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elevregwpf
{
    class Dal
    {

        public void Checkind(string uni)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Settings.Default.Sqlcon;
            try
            {


                DateTime dt = DateTime.Now; // get the date time now
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO checkintid (intid, uni) VALUES (@value, '" + uni + "')", con); //runs our query with parameters

                cmd.Parameters.AddWithValue("@value", dt);

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
            }

            finally
            {
                con.Close();
            }
        }


        public void addpersontoday(string v) // adds persons who is here to day to whos here 
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Settings.Default.Sqlcon;
            try
            {

                DateTime dt = DateTime.Now;
                con.Open();


                SqlCommand cmd = new SqlCommand("DELETE FROM whoshere where uni = '" + v + "' INSERT INTO whoshere (checkintid, uni) VALUES (@value, '" + v + "')", con);
                cmd.Parameters.AddWithValue("@value", dt);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                
            }
            finally
            {
                con.Close();
            }
        }

        public void Adduser(string uni)
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = Settings.Default.Sqlcon;
            try
            {



                con.Open();
                string query = "IF NOT EXISTS(SELECT * FROM brugere where uni = '" + uni + "') " +
                    "Begin INSERT INTO brugere(uni) values('" + uni + "') end";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {


                con.Open();
                string query = "IF NOT EXISTS(SELECT * FROM brugere where uni = '" + uni + "') " +
                    "Begin INSERT INTO brugere(uni) values('" + uni + "') end";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.ExecuteNonQuery();
                con.Close();

            }
            finally
            {
                con.Close();
            }





        }

    }
}
