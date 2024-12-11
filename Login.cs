using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyMessager
{
    public partial class Login : Form
    {
        private MessangerAPI.Core.MessangerAPI own;
        public Login(MessangerAPI.Core.MessangerAPI _own)
        {
            InitializeComponent();
            own = _own;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.textBox1.Text))
            {
                MessageBox.Show("Проверьте логин!");
                return;
            }
            if (string.IsNullOrWhiteSpace(this.textBox2.Text))
            {
                MessageBox.Show("Проверьте пороль!");
                return;
            }

            try
            {
                Task.Run(Log);
            }
            catch
            {
                MessageBox.Show("Проверьте логин или пороль");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.textBox1.Text))
            {
                MessageBox.Show("Проверьте логин!");
                return;
            }
            if (string.IsNullOrWhiteSpace(this.textBox2.Text))
            {
                MessageBox.Show("Проверьте пороль!");
                return;
            }

            try
            {
                Task.Run(Reg);
            }
            catch
            {
                MessageBox.Show("Такой пользователь уже зарегестрирован");
            }
        }

        private async Task Log()
        {
            await own.Login(textBox1.Text, textBox2.Text);
            IsLog();
        }

        private async Task Reg()
        {
            await own.Registr(textBox1.Text, textBox2.Text);
            IsLog();
        }

        private void IsLog()
        {
            if(own.GetIsLogin())
            {
                //MessageBox.Show("Test");
                this.Close();
            }
        }
    }
}
