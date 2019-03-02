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
using AutoUpdaterDotNET;

namespace MakerLab
{
    public partial class InicioSesion : Form
    {
        bool Mover;
        int MvalX;
        int MValY;
        public static string Usuario;
        public static string Contraseña;
        public static string Premium;
        public static string ClaveSesion;

        public InicioSesion()
        {
            Thread Carga = new Thread(new ThreadStart(InicioMakerDev));
            Carga.Start();
            Thread.Sleep(3000);
            InitializeComponent();
            Carga.Abort();
            AutoUpdater.ApplicationExitEvent += AutoUpdater_ApplicationExitEvent;
            this.WindowState = FormWindowState.Minimized;
            this.Show();
            this.WindowState = FormWindowState.Normal;

            /*/  WebClient webClient = new WebClient();
              if (!webClient.DownloadString("https://pastebin.com/raw/ATTJHSnN").Contains("1.0"))
              {
                  Actualizador actualizar = new Actualizador();
                  actualizar.ShowDialog(this);
                 // Thread.Sleep(2000000000);
              }
              else
              {
                  Notificacion Alerta2 = new Notificacion("MakerLab Dev", "Estas utilizando la ultima version disponible! 1.0");
                  Alerta2.ShowDialog(this);
              }/*/
        }

        //Función Principal
        public static int Ejecuta(string accion, string args)
        {
            WebClient peticiones = new WebClient();
            string url = "https://makerlabdev.000webhostapp.com/App/Sistema/ejecuta.php";
            string urlaccion = "?accion=" + accion;
            string urlargs = "&" + args;
            string urlcompilada = url + urlaccion + urlargs;

            string respuesta = peticiones.DownloadString(urlcompilada);
            if(respuesta == null)
            {
                return 0;
            }

            if(!respuesta.StartsWith("OK"))
            {
                ComprobarError(respuesta);
                return 0;
            }

            if (respuesta.StartsWith("OK:SESION_INICIADA:CLAVE_SESION:"))
            {
                ClaveSesion = respuesta.Replace("OK:SESION_INICIADA:CLAVE_SESION:", "");
            }

            return 1;
        }

        public static void LevantarError(string error)
        {
            Notificacion AlertaError = new Notificacion("Ocurrio un error!", error);
            AlertaError.ShowDialog();
        }

        public static int ComprobarError(string error)
        {
            Dictionary<string, string> Errores = new Dictionary<string, string>();
            Errores.Add("FALTAN_PARAMETROS", "Faltan parametros");
            Errores.Add("USUARIO_EXISTE", "El usuario ya existe");
            Errores.Add("USUARIO_MUY_CORTO", "El nombre de usuario es muy corto");
            Errores.Add("CONTRASENA_MUY_CORTA", "La contraseña es muy corta");
            Errores.Add("CLAVE_INVALIDA", "La clave de registro es invalida");
            Errores.Add("CONTRASENAS_NO_COINCIDEN", "Las contraseñas no coinciden");
            Errores.Add("CREDENCIALES_INVALIDOS", "Usuario o contraseña incorrectos\n contacta a contact.makerlab@gmail.com\n para obtener ayuda");
            Errores.Add("USUARIO_BANEADO", "Has sido baneado de la plataforma");
            Errores.Add("NO_ACCION", "No se ejecuto ninguna accion");
            Errores.Add("PRIVILEGIOS_INSUFICIENTES", "No tienes suficientes privilegios");
            Errores.Add("USUARIO_NO_EXISTE", "El usuario no existe");
            Errores.Add("SESION_NO_VALIDA", "Sesion no valida, has iniciado\n sesion en otro dispositivo?");

            if (!error.StartsWith("ERROR"))
            {
                LevantarError(error);
                return 0;
            }

            string mensaje = "Error indefinido "+error;
            string[] array = error.Split(':');
            if(array.Length == 2 && Errores.ContainsKey(array[1]))
            {
                string key = array[1];
                mensaje = Errores[key];
            }

            LevantarError(mensaje);
            return 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AutoUpdater.Start("https://pastebin.com/raw/216Ay5p8");
           // if (!Directory.Exists(path))
          //      Directory.CreateDirectory(path);
          //
          //  if (File.Exists(path + "/usuario.mlab") && File.ReadAllText(path) != "/usuario.mlab")
         //       UsuarioExiste = true;
            System.Timers.Timer timer = new System.Timers.Timer
            {
                Interval = 2 * 60 * 1000,
                SynchronizingObject = this
            };
            timer.Elapsed += delegate
            {
                AutoUpdater.Start("https://pastebin.com/raw/216Ay5p8");
            };
            timer.Start();
        }

