using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Session1
{
    public partial class FormPayed : Form
    {
        public FormPayed()
        {
            InitializeComponent();
        }

        public FormPayed(string money, string racer)
        {
            InitializeComponent();
            moneyLabel.Text = money;
            racerLabel.Text = racer;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
