using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using CAPA_NEGOCIO;
using CapaSoporte.Cache;

namespace ProyectoFinal
{
    public partial class LOGIN : Form
    {
        public LOGIN()
        {
            InitializeComponent();
        }

        //PERMITE ARRASTRAR EL FORM
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "USUARIO")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.LightGray;
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Text = "USUARIO";
                txtUser.ForeColor = Color.DarkGray;
            }
        }

        private void txtpass_Enter(object sender, EventArgs e)
        {
            if (txtpass.Text == "CONTRASEÑA")
            {
                txtpass.Text = "";
                txtpass.ForeColor = Color.DarkGray;
                txtpass.UseSystemPasswordChar = true;
            }
        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
            if (txtpass.Text == "")
            {
                txtpass.Text = "CONTRASEÑA";
                txtpass.ForeColor = Color.DarkGray;
                txtpass.UseSystemPasswordChar = false;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro de cerrar la aplicacion?", "Advertencia",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                Application.Exit();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //////////////////////////////////////////////////////////////PERMITE ARRASTAR EL FORM
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }////////////////////////////////////////////////////////////PERMITE ARRASTRAR EL FORM

        private void btnLog_Click(object sender, EventArgs e)
        {
            if (txtUser.Text != "USUARIO")
            {
                if (txtpass.Text != "CONTRASEÑA")
                {
                    usuarioN USU = new usuarioN();
                    var validacion = USU.LoginUsuario(txtUser.Text, txtpass.Text);
                    if(validacion == true)
                    {
                        INICIO inicio = new INICIO();
                        MessageBox.Show("Bienvenido " + UsuarioCache.PrimerNombre); //akimekede
                        inicio.Show();
                        inicio.FormClosed += CerrarCesion;
                        this.Hide();
                    }
                    else
                    {
                        ERROR("Usuario o contraseña incorrectos o inexistentes, verifique los datos");
                        txtpass.Text = "Contraseña";
                        txtUser.Clear();
                    }

                }
                else ERROR("Digite la contraseña");
            }
            else ERROR("Digite el usuario");
        }

        private void ERROR(string mensaje)
        {
            labelError.Text = "    " + mensaje;
            labelError.Visible = true;
        }
        
        private void CerrarCesion(object sender, FormClosedEventArgs e)
        {
            txtpass.Text = "Password";
            txtpass.UseSystemPasswordChar = false;
            txtUser.Text = "Usuario";
            labelError.Visible = false;
            this.Show();
            
        }
    }
}
