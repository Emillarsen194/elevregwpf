using elevregwpf.Properties;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
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

        public bool ValidateUser(string userName, string password)
        {
            bool Valid = false;
            try
            {
                PrincipalContext pc = new PrincipalContext(ContextType.Domain, "elevreg-skpit.local");
                Valid = pc.ValidateCredentials(userName, password);
                if (Valid)
                {
                    DirectorySearcher search = new DirectorySearcher(new DirectoryEntry("LDAP://elevreg-skpit.local", userName, password))
                    {
                        //makes a filter the searches for users with the same UNI(sAMAccountName)
                        Filter = string.Format("(&(objectClass=user)(objectCategory=person)(sAMAccountName={0}))", userName)
                    };
                    //asks for name and what group it is member of

                    search.PropertiesToLoad.Add("sAMAccountName");



                    //gets the information
                    SearchResult resultCol = search.FindOne();
                    //get unilogon
                    string studing = resultCol.GetDirectoryEntry().Properties["sAMAccountName"].Value.ToString();







                }
            }
            catch
            {
            }


            return Valid;//true = user authenticated!
        }

    }
        }

    

