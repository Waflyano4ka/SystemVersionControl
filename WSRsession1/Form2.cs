using Session1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WSRsession1
{
    public partial class Form2 : Form
    {
        DateTime voteTime = new DateTime(2017, 7, 20, 0, 0, 0);
        Form1 form1;
        public Form2(Form1 form)
        {
            InitializeComponent();
            form1 = form;

            timer1.Tick += timer1_Tick;
            timer1.Interval = 1000;
            timer1.Enabled = true;
            timer1.Start();

            this.Load += Form2_Load;
        }
        void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan TimeRemaining = voteTime - DateTime.Now;
            label1.Text = $"До начала события осталось {TimeRemaining.Days / 356} лет, {(TimeRemaining.Days % 356) / 30} месяцев, {(TimeRemaining.Days % 356) % 30} дней, {TimeRemaining.Hours} часов, {TimeRemaining.Minutes} часов, {TimeRemaining.Seconds} секунд";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form1.Show();
            this.Close();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            form1.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            var data = DBHelper.FillDataSet("SELECT * FROM Racer").Tables[0];
            List<DisplayRacer> racers = new List<DisplayRacer>();
            foreach (DataRow row in data.Rows)
            {
                var d = row.ItemArray;
                racers.Add(new DisplayRacer($"{d[1]} {d[2]} - 204 (UKR)", d[0].ToString()));
            }
            comboBox1.DataSource = racers;
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "name";
        }

        private class DisplayRacer
        {
            public DisplayRacer(string name, string id)
            {
                this.name = name;
                this.id = id;
            }

            public string name { get; set; }
            public string id { get; set; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int money = int.Parse(moneyBox.Text);
                money -= 10;
                if (money < 0) money = 0;
                moneyBox.Text = money.ToString();
                moneyLabel.Text = $"$ {money}";
            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int money = int.Parse(moneyBox.Text);
                money += 10;
                moneyBox.Text = money.ToString();
                moneyLabel.Text = $"$ {money}";
            }
            catch { }
        }

        private void moneyBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void moneyBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int money = int.Parse(moneyBox.Text);
                moneyLabel.Text = $"$ {money}";
            }
            catch { }
        }
    }
}
