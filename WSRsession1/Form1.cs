using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WSRsession1
{
    public partial class Form1 : Form
    {
        DateTime voteTime = new DateTime(2017, 7, 20, 0, 0, 0);
        public Form1()
        {
            InitializeComponent();

            timer1.Tick += timer1_Tick;
            timer1.Interval = 1000;
            timer1.Enabled = true;
            timer1.Start();
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan TimeRemaining = voteTime - DateTime.Now;
            label1.Text = $"До начала события осталось {TimeRemaining.Days/356} лет, {(TimeRemaining.Days % 356) / 30} месяцев, {(TimeRemaining.Days % 356) % 30} дней, {TimeRemaining.Hours} часов, {TimeRemaining.Minutes} часов, {TimeRemaining.Seconds} секунд";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(this);
            form.Show();

            this.Hide();
        }
    }
}
