using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakerLab
{
    public partial class Registro : Form
    {
        bool Mover;
        int MvalX;
        int MValY;
        char noigual = '=';
        char nointerro = '?';
        char noand = '&';
        char nopunto = '·';

        public Registro(InicioSesion InicioS)
        {
            InitializeComponent();
        }

        string oldTextCC = string.Empty;
        private void CrearContraseña_TextChanged(object sender, EventArgs e)
        {
            CrearBoton.Enabled = (CrearUsuario.Text.Trim() != "" && CrearContraseña.Text.Trim() != "" && CrearReContraseña.Text.Trim() != "" && ClaveRegistro.Text.Trim() != "");

            if (CrearContraseña.Text.All(chr => chr != noigual))
            {
                if (CrearContraseña.Text.All(chr => chr != nointerro))
                {
                    if (CrearContraseña.Text.All(chr => chr != noand))
                    {
                        if (CrearContraseña.Text.All(chr => chr != nopunto))
                        {
                            oldTextCC = CrearContraseña.Text;
                            CrearContraseña.Text = oldTextCC;

                            CrearContraseña.BackColor = Color.Black;
                            CrearContraseña.ForeColor = Color.White;
                        }
                        else
                        {
                            CrearContraseña.Text = oldTextCC;
                            CrearContraseña.BackColor = Color.Red;
                            CrearContraseña.ForeColor = Color.White;
                        }
                    }
                    else
                    {
                        CrearContraseña.Text = oldTextCC;
                        CrearContraseña.BackColor = Color.Red;
                        CrearContraseña.ForeColor = Color.White;
                    }
                }
                else
                {
                    CrearContraseña.Text = oldTextCC;
                    CrearContraseña.BackColor = Color.Red;
                    CrearContraseña.ForeColor = Color.White;
                }
            }
            else
            {
                CrearContraseña.Text = oldTextCC;
                CrearContraseña.BackColor = Color.Red;
                CrearContraseña.ForeColor = Color.White;
            }
            CrearContraseña.SelectionStart = CrearContraseña.Text.Length;
        }

        private void CrearBoton_Click(object sender, EventArgs e)
        {
            CrearBoton.Text = "Conectando...";
            if(InicioSesion.Ejecuta("registrarUsuario", "Usuario=" + CrearUsuario.Text + "&Contraseña=" + CrearContraseña.Text + "&ReContraseña=" + CrearReContraseña.Text + "&claveRegistro=" + ClaveRegistro.Text) == 1)
            {
                CrearBoton.Text = "Esperando...";
                Notificacion Alerta = new Notificacion("Tu cuenta fue creada correctamente!", "Bienvenid@ "+ CrearUsuario.Text+"!");
                Alerta.ShowDialog(this);
                CrearBoton.Enabled = false;
                this.Close();
            }
            CrearBoton.Text = "Crear Cuenta";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        string oldTextCU = string.Empty;
        private void CrearUsuario_TextChanged(object sender, EventArgs e)
        {
            CrearBoton.Enabled = (CrearUsuario.Text.Trim() != "" && CrearContraseña.Text.Trim() != "" && CrearReContraseña.Text.Trim() != "" && ClaveRegistro.Text.Trim() != "");

            if (CrearUsuario.Text.All(chr => char.IsLetterOrDigit(chr) || char.IsSeparator(chr)))
            {
                oldTextCU = CrearUsuario.Text;
                CrearUsuario.Text = oldTextCU;

                CrearUsuario.BackColor = System.Drawing.Color.Black;
                CrearUsuario.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                CrearUsuario.Text = oldTextCU;
                CrearUsuario.BackColor = System.Drawing.Color.Red;
                CrearUsuario.ForeColor = System.Drawing.Color.White;
            }
            CrearUsuario.SelectionStart = CrearUsuario.Text.Length;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            Mover = false;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Mover = true;
            MvalX = e.X;
            MValY = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Mover == true)
            {
                SetDesktopLocation(MousePosition.X - MvalX, MousePosition.Y - MValY);
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Mover = false;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Mover = true;
            MvalX = e.X;
            MValY = e.Y;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Mover == true)
            {
                SetDesktopLocation(MousePosition.X - MvalX, MousePosition.Y - MValY);
            }
        }

        private void CrearUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (CrearBoton.Enabled == true)
                {
                    CrearBoton_Click (null, null);
                }
            }
        }

        private void CrearContraseña_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (CrearBoton.Enabled == true)
                {
                    CrearBoton_Click(null, null);
                }
            }
        }

        private void CrearReContraseña_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (CrearBoton.Enabled == true)
                {
                    CrearBoton_Click(null, null);
                }
            }
        }

        private void ClaveRegistro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (CrearBoton.Enabled == true)
                {
                    CrearBoton_Click(null, null);
                }
            }
        }

        string oldTextCRC = string.Empty;
        private void CrearReContraseña_TextChanged(object sender, EventArgs e)
        {
            CrearBoton.Enabled = (CrearUsuario.Text.Trim() != "" && CrearContraseña.Text.Trim() != "" && CrearReContraseña.Text.Trim() != "" && ClaveRegistro.Text.Trim() != "");

            if (CrearReContraseña.Text.All(chr => chr != noigual))
            {
                if (CrearReContraseña.Text.All(chr => chr != nointerro))
                {
                    if (CrearReContraseña.Text.All(chr => chr != noand))
                    {
                        if (CrearReContraseña.Text.All(chr => chr != nopunto))
                        {
                            oldTextCRC = CrearReContraseña.Text;
                            CrearReContraseña.Text = oldTextCRC;

                            CrearReContraseña.BackColor = Color.Black;
                            CrearReContraseña.ForeColor = Color.White;
                        }
                        else
                        {
                            CrearReContraseña.Text = oldTextCRC;
                            CrearReContraseña.BackColor = Color.Red;
                            CrearReContraseña.ForeColor = Color.White;
                        }
                    }
                    else
                    {
                        CrearReContraseña.Text = oldTextCRC;
                        CrearReContraseña.BackColor = Color.Red;
                        CrearReContraseña.ForeColor = Color.White;
                    }
                }
                else
                {
                    CrearReContraseña.Text = oldTextCRC;
                    CrearReContraseña.BackColor = Color.Red;
                    CrearReContraseña.ForeColor = Color.White;
                }
            }
            else
            {
                CrearReContraseña.Text = oldTextCRC;
                CrearReContraseña.BackColor = Color.Red;
                CrearReContraseña.ForeColor = Color.White;
            }
            CrearReContraseña.SelectionStart = CrearReContraseña.Text.Length;
        }

        string oldTextCR = string.Empty;
        private void ClaveRegistro_TextChanged(object sender, EventArgs e)
        {
            CrearBoton.Enabled = (CrearUsuario.Text.Trim() != "" && CrearContraseña.Text.Trim() != "" && CrearReContraseña.Text.Trim() != "" && ClaveRegistro.Text.Trim() != "");

            if (ClaveRegistro.Text.All(chr => char.IsLetterOrDigit(chr) || char.IsSeparator(chr)))
            {
                oldTextCR = ClaveRegistro.Text;
                ClaveRegistro.Text = oldTextCR;

                ClaveRegistro.BackColor = System.Drawing.Color.Black;
                ClaveRegistro.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                ClaveRegistro.Text = oldTextCR;
                ClaveRegistro.BackColor = System.Drawing.Color.Red;
                ClaveRegistro.ForeColor = System.Drawing.Color.White;
            }
            ClaveRegistro.SelectionStart = ClaveRegistro.Text.Length;
        }
    }
}
