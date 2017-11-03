using System;
using System.Configuration;
using System.Data.SqlClient;

namespace DataTableToList.Configarations
{
    public static class MSSQLConn
    {
        public static SqlConnection GetMSSQLConn()
        {
            SqlConnection connMSSQLDB = null;
            try
            {
                connMSSQLDB = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLDBConn"].ConnectionString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return connMSSQLDB;
        }
    }
}
