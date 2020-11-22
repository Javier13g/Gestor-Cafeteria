using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using CapaSoporte.Cache;

namespace ProyectoFinal
{
    public partial class INICIO : Form
    {
        public INICIO()
        {
            InitializeComponent();
        }

        private void datosUSUARIO()
        {
            labelNombre.Text = UsuarioCache.PrimerNombre+" "+UsuarioCache.SegundoNombre;
            labelPosicion.Text = UsuarioCache.Posicion;
            labelCorreo.Text = UsuarioCache.Email;
        }

        //PERMITE ARRASTRAR EL FORM
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void btnCerrar_Click(object sender, EventArgs e) //CIERRA EL FORM
        {
            if (MessageBox.Show("Estas seguro de cerrar la aplicacion?", "Advertencia",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                Application.Exit();
        }

        private void btnMin_Click(object sender, EventArgs e) //MINIMIZA EL FORM
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void INICIO_MouseDown(object sender, MouseEventArgs e) //PERMITE ARRASTRAR DESDE EL FORM
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e) //PERMITE ARRASTAR DESDE EL PANEL SUPERIOR
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e) //PERMITE ARRASTAR DESDE EL PANEL IZQUIERDO
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            fecha.Text = DateTime.Now.ToLongDateString();
        }

        /*private void Salir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro de cerrar la sesion?", "Advertencia",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                this.Close();
        }*/

        private void INICIO_Load(object sender, EventArgs e)
        {
            datosUSUARIO();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro de cerrar la sesion?", "Advertencia",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                this.Close();
        }

        private void btnOrden_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panelazul.Visible = true;
            panelazul2.Visible = true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panelazul.Visible = false;
            panelazul2.Visible = false;
            AbrirFormOrden(new ORDEN());
            label1.Visible = false;
        }

        private void btnResumen_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panelazul.Visible = false;
            panelazul2.Visible = false;
        }

        //ESTA SECCION DE CODIGO SERA PARA ABRIR FORMS

        private void AbrirFormOrden(object formOrden)
        {
            if (this.paneLinicio.Controls.Count > 0)
                this.paneLinicio.Controls.RemoveAt(0);
            Form OrdenForm = formOrden as Form;
            OrdenForm.TopLevel = false;
            OrdenForm.Dock = DockStyle.Fill;
            this.paneLinicio.Controls.Add(OrdenForm);
            this.paneLinicio.Tag = OrdenForm;
            OrdenForm.Show();

        }

        private void AbrirFormEmpleado(object formEmpleado)
        {
            if (this.paneLinicio.Controls.Count > 0)
                this.paneLinicio.Controls.RemoveAt(0);
            Form EmpleForm = formEmpleado as Form;
            EmpleForm.TopLevel = false;
            EmpleForm.Dock = DockStyle.Fill;
            this.paneLinicio.Controls.Add(EmpleForm);
            this.paneLinicio.Tag = EmpleForm;
            EmpleForm.Show();

        }

        private void btnEmpleado_Click(object sender, EventArgs e)
        {
            AbrirFormEmpleado(new PanelEmpleado());
            label1.Visible = false;
        }
    }
}
