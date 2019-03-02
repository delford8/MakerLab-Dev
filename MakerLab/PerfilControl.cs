using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace MakerLab
{
    public partial class PerfilControl : UserControl
    {
        public PerfilControl()
        {
            InitializeComponent();
            label1.Text = "Nombre de Usuario: " + InicioSesion.Usuario;
            label4.Text = "Clave de Sesión: "+InicioSesion.ClaveSesion;
            if (InicioSesion.Premium == "1")
            {
                label8.Text = "Tipo de Cuenta: Premium";
                pictureBox2.Visible = false;
            }
            else if (InicioSesion.Premium == "2")
            {
                label8.Text = "Tipo de Cuenta: Admin";
                Point newOrigin = new Point(label1.Location.X + label1.Size.Width - 5, label1.Location.Y + label1.Size.Height - 27);
                pictureBox2.Location = newOrigin;
                pictureBox2.Visible = true;
            }
            else
            {
                label8.Text = "Tipo de Cuenta: Normal";
                pictureBox2.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MakerLab_Dev.Ejecuta("cambiaDatosPerfil", "Usuario=" + InicioSesion.Usuario + "&Contraseña=" + InicioSesion.Contraseña + "&ClaveSesion=" + InicioSesion.ClaveSesion + "&QueCambiar=CambiarUsuario" + "&Cambio=" + textBox1.Text) == "1")
            {
                InicioSesion.Usuario = textBox1.Text;
                Notificacion AlertaError = new Notificacion("Usuario cambiado!", "El Nombre de Usuario fue cambiado correctamente.");
                AlertaError.ShowDialog();
                textBox1.Text = "Escribe aquí tu nuevo nombre de usuario";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == textBox3.Text)
            {
                if (MakerLab_Dev.Ejecuta("cambiaDatosPerfil", "Usuario=" + InicioSesion.Usuario + "&Contraseña=" + InicioSesion.Contraseña + "&ClaveSesion=" + InicioSesion.ClaveSesion + "&QueCambiar=CambiarContraseña" + "&Cambio=" + textBox2.Text) == "1")
                {
                    InicioSesion.Contraseña = textBox2.Text;
                    Notificacion AlertaError = new Notificacion("Contraseña cambiada!", "La Contraseña fue cambiada correctamente.");
                    AlertaError.ShowDialog();
                    textBox2.Text = "Escribe aquí tu nueva contraseña";
                    textBox3.Text = "Confirma tu nueva contraseña";
                }
            }
            else
            {
                Notificacion AlertaError = new Notificacion("Error!", "Las contraseñas no coinciden!");
                AlertaError.ShowDialog();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label1.Text = "Nombre de Usuario: " + InicioSesion.Usuario;
            Point newOrigin = new Point(label1.Location.X + label1.Size.Width - 5, label1.Location.Y + label1.Size.Height - 27);
            pictureBox2.Location = newOrigin;
            pictureBox2.Visible = true;

            WebClient CompruebaPremium = new WebClient();
            string EsPremium = CompruebaPremium.DownloadString("https://makerlabdev.000webhostapp.com/App/Sistema/ejecuta.php?accion=esPremium&Usuario=" + InicioSesion.Usuario);
            InicioSesion.Premium = EsPremium;

            if (InicioSesion.Premium == "1")
            {
                label8.Text = "Tipo de Cuenta: Premium";
            }
            else if (InicioSesion.Premium == "2")
            {
                label8.Text = "Tipo de Cuenta: Admin";
            }
            else
            {
                label8.Text = "Tipo de Cuenta: Normal";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        { //Borrado de Datos
            if (MessageBox.Show("Esta operación es irreversible!", "Estas seguro?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (MakerLab_Dev.Ejecuta("solicitaBorrar", "Usuario=" + InicioSesion.Usuario + "&Contraseña=" + InicioSesion.Contraseña + "&ClaveSesion=" + InicioSesion.ClaveSesion + "&QueBorrar=BorrarDatos") == "1")
                {
                    Notificacion AlertaError = new Notificacion("Datos Borrados!", "Tus datos fueron borrados correctamente.");
                    AlertaError.ShowDialog();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        { //Borrado de Cuenta
            if (MessageBox.Show("Esta operación es irreversible!", "Estas seguro?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (MakerLab_Dev.Ejecuta("solicitaBorrar", "Usuario=" + InicioSesion.Usuario + "&Contraseña=" + InicioSesion.Contraseña + "&ClaveSesion=" + InicioSesion.ClaveSesion + "&QueBorrar=BorrarCuenta") == "1")
                {
                    Notificacion AlertaError = new Notificacion("CUENTA BORRADA!", "TU CUENTA FUE BORRADA PERMANENTEMENTE.");
                    AlertaError.ShowDialog();
                }
            }
        }

        string oldText = string.Empty;
        char noigual = '=';
        char nointerro = '?';
        char noand = '&';
        char nopunto = '·';
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.All(chr => char.IsLetterOrDigit(chr) || char.IsSeparator(chr)))
            {
                oldText = textBox1.Text;
                textBox1.Text = oldText;

                textBox1.BackColor = System.Drawing.Color.White;
                textBox1.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                textBox1.Text = oldText;
                textBox1.BackColor = System.Drawing.Color.Red;
                textBox1.ForeColor = System.Drawing.Color.White;
                textBox1.SelectionStart = textBox1.Text.Length;
            }
        }

        string oldText2 = string.Empty;
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.All(chr => chr != noigual))
            {
                if (textBox2.Text.All(chr => chr != nointerro))
                {
                    if (textBox2.Text.All(chr => chr != noand))
                    {
                        if (textBox2.Text.All(chr => chr != nopunto))
                        {
                            oldText2 = textBox2.Text;
                            textBox2.Text = oldText2;

                            textBox2.BackColor = Color.White;
                            textBox2.ForeColor = Color.Black;
                        }
                        else
                        {
                            textBox2.Text = oldText2;
                            textBox2.BackColor = Color.Red;
                            textBox2.ForeColor = Color.White;
                            textBox2.SelectionStart = textBox2.Text.Length;
                        }
                    }
                    else
                    {
                        textBox2.Text = oldText2;
                        textBox2.BackColor = Color.Red;
                        textBox2.ForeColor = Color.White;
                        textBox2.SelectionStart = textBox2.Text.Length;
                    }
                }
                else
                {
                    textBox2.Text = oldText2;
                    textBox2.BackColor = Color.Red;
                    textBox2.ForeColor = Color.White;
                    textBox2.SelectionStart = textBox2.Text.Length;
                }
            }
            else
            {
                textBox2.Text = oldText2;
                textBox2.BackColor = Color.Red;
                textBox2.ForeColor = Color.White;
                textBox2.SelectionStart = textBox2.Text.Length;
            }
        }

        string oldText3 = string.Empty;
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.All(chr => chr != noigual))
            {
                if (textBox3.Text.All(chr => chr != nointerro))
                {
                    if (textBox3.Text.All(chr => chr != noand))
                    {
                        if (textBox3.Text.All(chr => chr != nopunto))
                        {
                            oldText3 = textBox3.Text;
                            textBox3.Text = oldText3;

                            textBox3.BackColor = Color.White;
                            textBox3.ForeColor = Color.Black;
                        }
                        else
                        {
                            textBox3.Text = oldText3;
                            textBox3.BackColor = Color.Red;
                            textBox3.ForeColor = Color.White;
                            textBox3.SelectionStart = textBox3.Text.Length;
                        }
                    }
                    else
                    {
                        textBox3.Text = oldText3;
                        textBox3.BackColor = Color.Red;
                        textBox3.ForeColor = Color.White;
                        textBox3.SelectionStart = textBox3.Text.Length;
                    }
                }
                else
                {
                    textBox3.Text = oldText3;
                    textBox3.BackColor = Color.Red;
                    textBox3.ForeColor = Color.White;
                    textBox3.SelectionStart = textBox3.Text.Length;
                }
            }
            else
            {
                textBox3.Text = oldText3;
                textBox3.BackColor = Color.Red;
                textBox3.ForeColor = Color.White;
                textBox3.SelectionStart = textBox3.Text.Length;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (textBox2.UseSystemPasswordChar == true)
            {
                textBox2.UseSystemPasswordChar = false;
                textBox3.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
                textBox3.UseSystemPasswordChar = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas a punto de cerrar la sesión", "Estas seguro?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (MakerLab_Dev.Ejecuta("cerrarSesion", "Usuario=" + InicioSesion.Usuario + "&Contraseña=" + InicioSesion.Contraseña + "&ClaveSesion=" + InicioSesion.ClaveSesion) == "1")
                {
                    Notificacion AlertaError = new Notificacion("Sesión cerrada!", "La sesión fue cerrada.");
                    AlertaError.ShowDialog();
                    Application.Exit();
                }
            }
        }
    }
}
