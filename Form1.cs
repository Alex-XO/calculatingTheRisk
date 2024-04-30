using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatingTheRisk
{
    public partial class Form1 : Form
    {
        private double P;
        private double L;
        private double U;
        private double lambda;

        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox4.ReadOnly == false)
            {
                textBox4.ReadOnly = true;
                textBox4.Text = "";
            }
            else
                textBox4.ReadOnly = false;
        }

        private void get_parameters()
        {
            this.P = ParseParameter(textBox1.Text);
            this.U = ParseParameter(textBox2.Text);
            this.lambda = ParseParameter(textBox3.Text);
            this.L = textBox4.ReadOnly ? 0 : ParseLimitedParameter(textBox4.Text);

            double ParseParameter(string text)
            {
                if (double.TryParse(text.Replace('.', ','), out double value) && value >= 0)
                    return value;
                return 0;
            }

            double ParseLimitedParameter(string text)
            {
                if (double.TryParse(text.Replace('.', ','), out double value) && value >= 0 && value <= 1)
                    return value;
                return 0;
            }
        }


        private double calculate()
        {
            return Math.Round((this.P * (1 - this.L) * this.U * this.lambda * 365), 2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.get_parameters();
            label6.Text = Convert.ToString(this.calculate());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
