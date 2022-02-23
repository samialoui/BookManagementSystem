using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Classes
{
    class Users
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string CNIC { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        static string myConnstrg = ConfigurationManager.ConnectionStrings["cnnstrng"].ConnectionString;

        public DataTable Select()
        {
            SqlConnection conn = new SqlConnection(myConnstrg);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM tbl_Users";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        public bool Insert(Users user)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myConnstrg);
            try
            {
                string sql = "INSERT INTO tbl_Users (FirstName,LastName,Phone,CNIC,Email,Password,Role) VALUES(@FirstName,@LastName,@Phone,@CNIC,@Email,@Password,@Role)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@Phone", user.Phone);
                cmd.Parameters.AddWithValue("@CNIC", user.CNIC);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Role", user.Role);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }
            return isSuccess;

        }

        public bool upDate(Users user)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myConnstrg);
            try
            {
                string sql = "UPDATE tbl_Users SET FirstName=@FirstName , LastName=@LastName , Phone=@Phone, CNIC=@CNIC, Email=@Email, Password=@Password, Role=@Role WHERE ID=@ID ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@Phone", user.Phone);
                cmd.Parameters.AddWithValue("@CNIC", user.CNIC);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Role", user.Role);
                cmd.Parameters.AddWithValue("@ID", user.ID);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if(rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }


            }
            catch(Exception e)
            {
          
            }
            finally
            {
             
            }
            return isSuccess;
        }

        public bool Delete(Users user)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myConnstrg);
            try
            {
                
                string sql = "DELETE FROM tbl_Users WHERE ID = @ID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ID", user.ID);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
    }
}
