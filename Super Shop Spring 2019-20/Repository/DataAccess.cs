using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Shop_Spring_2019_20.Repository
{
    public class DataAccess:IDisposable
    {
        private SqlConnection connection;
        private SqlCommand command;
        public DataAccess()
        {
            //this.connection = new SqlConnection(@"data source=.\sqlexpress;initial catalog=Spring 2019-20;integrated security=true;");
            this.connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SuperShop"].ConnectionString);
            this.connection.Open();
        }

        public SqlDataReader GetData(string sql)
        {
            this.command = new SqlCommand(sql,this.connection);
            return this.command.ExecuteReader();
        }

        public int ExecuteQuery(string sql)
        {
            this.command = new SqlCommand(sql,this.connection);
            return this.command.ExecuteNonQuery();
        }

        public void Dispose()
        {
            this.connection.Close();
        }
    }
}
