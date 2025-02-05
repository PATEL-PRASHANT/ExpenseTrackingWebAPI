using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackingAPI.BRule.DataLayer
{
    public class DataHelper : IDataHelper
    {
        private readonly string _connectionString;
        private const int CommandTimeout = 300;

        public DataHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlConnection OpenConnection()
        {
            try
            {
                SqlConnection con = new SqlConnection(_connectionString);
                return con;
            }
            catch (Exception)
            {
                throw new Exception("connection is fail.");
            }
        }

        public void ExecuteCommand(SqlCommand cmd)
        {
            cmd.ExecuteNonQuery();
        }

        public SqlDataReader ExecuteReader(StringBuilder sb, SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sb.ToString();
            cmd.Connection = con;
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }

        public SqlDataReader ExecuteReader(SqlCommand cmd)
        {
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }

        public SqlDataReader ExecuteReader(StringBuilder sb, SqlConnection con, Int32 commandTimeOut)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = commandTimeOut;
            cmd.CommandText = sb.ToString();
            cmd.Connection = con;
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }

        public SqlDataReader ExecuteReader(SqlCommand cmd, SqlConnection con)
        {
            cmd.Connection = con;
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }

        public Object ExecuteScaler(StringBuilder sb, SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sb.ToString();
            cmd.Connection = con;
            object returnScaler = cmd.ExecuteScalar();
            return returnScaler;
        }

        public Object ExecuteScaler(SqlCommand cmd)
        {
            object returnScaler = cmd.ExecuteScalar();
            return returnScaler;
        }
    }
}
