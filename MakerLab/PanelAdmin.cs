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
    public partial class PanelAdmin : UserControl
    {
        DataTable TablaBaneados;
        DataTable TablaInfo;

        public PanelAdmin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MakerLab_Dev.Ejecuta("admin", "Usuario=" + InicioSesion.Usuario + "&Contraseña=" + InicioSesion.Contraseña + "&ClaveSesion=" + InicioSesion.ClaveSesion + "&Accion=Ban" + "&Afectado=" + textBox1.Text) == "1")
            {
                Notificacion Alerta = new Notificacion("Comando Ejecutado!", "Usuario: " + textBox1.Text + " Baneado!");
                Alerta.ShowDialog();
                textBox1.Text = "Nombre de Usuario...";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MakerLab_Dev.Ejecuta("admin", "Usuario=" + InicioSesion.Usuario + "&Contraseña=" + InicioSesion.Contraseña + "&ClaveSesion=" + InicioSesion.ClaveSesion + "&Accion=Unban" + "&Afectado=" + textBox1.Text) == "1")
            {
                Notificacion Alerta = new Notificacion("Comando Ejecutado!", "Usuario: " + textBox1.Text + " Desbaneado!");
                Alerta.ShowDialog();
                textBox1.Text = "Nombre de Usuario...";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MakerLab_Dev.Ejecuta("admin", "Usuario=" + InicioSesion.Usuario + "&Contraseña=" + InicioSesion.Contraseña + "&ClaveSesion=" + InicioSesion.ClaveSesion + "&Accion=Premium" + "&Afectado=" + textBox1.Text) == "1")
            {
                Notificacion Alerta = new Notificacion("Comando Ejecutado!", "Usuario: " + textBox1.Text + " ahora es Premium!");
                Alerta.ShowDialog();
                textBox1.Text = "Nombre de Usuario...";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (MakerLab_Dev.Ejecuta("admin", "Usuario=" + InicioSesion.Usuario + "&Contraseña=" + InicioSesion.Contraseña + "&ClaveSesion=" + InicioSesion.ClaveSesion + "&Accion=Unpremium" + "&Afectado=" + textBox1.Text) == "1")
            {
                Notificacion Alerta = new Notificacion("Comando Ejecutado!", "Usuario: " + textBox1.Text + " ahora no es Premium!");
                Alerta.ShowDialog();
                textBox1.Text = "Nombre de Usuario...";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MakerLab_Dev.Ejecuta("admin", "Usuario=" + InicioSesion.Usuario + "&Contraseña=" + InicioSesion.Contraseña + "&ClaveSesion=" + InicioSesion.ClaveSesion + "&Accion=BorrarDatos" + "&Afectado=" + textBox1.Text) == "1")
            {
                Notificacion Alerta = new Notificacion("Comando Ejecutado!", "Datos de: " + textBox1.Text + " borrados!");
                Alerta.ShowDialog();
                textBox1.Text = "Nombre de Usuario...";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas a punto de borrar la cuenta de un usuario", "Estas seguro?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (MakerLab_Dev.Ejecuta("admin", "Usuario=" + InicioSesion.Usuario + "&Contraseña=" + InicioSesion.Contraseña + "&ClaveSesion=" + InicioSesion.ClaveSesion + "&Accion=BorrarCuenta" + "&Afectado=" + textBox1.Text) == "1")
                {
                    Notificacion Alerta = new Notificacion("Comando Ejecutado!", "CUENTA DE: " + textBox1.Text + " BORRADA!");
                    Alerta.ShowDialog();
                    textBox1.Text = "Nombre de Usuario...";
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (MakerLab_Dev.Ejecuta("admin", "Usuario=" + InicioSesion.Usuario + "&Contraseña=" + InicioSesion.Contraseña + "&ClaveSesion=" + InicioSesion.ClaveSesion + "&Accion=CierraSesion" + "&Afectado=" + textBox1.Text) == "1")
            {
                Notificacion Alerta = new Notificacion("Comando Ejecutado!", "Sesión de: " + textBox1.Text + " cerrada!");
                Alerta.ShowDialog();
                textBox1.Text = "Nombre de Usuario...";
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string ClaveRegistro = MakerLab_Dev.Ejecuta("generarClaveRegistro", "codigoAdmin=" + textBox8.Text);
            if (ClaveRegistro != "0")
            {
                Notificacion Alerta = new Notificacion("Clave generada!", "La clave generada es: " + ClaveRegistro + " !");
                Alerta.ShowDialog();
                textBox8.Text = "Contraseña...";
            }
            else
            {
                Notificacion Alerta = new Notificacion("Error al generar clave!", "La clave no se pudo generar, tal vez la contraseña es incorrecta!");
                Alerta.ShowDialog();
                textBox8.Text = "Contraseña...";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label20.Visible = false;
            string BaneadosRAW = MakerLab_Dev.Ejecuta("admin", "Usuario=" + InicioSesion.Usuario + "&Contraseña=" + InicioSesion.Contraseña + "&ClaveSesion=" + InicioSesion.ClaveSesion + "&Accion=obtenerBans" + "&Afectado=GetBans");
            if (BaneadosRAW != "0")
            {
                TablaBaneados = new DataTable();
                TablaBaneados.Columns.Add("Usuarios Baneados", typeof(String));

                string[] BaneadosSeparados = BaneadosRAW.Split('&');

                var n = BaneadosSeparados.Length;

                for (int i = 0; i < n; i++)
                {
                    var UsuariosBaneados = BaneadosSeparados[0 + i];
                    if (UsuariosBaneados.StartsWith("OK:Bans:")) { UsuariosBaneados = UsuariosBaneados.Substring(8); }
                    if (UsuariosBaneados.StartsWith("FIN")) { break; }
                    if (UsuariosBaneados.StartsWith("NO_BANEADOS")) { break; }

                    TablaBaneados.Rows.Add(UsuariosBaneados);
                }

                dataGridView1.DataSource = TablaBaneados;

                if (n-1 == 0) {
                    label3.Text = "Usuarios Baneados(0)";
                    label11.Visible = true;
                }
                else
                {
                    int n2 = n - 1;
                    label3.Text = "Usuarios Baneados(" + n2 + ")";
                    label11.Visible = false;
                }
            }
            else
            {
                label3.Text = "Usuarios Baneados(0)";
                label11.Visible = true;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string InfoRAW = MakerLab_Dev.Ejecuta("admin", "Usuario=" + InicioSesion.Usuario + "&Contraseña=" + InicioSesion.Contraseña + "&ClaveSesion=" + InicioSesion.ClaveSesion + "&Accion=obtenerInfo" + "&Afectado=" + textBox1.Text);
            if (InfoRAW != "0")
            {
                TablaInfo = new DataTable();
                TablaInfo.Columns.Add("IDCuenta", typeof(String));
                TablaInfo.Columns.Add("Baneado", typeof(String));
                TablaInfo.Columns.Add("Premium", typeof(String));
                TablaInfo.Columns.Add("Clave Registro", typeof(String));
                TablaInfo.Columns.Add("Tickets Soporte", typeof(String));

                string[] InfoRAWSeparado = InfoRAW.Split('&');

                var IDCuenta = InfoRAWSeparado[0];
                var Baneado = InfoRAWSeparado[1];
                var Premium = InfoRAWSeparado[2];
                var ClaveRegistro = InfoRAWSeparado[3];
                var TicketsSoporte = InfoRAWSeparado[4];

                TablaInfo.Rows.Add(IDCuenta, Baneado, Premium, ClaveRegistro, TicketsSoporte);

                label12.Visible = false;
                dataGridView2.DataSource = TablaInfo;

            }
        }
    }
}
