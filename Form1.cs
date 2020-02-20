using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSH_CountdownTimer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1OnClick(object sender, EventArgs e)
        {
            for(int i=0; i <= 30; i++)
            {
                comboBox1.Items.Add(i.ToString());
            }
        }

        private void comboBox2OnClick(object sender, EventArgs e)
        {
            for (int i = 0; i <= 60; i++)
            {
                comboBox2.Items.Add(i.ToString());
            }
        }
    }
}
