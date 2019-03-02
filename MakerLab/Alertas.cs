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
    public partial class Alertas : UserControl
    {
        DataTable TablaAlertas;
        int ultimasAlertas;

        public Alertas()
        {
            InitializeComponent();
            label1.Text = "Alertas (Cargando...)";
            MakerLab_Dev.Notificaciones = 0;
            usuarioToolStripMenuItem.Text = "Usuario: " + InicioSesion.Usuario;
            string NotificacionesRAW = MakerLab_Dev.Ejecuta("obtenAlertas", "Usuario=" + InicioSesion.Usuario + "&Contraseña=" + InicioSesion.Contraseña + "&ClaveSesion=" + InicioSesion.ClaveSesion);
            if (NotificacionesRAW != "0")
            {
                TablaAlertas = new DataTable();
                TablaAlertas.Columns.Add("Titulo", typeof(String));
                TablaAlertas.Columns.Add("Contenido", typeof(String));
                TablaAlertas.Columns.Add("Tipo", typeof(String));

                string[] NotificacionesSeparado = NotificacionesRAW.Split('&');

                var n = NotificacionesSeparado.Length / 4;

                for (int i = 0; i < n; i++)
                {
                    var Titulo = NotificacionesSeparado[0 + i * 4];
                    if (Titulo.StartsWith("OK:NotiT")) { Titulo = Titulo.Substring(8); }
                    var Contenido = NotificacionesSeparado[1 + i * 4];
                    var Personal = NotificacionesSeparado[2 + i * 4];
                    var Fin = NotificacionesSeparado[3 + i * 4];
                    MakerLabDev.BalloonTipTitle = "MakerLab Dev";
                    MakerLabDev.BalloonTipText = "Tienes alertas nuevas";
                    MakerLabDev.ShowBalloonTip(1000);

                    TablaAlertas.Rows.Add(Titulo, Contenido, Personal);
                }

                dataGridView1.DataSource = TablaAlertas;

                label1.Text = "Alertas (" + n + ")";
                MakerLab_Dev.Notificaciones = n;
                ultimasAlertas = n;
                label2.Visible = false;
                notificacionesToolStripMenuItem.Text = "Notificaciones ("+ n + ")";
            }
            else
            {
                label1.Text = "Alertas (0)";
                label2.Visible = true;
                ultimasAlertas = 0;
                MakerLab_Dev.Notificaciones = 0;
                notificacionesToolStripMenuItem.Text = "Notificaciones (0)";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string NotificacionesRAW = MakerLab_Dev.Ejecuta("obtenAlertas", "Usuario=" + InicioSesion.Usuario + "&Contraseña=" + InicioSesion.Contraseña + "&ClaveSesion=" + InicioSesion.ClaveSesion);
            if (NotificacionesRAW != "0")
            {
                TablaAlertas = new DataTable();
                TablaAlertas.Columns.Add("Titulo", typeof(String));
                TablaAlertas.Columns.Add("Contenido", typeof(String));
                TablaAlertas.Columns.Add("Tipo", typeof(String));
                
                string[] NotificacionesSeparado = NotificacionesRAW.Split('&');

                var n = NotificacionesSeparado.Length / 4;

                    for (int i = 0; i < n; i++)
                    {
                        var Titulo = NotificacionesSeparado[0 + i*4];
                        if (Titulo.StartsWith("OK:NotiT")) { Titulo = Titulo.Substring(8); }
                        var Contenido = NotificacionesSeparado[1 + i*4];
                        var Personal = NotificacionesSeparado[2 + i * 4];
                        var Fin = NotificacionesSeparado[3 + i*4];
                    if (n > ultimasAlertas)
                    {
                        MakerLabDev.BalloonTipTitle = "MakerLab Dev";
                        MakerLabDev.BalloonTipText = "Tienes alertas nuevas";
                        MakerLabDev.ShowBalloonTip(1000);
                    }

                        TablaAlertas.Rows.Add(Titulo, Contenido, Personal);
                        
                        //SISTEMA DE NOTIFICACIONES ANTIGUO (MEJOR DISEÑO PERO PEOR CONTROL)
                        //Label TituloL = new Label();
                        //Label ContenidoL = new Label();
                        //Label PersonalL = new Label();

                        //TituloL.Text = Titulo;
                        //ContenidoL.Text = Contenido;
                        //PersonalL.Text = Personal;

                        //TituloL.Left = 10;
                        //TituloL.Top = (i + 10) * 20;

                        //ContenidoL.Left = 120;
                        //ContenidoL.Top = (i + 10) * 20;

                        //PersonalL.Left = 140;
                        //PersonalL.Top = (i + 10) * 20;

                        //this.Controls.Add(TituloL);
                        //this.Controls.Add(ContenidoL);
                        //this.Controls.Add(PersonalL);
                        /////////////////////////////////////////////////////////////////////
                    }

                dataGridView1.DataSource = TablaAlertas;

                label1.Text = "Alertas (" + n + ")";
                MakerLab_Dev.Notificaciones = n;
                ultimasAlertas = n;
                label2.Visible = false;
                notificacionesToolStripMenuItem.Text = "Notificaciones (" + n + ")";
            }
            else
            {
                label1.Text = "Alertas (0)";
                ultimasAlertas = 0;
                label2.Visible = true;
                MakerLab_Dev.Notificaciones = 0;
                notificacionesToolStripMenuItem.Text = "Notificaciones (0)";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string accion = "obtenAlertas";
            string args = "Usuario=" + InicioSesion.Usuario + "&Contraseña=" + InicioSesion.Contraseña + "&ClaveSesion=" + InicioSesion.ClaveSesion;
            WebClient peticiones = new WebClient();
            string url = "https://makerlabdev.000webhostapp.com/App/Sistema/ejecuta.php";
            string urlaccion = "?accion=" + accion;
            string urlargs = "&" + args;
            string urlcompilada = url + urlaccion + urlargs;

            peticiones.DownloadStringAsync(new Uri(urlcompilada));
            peticiones.DownloadStringCompleted += new DownloadStringCompletedEventHandler(peticiones_DownloadStringCompleted);
        }


        void peticiones_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            string NotificacionesRAW = e.Result; //MakerLab_Dev.Ejecuta("obtenAlertas", "Usuario=" + InicioSesion.Usuario + "&Contraseña=" + InicioSesion.Contraseña + "&ClaveSesion=" + InicioSesion.ClaveSesion);
            if (NotificacionesRAW != "0")
            {
                TablaAlertas = new DataTable();
                TablaAlertas.Columns.Add("Titulo", typeof(String));
                TablaAlertas.Columns.Add("Contenido", typeof(String));
                TablaAlertas.Columns.Add("Tipo", typeof(String));

                string[] NotificacionesSeparado = NotificacionesRAW.Split('&');

                var n = NotificacionesSeparado.Length / 4;

                for (int i = 0; i < n; i++)
                {
                    var Titulo = NotificacionesSeparado[0 + i * 4];
                    if (Titulo.StartsWith("OK:NotiT")) { Titulo = Titulo.Substring(8); }
                    var Contenido = NotificacionesSeparado[1 + i * 4];
                    var Personal = NotificacionesSeparado[2 + i * 4];
                    var Fin = NotificacionesSeparado[3 + i * 4];
                    if (n > ultimasAlertas)
                    {
                        MakerLabDev.BalloonTipTitle = "MakerLab Dev";
                        MakerLabDev.BalloonTipText = "Tienes alertas nuevas";
                        MakerLabDev.ShowBalloonTip(1000);
                    }

                    TablaAlertas.Rows.Add(Titulo, Contenido, Personal);
                }

                dataGridView1.DataSource = TablaAlertas;

                label1.Text = "Alertas (" + n + ")";
                MakerLab_Dev.Notificaciones = n;
                label2.Visible = false;
                notificacionesToolStripMenuItem.Text = "Notificaciones (" + n + ")";
                ultimasAlertas = n;
            }
            else
            {
                label1.Text = "Alertas (0)";
                ultimasAlertas = 0;
                label2.Visible = true;
                MakerLab_Dev.Notificaciones = 0;
                notificacionesToolStripMenuItem.Text = "Notificaciones (0)";
            }
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MakerLab_Dev.Ejecuta("cerrarSesion", "Usuario=" + InicioSesion.Usuario + "&Contraseña=" + InicioSesion.Contraseña + "&ClaveSesion=" + InicioSesion.ClaveSesion) == "1")
            {
                cerrarSesionToolStripMenuItem.Text = "Cerrando sesión...";
                MakerLabDev.BalloonTipTitle = "MakerLab Dev";
                MakerLabDev.BalloonTipText = "Cerrando Sesión y Saliendo...";
                MakerLabDev.ShowBalloonTip(1000);
                Application.Exit();
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            salirToolStripMenuItem.Text = "Saliendo...";
            MakerLabDev.BalloonTipTitle = "MakerLab Dev";
            MakerLabDev.BalloonTipText = "Saliendo De La Aplicación...";
            MakerLabDev.ShowBalloonTip(1000);
            Application.Exit();
        }
    }
}
