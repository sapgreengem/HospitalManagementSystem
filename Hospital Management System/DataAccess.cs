using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Hospital_Management_System
{
    class DataAccess
    {
        static string _ConnectionString = "server=localhost;database=user;uid=root;pwd=;";
        static MySqlConnection _Connection = null;
        public static MySqlConnection Connection
    {
        get
        {
            if (_Connection == null)
            {
                _Connection = new MySqlConnection(_ConnectionString);
                _Connection.Open();

                return _Connection;
            }
            else if (_Connection.State != System.Data.ConnectionState.Open)
            {
                _Connection.Open();

                return _Connection;
            }
            else
            {
                return _Connection;
            }
        }
    }

    static DataSet GetDataSet(string sql)
    {
        MySqlCommand cmd = new MySqlCommand(sql, Connection);
        MySqlDataAdapter adp = new MySqlDataAdapter(cmd);

        DataSet ds = new DataSet();
        adp.Fill(ds);
        Connection.Close();

        return ds;
    }

    public static DataTable GetDataTable(string sql)
    {
        DataSet ds = GetDataSet(sql);

        if (ds.Tables.Count > 0)
            return ds.Tables[0];
        return null;
    }

    public static int ExecuteSQL(string sql)
    {
        MySqlCommand cmd = new MySqlCommand(sql, Connection);
        return cmd.ExecuteNonQuery();
    }

    public static int ExecuteSQL(string sql, MySqlParameter p)
    {
        MySqlCommand cmd = new MySqlCommand(sql, Connection);
        cmd.Parameters.Add(p);
        return cmd.ExecuteNonQuery();

    }
}
}

