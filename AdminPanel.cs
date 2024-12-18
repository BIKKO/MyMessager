using MessangerAPI.Core;
using MessangerAPI.Core.Model;
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
    public partial class AdminPanel : Form
    {
        MessangerAPI.Core.MessangerAPI admin;
        List<User_Ad> users;

        public AdminPanel(MessangerAPI.Core.MessangerAPI own)
        {
            InitializeComponent();
            admin = own;
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            Task.Run(GetUsers);
        }

        private async Task GetUsers()
        {
            users = await admin.Admin();
            var user_name = users.Select(u => u.login).ToArray();
            BeginInvoke(new MethodInvoker(() =>
            {
                comboBox1.DataSource = user_name;
            }));
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = users.Where(u => u.login == comboBox1.SelectedItem.ToString())
                .Select(u => u.id).First();
            BeginInvoke(new MethodInvoker(async () =>
            {
                numericUpDown1.Value = await admin.DostAD(id);
            }));
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Task.Run(Save);
        }

        private async Task Save()
        {
            BeginInvoke(new MethodInvoker(async () =>
            {
                if (comboBox1.SelectedItem.ToString() == "admin")
                {
                    MessageBox.Show("Нельзя изменить");
                    return;
                }
                var id = users.Where(u => u.login == comboBox1.SelectedItem.ToString())
                    .Select(u => u.id).First();
                await admin.SetDost(id, (int)numericUpDown1.Value);
            }));
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "admin")
            {
                MessageBox.Show("Нельзя удалить");
                return;
            }
        }
    }
}
