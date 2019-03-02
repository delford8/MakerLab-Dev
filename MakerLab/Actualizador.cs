using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace MakerLab
{
    public partial class Actualizador : Form
    {
        public Actualizador()
        {
            InitializeComponent();
        }

        private void boton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://makerlabdev.weebly.com/");
        }
    }
}
