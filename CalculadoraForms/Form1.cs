using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraForms
{
    public partial class Form1 : Form
    {

        int numero1;
        string ultimoOp;
        bool Contador = false;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Contador = false;
            txbTela.Clear();
            txbAux.Clear();
        }
        private void Operador_Click(object sender, EventArgs e)
        {
            var botao = (Button)sender;
            
            if (Contador == false && txbTela.Text != "" && txbAux.Text == "")
            {
                // Obter o botão que está chamando o evento
                
                numero1 = int.Parse(txbTela.Text);
                txbTela.Clear();
                txbAux.Text = numero1.ToString() + botao.Text;
                ultimoOp = botao.Text;
                Contador = true;
            }
            else
            {
                if(txbTela.Text != "")
                {
                    btnIgual.PerformClick();
                    numero1 = int.Parse(txbTela.Text);
                    txbAux.Text = txbTela.Text + botao.Text;
                    numero1 = int.Parse(txbTela.Text);
                    txbTela.Text = "";
                    ultimoOp = botao.Text;
                    

                }
                
            }

        }
        private void Numero_Click(object sender, EventArgs e)
        {
            // Obter o botão que está chamando o evento
            var botao = (Button)sender;
            txbTela.Text += botao.Text;
           
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            

           if(txbTela.Text != "")
            {
                switch (ultimoOp)
                {

                    case "+":
                        
                        txbAux.Clear();
                        txbTela.Text = (numero1 + int.Parse(txbTela.Text)).ToString();
                        break;
                    case "-":
                        
                        txbAux.Clear();
                        txbTela.Text = (numero1 - int.Parse(txbTela.Text)).ToString();
                        break;
                    case "x":
                        
                        txbAux.Clear();
                        txbTela.Text = (numero1 * int.Parse(txbTela.Text)).ToString();

                        break;
                    case "÷":
                        
                        if (int.Parse(txbTela.Text) != 0)
                        {
                            txbAux.Clear();
                            txbTela.Text = (numero1 / int.Parse(txbTela.Text)).ToString();
                        }
                        else
                        {
                            MessageBox.Show("Impossivel dividir por zero!");
                            txbTela.Clear();
                            txbAux.Clear();
                        }


                        break;

                }
            }
            else
            {
                MessageBox.Show("Digite algum valor antes de clicar no igual");
            }

            Contador = false;
        }

        private void txbTela_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbAux_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
