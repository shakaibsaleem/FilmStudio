using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace FilmStudio
{
    public class mySQLcon
    {
        public SqlConnection con;

        public mySQLcon()
        {
            const string conString = "Data Source = .\\SQLEXPRESS;Initial Catalog = FilmStudio; Persist Security Info=True;User ID = sa; Password=uiop7890;";
            con = new SqlConnection();
            con.ConnectionString = conString;
            con.Open();
        }
    }
}
