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
    public partial class Notificacion : Form
    {
        public Notificacion(string titulo,string subtitulo)
        {
            InitializeComponent();
            TituloNotificacion.Text = titulo;
            SubTituloNotificacion.Text = subtitulo;
        }

        private void boton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
