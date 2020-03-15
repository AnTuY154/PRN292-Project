using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjectCSharp_Shop.DAO
{
    public class DemoDAO
    {
        SqlConnection conn = null;
        //demo query SELECT
        public List<Account> GetAccount()
        {
            List<Account> listAccount = new List<Account>();
            conn = DBContext.GetDBConnection();
            conn.Open();
            try
            {              
                string query = "SELECT [username],[password] FROM[dbo].[Account]";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = query;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Account a = new Account();
                            a.Username = reader.GetString(0);
                            a.Password = reader.GetString(1);
                            listAccount.Add(a);
                        }
                    }
                }
                return listAccount;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            }
        }
        //demo query INSERT
        public void AddAccount(string username, string password)
        {
            conn = DBContext.GetDBConnection();
            conn.Open();
            try
            {    
                //tham số @user, @pass giống như ? trong java
                string query = "INSERT INTO [dbo].[Account] ([username],[password])"
                 + "VALUES (@user, @pass)";
                SqlCommand cmd = conn.CreateCommand();             
                cmd.CommandText = query;
                //sét tham số @ bằng dữ liệu truyền vào
                cmd.Parameters.Add("@user", System.Data.SqlDbType.NVarChar).Value = username;
                cmd.Parameters.Add("@password", System.Data.SqlDbType.NVarChar).Value = password;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            }
        }
        //demo query UPDATE
        public void UpdateAccount(string oldUsername, string newPassword)
        {
            conn = DBContext.GetDBConnection();
            conn.Open();
            try
            {
                string query = "UPDATE [dbo].[Account]" 
                + "SET [password] = @newPass"
                + "WHERE username = @oldName";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = query;
                cmd.Parameters.Add("@newPass", System.Data.SqlDbType.NVarChar).Value = newPassword;
                cmd.Parameters.Add("@oldName", System.Data.SqlDbType.NVarChar).Value = oldUsername;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            }
        }
        //demo query DELETE
        public void DeleteAccount(string username)
        {
            conn = DBContext.GetDBConnection();
            conn.Open();
            try
            {
                string query = "DELETE FROM [dbo].[Account] WHERE username = @user";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = query;
                cmd.Parameters.Add("@user", System.Data.SqlDbType.NVarChar).Value = username;                
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}