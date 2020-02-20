using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace CSH_CountdownTimer
{
    public partial class Form1 : Form
    {
        int preostaleSekunde;
        int sekundeBlinkanja = 300;
        int flag = 1;
        SoundPlayer zadnjihPet = new SoundPlayer(CSH_CountdownTimer.Properties.Resources.zadnjihPet5);
        SoundPlayer kraj = new SoundPlayer(CSH_CountdownTimer.Properties.Resources.kraj);
        
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

        private void normalniEkran()
        {
            FormBorderStyle = FormBorderStyle.Sizable;
            WindowState = FormWindowState.Normal;
            TopMost = false;
            comboBox1.Visible = true;
            comboBox2.Visible = true;
            button1.Visible = true;
            label1.Visible = false;
        }
        private void maksimiziraniEkran()
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            //TopMost = true;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            button1.Visible = false;
            label1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int minute = int.Parse(comboBox1.Text);
            int sekunde = int.Parse(comboBox2.Text);
            preostaleSekunde = minute * 60 + sekunde;

            if(preostaleSekunde > 0)
            {
                timerStart();
                maksimiziraniEkran();
            }
            else
            {
                normalniEkran();
            }
        }

        private void timerStart()
        {
            if(preostaleSekunde > sekundeBlinkanja)
            {
                label1.Text = TimeSpan.FromSeconds(preostaleSekunde).ToString(@"mm\:ss");
                timer1.Interval = 1000;
            }
            else if(preostaleSekunde == sekundeBlinkanja)
            {
                label1.Text = TimeSpan.FromSeconds(preostaleSekunde).ToString(@"mm\:ss");
                timer1.Interval = 500;
            }
            else
            {
                label1.Text = TimeSpan.FromSeconds(preostaleSekunde).ToString(@"mm\:ss");
                timer1.Interval = 500;
            }
            timer1.Start();
        }

        private void timerStop()
        {
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timer1.Interval == 1000)
            {
                --preostaleSekunde;
            }
            else
            {
                if (flag == 0)
                    flag++;
                else
                {
                    --preostaleSekunde;
                    flag = 0;
                }
            }

            if(preostaleSekunde > sekundeBlinkanja)
            {
                label1.Text = TimeSpan.FromSeconds(preostaleSekunde).ToString(@"mm\:ss");
            }
            else if(preostaleSekunde == sekundeBlinkanja)
            {
                label1.Text = TimeSpan.FromSeconds(preostaleSekunde).ToString(@"mm\:ss");
                timer1.Interval = 500;
            }
            else
            {
                label1.Text = TimeSpan.FromSeconds(preostaleSekunde).ToString(@"mm\:ss");
                timer1.Interval = 500;
                label1.Visible = (!label1.Visible);
                if (label1.Visible)
                    zadnjihPet.Play();
            }

            if(preostaleSekunde == 0)
            {
                label1.Visible = true;
                kraj.Play();
                label1.Text = "Kraj!";
                timerStop();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Space)
            {
                if (timer1.Enabled)
                {
                    timerStop();
                    label1.Visible = true;
                }
                else
                    timerStart();
                return true;
            }
            if(keyData == Keys.Escape)
            {
                timerStop();
                normalniEkran();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
