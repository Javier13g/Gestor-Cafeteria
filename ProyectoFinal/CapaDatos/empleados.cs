using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class empleados
    {
        private Conexion2 conexion = new Conexion2();

        SqlDataReader lectura;
        DataTable TABLA = new DataTable();
        SqlCommand coronel = new SqlCommand();

        public DataTable MostrarEmpleados()
        {
            coronel.Connection = conexion.ConexionOupen();
            coronel.CommandText = "MostrarEmpleados";
            coronel.CommandType = CommandType.StoredProcedure;
            lectura = coronel.ExecuteReader();
            TABLA.Load(lectura);
            
            conexion.ConexionClous();
            return TABLA;
        }

        public void GuardarEmpleados(string nombre, string apellido, string sexo,
            string edad, string cedula, string nacionalidad, string direccion,
            string seguro, string telefono)
        {
            coronel.Connection = conexion.ConexionOupen();
            coronel.CommandText = "GuardarEmpleados";
            coronel.CommandType = CommandType.StoredProcedure;
            coronel.Parameters.AddWithValue("@nombre", nombre);
            coronel.Parameters.AddWithValue("@apellido", apellido);
            coronel.Parameters.AddWithValue("@sexo", sexo);
            coronel.Parameters.AddWithValue("@edad", edad);
            coronel.Parameters.AddWithValue("@cedula", cedula);
            coronel.Parameters.AddWithValue("@nacionalidad", nacionalidad);
            coronel.Parameters.AddWithValue("@direccion", direccion);
            coronel.Parameters.AddWithValue("@seguro", seguro);
            coronel.Parameters.AddWithValue("@telefono", telefono);
            coronel.ExecuteNonQuery();
            coronel.Parameters.Clear();
        }
    }
}
