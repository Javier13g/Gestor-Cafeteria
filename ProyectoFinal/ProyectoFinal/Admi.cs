using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAPA_NEGOCIO;

namespace ProyectoFinal
{
    public partial class PanelEmpleado : Form
    {
        CN_EMPLEADO objectoCE = new CN_EMPLEADO();
        private string idCliente = null;
        private bool Editar = false;

        public PanelEmpleado()
        {
            InitializeComponent();

        }

        private void limpiarDatoaFormulario()
        {
            txtNombreEmpleado.Clear();
            txtApellidoEmpleado.Clear();
            comboBoxSexoEmpleado.Items.Clear();
            txtCedulaEmpleado.Clear();
            txtNacionalidadEmpleado.Clear();
            txtDireccionEmpleado.Clear();
            comboBoxSeguroEmpleado.Items.Clear();
            txtTelefonoEmpleado.Clear();
        }

      

        private void MostrarEmpleados()
        {
            CN_EMPLEADO objeto = new CN_EMPLEADO();
            dataGridEmpleado.DataSource = objeto.MostrarEmp();
        }

        private void PanelEmpleado_Load(object sender, EventArgs e)
        {
            MostrarEmpleados();
           
        }

        private void btnGuardarEmpleados_Click(object sender, EventArgs e)
        {
            try
            {
                /*int CED = int.Parse(txtCedula.Text);*/
                objectoCE.GuardarEmple(txtNombreEmpleado.Text, txtApellidoEmpleado.Text, comboBoxSexoEmpleado.Text, txtEdadEmpleado.Text,
                    txtCedulaEmpleado.Text, txtNacionalidadEmpleado.Text, txtDireccionEmpleado.Text, comboBoxSeguroEmpleado.Text,
                    txtTelefonoEmpleado.Text);
                MessageBox.Show("CORRECTOOOO");
                MostrarEmpleados();
                limpiarDatoaFormulario();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR, SE DEBIO A: " + ex);
            }
        }
    }
}
