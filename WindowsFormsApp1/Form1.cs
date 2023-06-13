using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.DataBase;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var dbContext = new DatabaseContext())
            {
                if (dbContext.Employees.Any(x => x.Login == TextBoxLogin.Text))
                {
                    if(dbContext.Employees.Any(x => x.Password == TextBoxPassword.Text))
                    {
                        MessageBox.Show("Вы успешно вошли");

                        Form2 form2 = new Form2();
                        form2.Show();
                        Hide();
                    }
                    else
                    {
                        MessageBox.Show("Неверный пароль");
                    }
                }
                else
                {
                    MessageBox.Show("Неверный логин");
                }          
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                // Если флажок отмечен, показываем пароль
                TextBoxPassword.UseSystemPasswordChar = false;
            }
            else
            {
                // Если флажок снят, скрываем пароль
                TextBoxPassword.UseSystemPasswordChar = true;
            }
        }


    }
}
