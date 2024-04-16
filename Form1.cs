using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraSimples
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        enum operações
        {
            soma,
            subtrai,
            multiplica,
            Divide,
            Nenhuma
        }

        static operações ultimaOperacao = operações.Nenhuma;

        private void button1_Click(object sender, EventArgs e)
        {
            if (ultimaOperacao == operações.Nenhuma)
            {
                ultimaOperacao = operações.Divide;
            }
            else
            {
                fazerCalculo(ultimaOperacao);
            }
            textBoxDisplay.Text += (sender as Button).Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonApaga_Click(object sender, EventArgs e)
        {
            textBoxDisplay.Clear();
            ultimaOperacao = operações.Nenhuma;
        }

        private void buttonSubtrai_Click(object sender, EventArgs e)
        {
            if (ultimaOperacao == operações.Nenhuma)
            {
                ultimaOperacao = operações.subtrai;
            }
            else
            {
                fazerCalculo(ultimaOperacao);
            }
            textBoxDisplay.Text += (sender as Button).Text;
        }

        private void buttonMultiplica_Click(object sender, EventArgs e)
        {
            if (ultimaOperacao == operações.Nenhuma)
            {
                ultimaOperacao = operações.multiplica;
            }
            else
            {
                fazerCalculo(ultimaOperacao);
            }
            textBoxDisplay.Text += (sender as Button).Text;
        }

        private void buttonSoma_Click(object sender, EventArgs e)
        {
            if (ultimaOperacao == operações.Nenhuma)
            {
                ultimaOperacao = operações.soma;
            }
            else
            {
                fazerCalculo(ultimaOperacao);
            }
            textBoxDisplay.Text += (sender as Button).Text;
        }



        private void fazerCalculo(operações ultimaOperacao)
        {
            List<double> ListaDeNumeros = new List<double>();
            
            switch (ultimaOperacao)
            {
                case operações.soma:
                    ListaDeNumeros = textBoxDisplay.Text.Split('+').Select(double.Parse).ToList();
                    textBoxDisplay.Text = (ListaDeNumeros[0] + ListaDeNumeros[1]).ToString();
                    break;
                case operações.subtrai:
                    ListaDeNumeros = textBoxDisplay.Text.Split('-').Select(double.Parse).ToList();
                    textBoxDisplay.Text = (ListaDeNumeros[0] - ListaDeNumeros[1]).ToString();
                    break;
                case operações.multiplica:
                    ListaDeNumeros = textBoxDisplay.Text.Split('X').Select(double.Parse).ToList();
                    textBoxDisplay.Text = (ListaDeNumeros[0] * ListaDeNumeros[1]).ToString();
                    break;
                case operações.Divide:
                    try
                    {
                        ListaDeNumeros = textBoxDisplay.Text.Split('/').Select(double.Parse).ToList();
                        textBoxDisplay.Text = (ListaDeNumeros[0] / ListaDeNumeros[1]).ToString();
                    }
                    catch (DivideByZeroException)
                    {
                        textBoxDisplay.Text = "DIvisão por zero.";
                    }
                    break;
                case operações.Nenhuma:
                    break;
                default:
                    break;
            }
        }

        private void buttonVirgula_Click(object sender, EventArgs e)
        {
            textBoxDisplay.Text = textBoxDisplay.Text + ",";
        }

        private void buttonNum_Click(object sender, EventArgs e)
        {
            //textBoxDisplay.Text += "0";
            textBoxDisplay.Text += (sender as Button).Text;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBoxDisplay.Text);
        }

        private void button11_Click(object sender, EventArgs e)
       
            {
                textBoxDisplay.Text = textBoxDisplay.Text.Remove(textBoxDisplay.Text.Length - 1);
            }
        
        private void buttonEnter_Click(object sender, EventArgs e)
        {
            if (ultimaOperacao != operações.Nenhuma)
            {
                fazerCalculo(ultimaOperacao);
            }
            ultimaOperacao = operações.Nenhuma;
        }
    }
}
