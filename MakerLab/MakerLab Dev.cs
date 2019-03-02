using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Threading;

namespace MakerLab
{
    public partial class MakerLab_Dev : Form
    {
        bool Mover;
        int MvalX;
        int MValY;
        string TipoCuenta;
        public static int Notificaciones;

        public MakerLab_Dev()
        {
            InitializeComponent();
            Indicador.Height = pitem1.Height;
            Indicador.Top = pitem1.Top;
            inicioControl1.BringToFront();
            TituloControl.Text = "Inicio";
            NombreUsuario.Text = "Bienvenido" + "\n" + InicioSesion.Usuario + "!";
            if(InicioSesion.Premium == "1")
            {
                TipoCuenta = "Premium";
                panelAdminBoton.Visible = false;
                verificado.Visible = false;
            }
            else if (InicioSesion.Premium == "2")
            {
                TipoCuenta = "Admin";
                panelAdminBoton.Visible = true;
                verificado.Visible = true;
                int letras = InicioSesion.Usuario.Length;
                if (letras > 10)
                {
                    Point newOrigin = new Point(NombreUsuario.Location.X + NombreUsuario.Size.Width - 5, NombreUsuario.Location.Y + NombreUsuario.Size.Height - 27);
                    verificado.Location = newOrigin;
                }
                else
                {

                    int modificador = 10 * letras;
                    Point newOrigin = new Point(NombreUsuario.Location.X + NombreUsuario.Size.Width + modificador - 110, NombreUsuario.Location.Y + NombreUsuario.Size.Height - 27);
                    verificado.Location = newOrigin;
                }
            }
            else
            {
                TipoCuenta = "Normal";
                panelAdminBoton.Visible = false;
                verificado.Visible = false;
            }
            TipoDeCuenta.Text = "Tipo de Cuenta:" + "\n" + TipoCuenta;
        }


        public static string Ejecuta(string accion, string args)
        {
            WebClient peticiones = new WebClient();
            string url = "https://makerlabdev.000webhostapp.com/App/Sistema/ejecuta.php";
            string urlaccion = "?accion=" + accion;
            string urlargs = "&" + args;
            string urlcompilada = url + urlaccion + urlargs;

            string respuesta = peticiones.DownloadString(urlcompilada);
            if (respuesta == null)
            {
                return "0";
            }

            if (respuesta.StartsWith("OK:DATO:"))
            {
                return respuesta.Substring(8);
            }

            if (respuesta.StartsWith("OK:EsTi"))
            {
                return respuesta.Substring(7);
            }

            if (respuesta.StartsWith("NO_TICKET"))
            {
                return "0";
            }

            if (respuesta.StartsWith("CLAVE_REGISTRO:"))
            {
                return respuesta.Substring(15);
            }

            if (respuesta.StartsWith("OK:NotiT"))
            {
                return respuesta.Substring(8);
            }

            if (respuesta.StartsWith("OK:Bans:"))
            {
                return respuesta.Substring(8);
            }

            if (respuesta.StartsWith("OK:INFO:"))
            {
                return respuesta.Substring(8);
            }

            if (respuesta.StartsWith("NO_NOTIFICACION"))
            {
                return "0";
            }

            if (!respuesta.StartsWith("OK"))
            {
                ComprobarError(respuesta);
                return "0";
            }

            return "1";
        }

        public static void LevantarError(string error)
        {
            Notificacion AlertaError = new Notificacion("Ocurrio un error!", error);
            AlertaError.ShowDialog();
        }

