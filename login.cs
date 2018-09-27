using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace HotelAutomation
{
    class Login
    {
        Database db = new Database();
        public string userName_hold { get; set; }
        public string userPassword_hold { get; set; }

        public string loginInfo { get; set; }

        public void login(string userName, string userPassword, DateTime date)
        {
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                db.connection.Close();
            }
            try
            {
                db.connection.Open();
                SqlCommand loginName = new SqlCommand("select userName from usersInformation where userName=@uName", db.connection);
                loginName.Parameters.AddWithValue(@"uName", userName);
                SqlDataReader uName_read = loginName.ExecuteReader();

                if(uName_read.Read())
                {
                    userName_hold = uName_read["userName"].ToString();
                    SqlCommand loginPw = new SqlCommand("select userPassword from usersInformation where userPassword=@uPw", db.connection);
                    loginPw.Parameters.AddWithValue("@uPw", userPassword);
                    SqlDataReader loginPw_read = loginPw.ExecuteReader();
                    if (loginPw_read.Read())
                    {
                        userPassword_hold = loginPw_read["userPassword"].ToString();
                        loginInfo = userName_hold + "" + userPassword_hold;
                        SqlCommand dateUpdate = new SqlCommand("update userInformation set date=@dte where userName=@uName AND userPassword=@uPw" ,db.connection);
                        dateUpdate.Parameters.AddWithValue("date", date);
                        dateUpdate.Parameters.AddWithValue("uName", userName_hold);
                        dateUpdate.Parameters.AddWithValue("uPw", userPassword_hold);
                        dateUpdate.ExecuteNonQuery();
                        dateUpdate.Dispose();


                    }
                    else
                    {
                       
                        MessageBox.Show("Your password is failed.", "ERROR | Hotel Automation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    loginPw.Dispose();
                    loginPw_read.Dispose();
                    
                }
                else
                {
                    MessageBox.Show("Your user name is failed.", "ERROR | Hotel Automation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                loginName.Dispose();
                uName_read.Close();
                db.connection.Close();
                
            }
            catch { }
            finally
            {
                db.connection.Close();
            }

        }
    }
}
    
