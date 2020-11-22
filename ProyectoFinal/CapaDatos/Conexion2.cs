using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace CapaDatos
{
    public class Conexion2
    {
        private SqlConnection ConexionJevi = new SqlConnection("Server=(local);Database=COMPAÑIA;Integrated Security=true");

        public SqlConnection ConexionOupen()
        {
            if (ConexionJevi.State == ConnectionState.Closed)
                ConexionJevi.Open();
            return ConexionJevi;
        }

        public SqlConnection ConexionClous()
        {
            if (ConexionJevi.State == ConnectionState.Open)
                ConexionJevi.Close();
            return ConexionJevi;
        }
    }
}
