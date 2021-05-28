using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookADO
{
    public class DBConnection
    {
        
        public SqlConnection GetConnection()
        {
            
            string connectiongString = @"Data Source=RAMYA\SQLEXPRESS;Initial Catalog=addressbook_service;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectiongString);
            return connection;
        }
    }
}
