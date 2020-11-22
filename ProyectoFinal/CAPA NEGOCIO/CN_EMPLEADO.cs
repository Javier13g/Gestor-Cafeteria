using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CAPA_NEGOCIO
{
    public class CN_EMPLEADO
    {
        private empleados objectoE = new empleados();

        public DataTable MostrarEmp()
        {
            DataTable TablaEmp = new DataTable();
            TablaEmp = objectoE.MostrarEmpleados();
            return TablaEmp;
        }

        public void GuardarEmple(string nombre, string apellido, string sexo,
            string edad, string cedula, string nacionalidad, string direccion,
            string seguro, string telefono)
        {
            objectoE.GuardarEmpleados(nombre, apellido, sexo, edad, cedula, nacionalidad,
                direccion, seguro, telefono);
        }

    }
}
