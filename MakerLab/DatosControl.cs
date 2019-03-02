using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakerLab
{
    public partial class DatosControl : UserControl
    {
        string DatoID = "Dato";
        public DatosControl()
        {
            InitializeComponent();
            textBox3.Text = "Cargando datos...";
            textBox3.Text =  MakerLab_Dev.Ejecuta("obtenDatos", "Usuario=" + InicioSesion.Usuario + "&Contraseña=" + InicioSesion.Contraseña + "&ClaveSesion=" + InicioSesion.ClaveSesion + "&DatoID=" + DatoID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MakerLab_Dev.Ejecuta("guardaDatos", "Usuario=" + InicioSesion.Usuario + "&Contraseña=" + InicioSesion.Contraseña + "&ClaveSesion=" + InicioSesion.ClaveSesion + "&DatoID=" + DatoID + "&Dato=" + textBox1.Text) == "1")
            {
                Notificacion AlertaError = new Notificacion("Datos guardados!", "Los Datos fueron guardados correctamente.");
                AlertaError.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = "Cargando Datos...";
            textBox3.Text = MakerLab_Dev.Ejecuta("obtenDatos", "Usuario=" + InicioSesion.Usuario + "&Contraseña=" + InicioSesion.Contraseña + "&ClaveSesion=" + InicioSesion.ClaveSesion + "&DatoID=" + DatoID);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DatoID = textBox2.Text;
            label7.Text = "Variable Actual: " + DatoID;
        }

        string oldText2 = string.Empty;
        char noigual = '=';
        char nointerro = '?';
        char noand = '&';
        char nopunto = '·';
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

        string oldText = string.Empty;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.All(chr => chr != noigual))
            {
                if (textBox1.Text.All(chr => chr != nointerro))
                {
                    if (textBox1.Text.All(chr => chr != noand))
                    {
                        if (textBox1.Text.All(chr => chr != nopunto))
                        {
                            oldText = textBox1.Text;
                            textBox1.Text = oldText;

                            textBox1.BackColor = Color.White;
                            textBox1.ForeColor = Color.Black;
                        }
                        else
                        {
                            textBox1.Text = oldText;
                            textBox1.BackColor = Color.Red;
                            textBox1.ForeColor = Color.White;
                            textBox1.SelectionStart = textBox1.Text.Length;
                        }
                    }
                    else
                    {
                        textBox1.Text = oldText;
                        textBox1.BackColor = Color.Red;
                        textBox1.ForeColor = Color.White;
                        textBox1.SelectionStart = textBox1.Text.Length;
                    }
                }
                else
                {
                    textBox1.Text = oldText;
                    textBox1.BackColor = Color.Red;
                    textBox1.ForeColor = Color.White;
                    textBox1.SelectionStart = textBox1.Text.Length;
                }
            }
            else
            {
                textBox1.Text = oldText;
                textBox1.BackColor = Color.Red;
                textBox1.ForeColor = Color.White;
                textBox1.SelectionStart = textBox1.Text.Length;
            }
        }
    }
}
