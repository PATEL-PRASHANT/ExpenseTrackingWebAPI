using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackingAPI.BRule.DataLayer
{
    public interface IDataHelper
    {
        SqlConnection OpenConnection();
        void ExecuteCommand(SqlCommand cmd);
        SqlDataReader ExecuteReader(StringBuilder sb, SqlConnection con);
        SqlDataReader ExecuteReader(SqlCommand cmd);
        SqlDataReader ExecuteReader(StringBuilder sb, SqlConnection con, Int32 commandTimeOut);
        SqlDataReader ExecuteReader(SqlCommand cmd, SqlConnection con);
        Object ExecuteScaler(StringBuilder sb, SqlConnection con);
        Object ExecuteScaler(SqlCommand cmd);
    }
}
