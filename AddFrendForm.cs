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
    public partial class AddFrendForm : Form
    {
        private readonly char[] warn = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
        private MessangerAPI.Core.MessangerAPI Owner;

        public AddFrendForm(MessangerAPI.Core.MessangerAPI owner)
        {
            InitializeComponent();
            Owner = owner;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task.Run(Add);
        }

        private async Task Add()
        {
            if (warn.Contains(textBox1.Text[0]))
            {
                MessageBox.Show("Имя не может начинаться с цифры");
                return;
            }

            try
            {
                await Owner.AddFrend(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("Ошибка!");
                return;

            }

            BeginInvoke(new MethodInvoker(Close));
        }
    }
}
