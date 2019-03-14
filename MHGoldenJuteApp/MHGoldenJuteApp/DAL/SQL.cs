using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MHGoldenJuteApp.DAL
{

    public class SQL
    {
        public SqlConnection Connection { get; set; }

        public SqlCommand Command { get; set; }

        public SqlDataReader Reader { get; set; }

        public string Query { get; set; }

        public int RowCount { get; set; }

        public SQL()
        {
            Connection = new SqlConnection(@"Data Source=.;Initial Catalog=MHGoldenJute;Integrated Security=True");

        }
    }
}