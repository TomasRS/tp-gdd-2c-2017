using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.Login
{
    public partial class EleccionRol : Form
    {
        public EleccionRol()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void volverButton_Click(object sender, EventArgs e)
        {
            this.Close();
            (new LoginForm()).Show();
        }

        private void aceptarButton_Click(object sender, EventArgs e)
        {
            /*Este boton lleva al menu principal el cual se cargara dependiendo del rol
            que se tenga por defecto o bien si tiene muchos entonces el que eligio*/
        }
    }
}