        public static string ComprobarError(string error)
        {
            Dictionary<string, string> Errores = new Dictionary<string, string>();
            Errores.Add("FALTAN_PARAMETROS", "Faltan parametros");
            Errores.Add("USUARIO_EXISTE", "El usuario ya existe");
            Errores.Add("USUARIO_MUY_CORTO", "El nombre de usuario es muy corto o muy largo");
            Errores.Add("CONTRASENA_MUY_CORTA", "La contraseña es muy corta, minimo 8 caracteres");
            Errores.Add("CLAVE_INVALIDA", "La clave de registro es invalida");
            Errores.Add("CONTRASENAS_NO_COINCIDEN", "Las contraseñas no coinciden");
            Errores.Add("CREDENCIALES_INVALIDOS", "Usuario o contraseña incorrectos");
            Errores.Add("USUARIO_BANEADO", "Has sido baneado de la plataforma");
            Errores.Add("NO_ACCION", "No se ejecuto ninguna accion");
            Errores.Add("PRIVILEGIOS_INSUFICIENTES", "No tienes suficientes privilegios");
            Errores.Add("USUARIO_NO_EXISTE", "El usuario no existe");
            Errores.Add("SESION_NO_VALIDA", "Sesion no valida, has iniciado\n sesion en otro dispositivo?");
            Errores.Add("FUNCION_PREMIUM", "Esta función es solo para cuentas Premium!");
            Errores.Add("NO_TICKET", "No se encontro ningun ticket!");
            Errores.Add("TICKET_NO_DISPONIBLE", "El ticket solicitado no se encuentra disponible!");

            if (!error.StartsWith("ERROR"))
            {
                LevantarError(error);
                return "0";
            }

            string mensaje = "Error indefinido " + error;
            string[] array = error.Split(':');
            if (array.Length == 2 && Errores.ContainsKey(array[1]))
            {
                string key = array[1];
                mensaje = Errores[key];
            }

            LevantarError(mensaje);
            return "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BarraSuperior_MouseMove(object sender, MouseEventArgs e)
        {
            if (Mover == true)
            {
                SetDesktopLocation(MousePosition.X - MvalX - 210, MousePosition.Y - MValY);
            }
        }

        private void BarraSuperior_MouseDown(object sender, MouseEventArgs e)
        {
            Mover = true;
            MvalX = e.X;
            MValY = e.Y;
        }

        private void BarraSuperior_MouseUp(object sender, MouseEventArgs e)
        {
            Mover = false;
        }

        private void pitem1_Click(object sender, EventArgs e)
        {
            Indicador.Visible = true;
            Indicador.Height = pitem1.Height;
            Indicador.Top = pitem1.Top;
            inicioControl1.BringToFront();
            TituloControl.Text = "Inicio";
            alertas1.Visible = false;
        }

        private void pitem2_Click(object sender, EventArgs e)
        {
            Indicador.Visible = true;
            Indicador.Height = pitem2.Height;
            Indicador.Top = pitem2.Top;
            datosControl1.BringToFront();
            TituloControl.Text = "Datos";
            alertas1.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            perfilControl1.BringToFront();
            perfilControl1.Visible = true;
            TituloControl.Text = "Perfil";
            Indicador.Visible = false;
            alertas1.Visible = false;
        }

        private void panelAdminBoton_Click(object sender, EventArgs e)
        {
            panelAdmin1.BringToFront();
            panelAdmin1.Visible = true;
            TituloControl.Text = "Panel Admin";
            Indicador.Visible = true;
            Indicador.Height = panelAdminBoton.Height;
            Indicador.Top = panelAdminBoton.Top;
            alertas1.Visible = false;
        }

        private void pitem5_Click(object sender, EventArgs e)
        {
            Indicador.Visible = true;
            Indicador.Height = pitem5.Height;
            Indicador.Top = pitem5.Top;
            reportar1.BringToFront();
            TituloControl.Text = "MakerLab";
            alertas1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (alertas1.Visible == false)
            {
                alertas1.BringToFront();
                alertas1.Visible = true;
            }
            else
            {
                alertas1.SendToBack();
                alertas1.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           if (alertas1.Visible == false)
           {
                alertas1.BringToFront();
                alertas1.Visible = true;
            }
            else
            {
                alertas1.SendToBack();
                alertas1.Visible = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = "("+ Notificaciones + ")";
            if (Notificaciones > 0)
            {
                button3.Visible = true;
                button3.BringToFront();
                button2.Visible = false;
                button2.SendToBack();
            }
            else
            {
                button3.Visible = false;
                button3.SendToBack();
                button2.Visible = true;
                button2.BringToFront();
            }
        }
    }
}
