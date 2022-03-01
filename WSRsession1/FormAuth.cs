using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Session1
{
    public partial class FormAuth : Form
    {
        public FormAuth()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) && string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            var userRole = DBHelper.CmdScalar($"SELECT [ID_Role] FROM [dbo].[User] WHERE [Email] = '{textBox1.Text}' AND [Password] = '{textBox2.Text}'");
            if (userRole != null)
            {
                switch (userRole)
                {
                    case "A":
                        FormAdminMenu formAdmin = new FormAdminMenu();
                        formAdmin.Show();
                        break;
                    case "C":
                        FormCoordinatorMenu formCoordinator = new FormCoordinatorMenu();
                        formCoordinator.Show();
                        break;
                    case "R":
                        FormRacerMenu formRacer = new FormRacerMenu();
                        formRacer.Show();
                        break;
                }
            }
            else MessageBox.Show("Такого пользователя не существует");
        }
    }
}
