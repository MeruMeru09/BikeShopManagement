using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeShopManagement
{
    public class Koneksyon
    {
        private SqlConnection conn;

        public SqlConnection GetConnection()
        {
            conn = new SqlConnection("Data Source=DESKTOP-GHE37H3;Initial Catalog=BikeShop;Integrated Security=True"); 
            return conn;
        }
    }
}
