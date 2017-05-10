using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saavedra.Nicolas.TrabajoPractico01
{
    public partial class TrabajoPractico01_Calculadora : Form
    {
        public TrabajoPractico01_Calculadora()
        {
            InitializeComponent();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            Numero num1 = new Numero(this.txtNumero1.Text);
            Numero num2 = new Numero(this.txtNumero2.Text);
            string operador = (this.cmbOperacion.SelectedItem.ToString());
            Calculadora calc = new Calculadora();

            double resultado = Calculadora.operar(num1, num2, operador);
            this.lblResultado.Text = resultado.ToString();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtNumero1.Text = Calculadora.limpiar(this.txtNumero1.Text);
            this.txtNumero2.Text = Calculadora.limpiar(this.txtNumero2.Text);
            this.lblResultado.Text = Calculadora.limpiar(this.lblResultado.Text);
            this.cmbOperacion.SelectedIndex = -1;
        }
    }
}
