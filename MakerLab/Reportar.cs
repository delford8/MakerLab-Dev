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
    public partial class Reportar : UserControl
    {
        public Reportar()
        {
            InitializeComponent();
            string EstadoTicket = MakerLab_Dev.Ejecuta("estadoTicket", "Usuario=" + InicioSesion.Usuario + "&Contraseña=" + InicioSesion.Contraseña + "&ClaveSesion=" + InicioSesion.ClaveSesion);
            if (EstadoTicket == "0")
            {
                label11.Text = "";   //Ticket
                label10.Text = "";   //Estado
                textBox1.ReadOnly = false;
                button2.Visible = false;
            }
            else
            {
                string[] EstadoSeparado = EstadoTicket.Split('&');

                var IDT = EstadoSeparado[0];
                var MensajeT = EstadoSeparado[1];
                var RespuestaT = EstadoSeparado[2];
                var EstadoT = EstadoSeparado[3];

                label11.Text = "Ticket: #" + IDT;   //Ticket
                label10.Text = "Estado: " + EstadoT;   //Estado
                textBox1.Text = MensajeT;
                textBox3.Text = RespuestaT;
                if (EstadoT == "Esperando Respuesta")
                {
                    textBox1.ReadOnly = false;
                }
                else
                {
                    textBox1.ReadOnly = true;
                }
                button2.Visible = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (label10.Text != "" && label10.Text.Substring(8) == "Esperando Respuesta")
            {
                if (MakerLab_Dev.Ejecuta("continuaTicket", "Usuario=" + InicioSesion.Usuario + "&Contraseña=" + InicioSesion.Contraseña + "&ClaveSesion=" + InicioSesion.ClaveSesion + "&C=" + textBox1.Text) == "1")
                {
                    string EstadoTicket = MakerLab_Dev.Ejecuta("estadoTicket", "Usuario=" + InicioSesion.Usuario + "&Contraseña=" + InicioSesion.Contraseña + "&ClaveSesion=" + InicioSesion.ClaveSesion);
                    if (EstadoTicket == "0")
                    {
                        label11.Text = "";   //Ticket
                        label10.Text = "";   //Estado
                        textBox1.ReadOnly = false;
                        button2.Visible = false;
                    }
                    else
                    {
                        string[] EstadoSeparado = EstadoTicket.Split('&');

                        var IDT = EstadoSeparado[0];
                        var MensajeT = EstadoSeparado[1];
                        var RespuestaT = EstadoSeparado[2];
                        var EstadoT = EstadoSeparado[3];

                        label11.Text = "Ticket: #" + IDT;   //Ticket
                        label10.Text = "Estado: " + EstadoT;   //Estado
                        textBox1.Text = MensajeT;
                        textBox3.Text = RespuestaT;
                        if (EstadoT == "Esperando Respuesta")
                        {
                            textBox1.ReadOnly = false;
                        }
                        else
                        {
                            textBox1.ReadOnly = true;
                        }
                        button2.Visible = true;
                    }
                    Notificacion AlertaError = new Notificacion("Ticket Enviado!", "Tu ticket de soporte fue enviado correctamente.");
                    AlertaError.ShowDialog();
                }
            }
            else
            {
                if (MakerLab_Dev.Ejecuta("enviarTicket", "Usuario=" + InicioSesion.Usuario + "&Contraseña=" + InicioSesion.Contraseña + "&ClaveSesion=" + InicioSesion.ClaveSesion + "&C=" + textBox1.Text) == "1")
                {
                    string EstadoTicket = MakerLab_Dev.Ejecuta("estadoTicket", "Usuario=" + InicioSesion.Usuario + "&Contraseña=" + InicioSesion.Contraseña + "&ClaveSesion=" + InicioSesion.ClaveSesion);
                    if (EstadoTicket == "0")
                    {
                        label11.Text = "";   //Ticket
                        label10.Text = "";   //Estado
                        textBox1.ReadOnly = false;
                        button2.Visible = false;
                    }
                    else
                    {
                        string[] EstadoSeparado = EstadoTicket.Split('&');

                        var IDT = EstadoSeparado[0];
                        var MensajeT = EstadoSeparado[1];
                        var RespuestaT = EstadoSeparado[2];
                        var EstadoT = EstadoSeparado[3];

                        label11.Text = "Ticket: #" + IDT;   //Ticket
                        label10.Text = "Estado: " + EstadoT;   //Estado
                        textBox1.Text = MensajeT;
                        textBox3.Text = RespuestaT;
                        if (EstadoT == "Esperando Respuesta")
                        {
                            textBox1.ReadOnly = false;
                        }
                        else
                        {
                            textBox1.ReadOnly = true;
                        }
                        button2.Visible = true;
                    }
                    Notificacion AlertaError = new Notificacion("Ticket Enviado!", "Tu ticket de soporte fue enviado correctamente.");
                    AlertaError.ShowDialog();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string EstadoTicket = MakerLab_Dev.Ejecuta("estadoTicket", "Usuario=" + InicioSesion.Usuario + "&Contraseña=" + InicioSesion.Contraseña + "&ClaveSesion=" + InicioSesion.ClaveSesion);
            if (EstadoTicket == "0")
            {
                label11.Text = "";   //Ticket
                label10.Text = "";   //Estado
                textBox1.ReadOnly = false;
                button2.Visible = false;
                Notificacion AlertaError = new Notificacion("No Hay Ticket!", "No has creado ningun ticket de soporte aun, puedes crear uno usando el formulario.");
                AlertaError.ShowDialog();
            }
            else
            {
                string[] EstadoSeparado = EstadoTicket.Split('&');

                var IDT = EstadoSeparado[0];
                var MensajeT = EstadoSeparado[1];
                var RespuestaT = EstadoSeparado[2];
                var EstadoT = EstadoSeparado[3];

                label11.Text = "Ticket: #" + IDT;   //Ticket
                label10.Text = "Estado: " + EstadoT;   //Estado
                textBox1.Text = MensajeT;
                textBox3.Text = RespuestaT;
                if (EstadoT == "Esperando Respuesta") {
                    textBox1.ReadOnly = false;
                }
                else
                {
                    textBox1.ReadOnly = true;
                }
                button2.Visible = true;
                Notificacion AlertaError = new Notificacion("Ticket Actualizado!", "El Ticket fue actualizado correctamente.");
                AlertaError.ShowDialog();
            }
        }

        string oldText = string.Empty;
        char noigual = '=';
        char nointerro = '?';
        char noand = '&';
        char nopunto = '·';

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

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas a punto de borrar tu ticket de soporte!", "Estas seguro?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (MakerLab_Dev.Ejecuta("cerrarTicket", "Usuario=" + InicioSesion.Usuario + "&Contraseña=" + InicioSesion.Contraseña + "&ClaveSesion=" + InicioSesion.ClaveSesion) == "1")
                {
                    label11.Text = "";   //Ticket
                    label10.Text = "";   //Estado
                    textBox1.Text = "Contacta con el equipo de soporte utilizando este formulario....";
                    textBox3.Text = "";
                    button2.Visible = false;
                    Notificacion AlertaError = new Notificacion("Ticket borrado!", "Tu ticket de soporte fue eliminado correctamente.");
                    AlertaError.ShowDialog();
                }
            }
        }
    }
}
