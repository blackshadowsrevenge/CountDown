using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CountDown
{
    public partial class Form1 : Form
    {
        int h = 16;
        int m = 0;
        DateTime qt = DateTime.Today;
        TimeSpan ts = new TimeSpan(16, 0, 0);
        bool cd; //countdown switch
        bool set; // set quittin' time
        

        public Form1()
        {
            InitializeComponent();
            cd = false;
            set = false;
            timer1.Start();
            timer1.Interval = 1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timer1.Interval < 10000) { timer1.Interval += 10; } //label8.Text = timer1.Interval + "";}                    
            if (set) {
                label1.Hide();
                label2.Show();
                label3.Show();
                label4.Show();
                label5.Show();
                label6.Show();
                label7.Show();
                label8.Show();
            }
            else {
                label1.Show();
                label2.Hide();
                label3.Hide();
                label4.Hide();
                label5.Hide();
                label6.Hide();
                label7.Hide();
                label8.Hide();
            }
            if (cd)
            {
                ts = new TimeSpan(h, m, 0);
                qt = qt.Date + ts;
                TimeSpan span = (qt - DateTime.Now);
                if (timer1.Interval <= 1000) { label1.Text = String.Format("{0}h:{1}m:{2}s", span.Hours, span.Minutes, span.Seconds); }
                else { label1.Text = String.Format("{0}h:{1}m", span.Hours, span.Minutes); }
                // no seconds ---label1.Text = String.Format("{0}h:{1}m", span.Hours, span.Minutes);
                this.Text = "Quittin' Time";
                label8.Show();
            }
            else
            {
                label1.Text = DateTime.Now.ToString("hh:mm tt");
                // seconds ---    label1.Text = DateTime.Now.ToString("hh:mm:ss tt");
                // 24hr clock --- label1.Text = DateTime.Now.ToString("HH:mm:ss tt");
                this.Text = "Time";
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {
            cd = !cd; //count down switch toggle
            timer1.Interval = 100;
        }

        private void label2_Click(object sender, EventArgs e) { }

        private void label8_Click(object sender, EventArgs e)
        {
            set = !set;
            timer1.Interval = 100;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            h--;
            if(h < 0) { h = 23; }
            label3.Text = "" + (h - 1);
            label4.Text = "" + (h + 1);
            if (h == 0) { label3.Text = "23"; }            
            label2.Text = "" + h;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            {
                h++;
                if(h > 23) { h = 0; }
                label3.Text = "" + (h - 1);
                label4.Text = "" + (h + 1);
                if (h == 0) { label3.Text = "23"; }
                label2.Text = "" + h;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
        
            m = (m-15);
            if (m < 0) { m = 45; }
            label5.Text = "" + (m - 15); 
            label7.Text = "" + (m + 15);
            label6.Text = "" + m;
            if (m == 0) { label5.Text = "45"; }
            if ((m - 15) == 0) { label5.Text = "00"; }
            if (m == 0) { label6.Text = "00"; }
            if ((m + 15) >= 60) { label7.Text = "00"; }
        
        }

        private void label7_Click(object sender, EventArgs e)
        {
        
            m = (m + 15);
            if (m >= 60) { m = 0; }
            label5.Text = "" + (m - 15);
            label7.Text = "" + (m + 15);
            label6.Text = "" + m;
            if (m == 0) { label5.Text = "45"; }
            if ((m - 15) == 0) { label5.Text = "00"; }
            if (m == 0) { label6.Text = "00"; }
            if ((m + 15) >= 60) { label7.Text = "00"; }
        }


    }


    }
