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
    class Books
    {
        public int Id { get; set; }
        public string BookTitle { get; set; }
        public string Author { get; set; }
        public string Quantity { get; set; }
        public string Publisher { get; set; }
        public string Category { get; set; }
        public long CostPrice { get; set; }
        public long SellingPrice { get; set; }
        public string BarCode { get; set; }
        public string Remarks { get; set; }

       static string myCon = ConfigurationManager.ConnectionStrings["cnnstrng"].ConnectionString;
        
        public DataTable Select()
        {
            SqlConnection conn = new SqlConnection(myCon);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM tbl_Books";
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

        public bool Insert(Books book)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myCon);
            try
            {
                string sql = "INSERT INTO tbl_Books (BookTitle,Author,Quantity,Publisher,Category,CostPrice,SellingPrice,BarCode,Remarks) values(@BookTitle,@Author,@Quantity,@Publisher,@Category,@CostPrice,@SellingPrice,@BarCode,@Remarks)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@BookTitle", book.BookTitle);
                cmd.Parameters.AddWithValue("@Author", book.Author);
                cmd.Parameters.AddWithValue("@Quantity", book.Quantity);
                cmd.Parameters.AddWithValue("@Publisher", book.Publisher);
                cmd.Parameters.AddWithValue("@Category", book.Category);
                cmd.Parameters.AddWithValue("@CostPrice", book.CostPrice);
                cmd.Parameters.AddWithValue("@SellingPrice", book.SellingPrice);
                cmd.Parameters.AddWithValue("@BarCode", book.BarCode);
                cmd.Parameters.AddWithValue("@Remarks", book.Remarks);
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

        public bool Edit(Books book)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myCon);
            try
            {
                string sql = "UPDATE tbl_Books SET BookTitle=@BookTitle , Author=@Author, Quantity=@Quantity, Publisher=@Publisher, Category=@Category, CostPrice=@CostPrice, SellingPrice=@SellingPrice, BarCode=@BarCode, Remarks=@Remarks WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@BookTitle", book.BookTitle);
                cmd.Parameters.AddWithValue("@Author", book.Author);
                cmd.Parameters.AddWithValue("@Quantity", book.Quantity);
                cmd.Parameters.AddWithValue("@Publisher", book.Publisher);
                cmd.Parameters.AddWithValue("@Category", book.Category);
                cmd.Parameters.AddWithValue("@CostPrice", book.CostPrice);
                cmd.Parameters.AddWithValue("@SellingPrice", book.SellingPrice);
                cmd.Parameters.AddWithValue("@BarCode", book.BarCode);
                cmd.Parameters.AddWithValue("@Remarks", book.Remarks);
                cmd.Parameters.AddWithValue("@Id", book.Id);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if(rows > 0)
                {
                    isSuccess = false;
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

        public bool Delete(Books book)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myCon);
            try
            {
                string sql = "DELETE FROM tbl_Books WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", book.Id);
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
