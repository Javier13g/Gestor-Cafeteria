using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CapaDatos
{
    public abstract class Conexion //NO SE PUEDE INSTANCIAR
    {
        private readonly string connectionString;
        public Conexion()
        {
            connectionString = "Server=localhost;Database=COMPAÑIA; integrated security= true";
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