        string oldText2 = string.Empty;
        char noigual = '=';
        char nointerro = '?';
        char noand = '&';
        char nopunto = '·';
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = (textBox1.Text.Trim() != "" && textBox2.Text.Trim() != "");

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

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = "Conectando...";
            if(Ejecuta("inicioSesion", "Usuario=" + textBox1.Text + "&Contraseña=" + textBox2.Text) == 1)
            {
                Usuario = textBox1.Text;
                Contraseña = textBox2.Text;
                button1.Text = "Revisando Cuenta";
                WebClient CompruebaInfo = new WebClient();
                string EsPremium = CompruebaInfo.DownloadString("https://makerlabdev.000webhostapp.com/App/Sistema/ejecuta.php?accion=esPremium&Usuario=" + Usuario);
                if (EsPremium == "1") {
                    button1.Text = "Esperando...";
                    Premium = EsPremium;
                    Notificacion Aviso = new Notificacion("Bienvenido " + textBox1.Text, "Estas ahora conectado! \n Eres un usuario Premium!");
                    Aviso.ShowDialog(this);
                }
                else if (EsPremium == "2")
                {
                    button1.Text = "Esperando...";
                    Premium = EsPremium;
                    Notificacion Aviso = new Notificacion("Bienvenido " + textBox1.Text, "Estas ahora conectado! \n Eres un admin!");
                    Aviso.ShowDialog(this);
                }
                else
                {
                    button1.Text = "Esperando...";
                    Premium = EsPremium;
                    Notificacion Aviso = new Notificacion("Bienvenido " + textBox1.Text, "Estas ahora conectado!");
                    Aviso.ShowDialog(this);
                }
                button1.Text = "Iniciar Sesión";
                Thread Inicio = new Thread(new ThreadStart(MakerLabDev));
                Inicio.Start();
                Thread Carga = new Thread(new ThreadStart(InicioMakerDev));
                Carga.Start();
                this.Close();
                Thread.Sleep(5000);
                Carga.Abort();
            }
            button1.Text = "Iniciar Sesión";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Registro Re = new Registro(this);
            Re.ShowDialog();
            textBox1.Text = "";
            textBox2.Text = "";
            button1.Enabled = false;
        }
        string oldText = string.Empty;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = (textBox1.Text.Trim() != "" && textBox2.Text.Trim() != "");

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

        public void InicioMakerDev()
        {
            Application.Run(new PantallaSplash());
        }

        private void AutoUpdater_ApplicationExitEvent()
        {
            Text = @"Closing application...";
            Thread.Sleep(2000);
            Notificacion Aviso = new Notificacion("Actualizacion requerida!", "Debes de actualizar la aplicacion!");
            Aviso.ShowDialog(this);
            Application.Exit();
            this.Close();
        }

        public void MakerLabDev()
        {
            //  string[] credenciales = File.ReadAllLines(path + "/usuario.mlab");
            Application.Run(new MakerLab_Dev());
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Mover = true;
            MvalX = e.X;
            MValY = e.Y;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            Mover = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Mover == true)
            {
                SetDesktopLocation(MousePosition.X - MvalX, MousePosition.Y - MValY);
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Mover = true;
            MvalX = e.X;
            MValY = e.Y;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Mover = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Mover == true)
            {
                SetDesktopLocation(MousePosition.X - MvalX, MousePosition.Y - MValY);
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (button1.Enabled == true)
                {
                    button1_Click(null, null);
                }
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (button1.Enabled == true)
                {
                    button1_Click(null, null);
                }
            }
        }
    }
}
