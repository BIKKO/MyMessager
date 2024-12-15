using MessangerAPI.Core;
using MyMessager.Model;
using System.Configuration;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Security.Policy;

namespace MyMessager
{
    public partial class Form1 : Form
    {

        bool f = true;
        int buf_mes;
        int buf_chat;
        int buf_fre;
        List<(Panel, Label)> mes = new List<(Panel, Label)>();
        List<((Guid, string), Panel, Label, List<(Panel, Label)>, int, int)> chats =
            new List<((Guid, string), Panel, Label, List<(Panel, Label)>, int, int)>();
        List<Panel> frends = new List<Panel>();
        int MessPanWidth;
        int MessPanHeight;
        int butomPad;
        int start_mes;
        int const_start_mes;
        int start_fre;
        int mes_max_size;
        MessangerAPI.Core.MessangerAPI API;
        Login LoginForm;
        ((Guid, string), Panel, Label, List<(Panel, Label)>, int, int) obj;

        bool mess_update;
        Label update_lable;

        bool log;

        public Form1(bool debugStayt = false)
        {
            InitializeComponent();

            MessPanWidth = MessagesPan.Width;
            MessPanHeight = MessagesPan.Height;
            ScrollBarMess.Visible = false;
            ScrollBarMess.LargeChange = 1;
            ScrollBarMess.Value = ScrollBarMess.Maximum;
            ScrollBarChat.LargeChange = 1;
            ScrollBarChat.Visible = false;
            ScrollBarFrend.Visible = false;
            butomPad = 15;
            buf_mes = 0;
            start_mes = MessagesPan.Height;
            const_start_mes = start_mes;
            mes_max_size = 40;
            buf_chat = 0;
            buf_fre = 0;
            start_fre = 0;
            log = true;
            panel2.Visible = false;
            mess_update = false;

            ToolStripMenuItem CreateChat = new ToolStripMenuItem("Создать чат");
            CreateChat.Click += CreateChat_Click;
            ToolStripMenuItem RemuveFrend = new ToolStripMenuItem("Удалить из друзей");
            RemuveFrend.Click += DeleteFrend_Click;
            contextMenuFrend.Items.Add(CreateChat);
            contextMenuFrend.Items.Add(RemuveFrend);

            ToolStripMenuItem UpdateMess = new ToolStripMenuItem("Обновить");
            contextMenuMess.Items.Add(UpdateMess);
            UpdateMess.Click += UpdateMess_Click;

#if !DEBUG
            log = false;
            var appConfig = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
            var uri = appConfig.AppSettings.Settings["uri"].Value;
            API = new MessangerAPI.Core.MessangerAPI(uri);

            LoginForm = new Login(API);
            LoginForm.Show();
#elif DEBUG && de
            var appConfig = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
            var uri = appConfig.AppSettings.Settings["uri"].Value;
            API = new MessangerAPI.Core.MessangerAPI(uri);
            Task.Run(Login);
            DebugStayt = debugStayt;
#endif
        }

        private async void Login()
        {
            try
            {
                await API.Login("ts1", "123");
                log = true;
                MessageBox.Show("Вход под ts1 успешен");
            }
            catch
            {
                MessageBox.Show("Неудалось подключиться");
                BeginInvoke(new System.Windows.Forms.MethodInvoker(Close));
            }
        }

        private void UpdateScrollBar()
        {
            if (buf_mes > MessagesPan.Height)
            {
                int scrollBuf = buf_mes - MessagesPan.Height;

                if (ScrollBarMess.Value != ScrollBarMess.Maximum && ScrollBarMess.Maximum != 100)
                {
                    mes.ForEach((me) =>
                    {
                        me.Item1.Location = new Point(
                            0,
                            me.Item1.Location.Y - (ScrollBarMess.Maximum - ScrollBarMess.Value)
                            );
                    });
                }

                ScrollBarMess.Maximum = scrollBuf;
                start_mes = MessagesPan.Height;
                ScrollBarMess.Value = ScrollBarMess.Maximum;

                if (!ScrollBarMess.Visible)
                {
                    ScrollBarMess.Visible = true;
                }
            }
            else
            {
                if (ScrollBarMess.Visible) ScrollBarMess.Visible = false;
            }
        }

        private void CreateMes(string _mess, MessPosition position)
        {
            string message;
            int mess_width;
            FormanMess(_mess, out message, out mess_width);

            var u1 = new Label()
            {
                //MaximumSize = new Size(100, 0),
                Dock = (DockStyle)position,
                Text = message,
                AutoEllipsis = true,
                AutoSize = true,
                BackColor = position == MessPosition.Right ? Color.LightGray : Color.LightSlateGray,
            };
            u1.Height *= message.Split("\n").Length;
            u1.ContextMenuStrip = contextMenuMess;
            var d = new Label()
            {
                Text = new string('\n', message.Split("\n").Length - 2) + DateTime.Now.ToShortTimeString(),
                AutoEllipsis = true,
                AutoSize = true,
                BackColor = position == MessPosition.Right ? Color.LightGray : Color.LightSlateGray,
                Dock = (DockStyle)(position == MessPosition.Right ? MessPosition.Right : MessPosition.Left),
                Tag = "date",
            };
            d.Height *= message.Split("\n").Length - 1;
            d.Location = new Point(mess_width, 0);
            var testpan = new Panel()
            {
                Height = u1.Height,
                Width = MessagesPan.Width,
                Visible = true,
            };
            if (position == MessPosition.Right)
            {
                testpan.Controls.Add(u1);
                testpan.Controls.Add(d);
            }
            else
            {
                testpan.Controls.Add(d);
                testpan.Controls.Add(u1);
            }

            testpan.Location = new Point(0, start_mes - testpan.Height - butomPad);
            MessagesPan.Controls.Add(testpan);

            f = !f;
            buf_mes += testpan.Height + butomPad;

            if (mes.Count > 0)
                mes.ForEach(me => { me.Item1.Location = new Point(0, me.Item1.Location.Y - testpan.Height - butomPad); });
            mes.Add((testpan, u1));
        }

        private void FormanMess(string _mess, out string message, out int mess_width)
        {
            if (string.IsNullOrEmpty(Regex.Replace(_mess, @"\t|\r|\n", ""))) throw new ArgumentNullException();
            message = string.Empty;
            mess_width = 0;
            var mes_buf = _mess.Trim().Split('\n');

            foreach (var mes in mes_buf.Where(s => s != "\r" || s != "\n" || s != "\r\n"))
            {
                if (mes.Length >= mes_max_size)
                {
                    int last_i = 0;
                    mess_width = mes_max_size;
                    string buf = string.Empty;
                    for (int i = 0; i + mes_max_size < mes.Length; i += mes_max_size)
                    {
                        buf += mes.Substring(i, mes_max_size);
                        buf += "\n";
                        last_i = i + mes_max_size;
                    }
                    buf += mes.Substring(last_i, mes.Length - last_i);
                    message += buf;
                }
                else
                    message += mes;
                if (mess_width != mes_max_size)
                {
                    mess_width = Math.Max(mess_width, mes.Length);
                }
                message += "\n";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!log) return;

            if (mess_update)
            {
                UpdateMessade();
                return;
            }

            if (f)
            {
                try
                {
                    CreateMes(textBox1.Text, MessPosition.Right);
                }
                catch (ArgumentNullException)
                {
                    return;
                }
            }
            else
            {
                try
                {
                    CreateMes(textBox1.Text, MessPosition.Left);
                }
                catch (ArgumentNullException)
                {
                    return;
                }
            }

            textBox1.Text = string.Empty;
            textBox1.Lines = null;

            UpdateScrollBar();
        }

        private void UpdateMessade()
        {
            var mess = obj.Item4.Where(m => m.Item2.Equals(update_lable)).First();
            string msg = string.Empty;
            int mess_width;

            FormanMess(textBox1.Text, out msg, out mess_width);

            mess.Item2.Text = msg;
            var c = mess.Item1.Controls;
            foreach (Control c2 in c)
            {
                var lab = c2 as Label;
                if (lab.Tag == "date")
                {
                    lab.Location = new Point(mess_width, lab.Location.Y);
                    lab.Height *= msg.Split("\n").Length - 1;
                    var date = lab.Text.Replace("\n", "");
                    lab.Text = new string('\n', msg.Split("\n").Length - 2) + date;
                }
            }
            int mess_pan_hig = mess.Item1.Height;
            int Hig_delta = mess.Item2.Height - mess_pan_hig;
            mess.Item1.Height = mess.Item2.Height;
            buf_mes += Hig_delta;

            mes.Where(m => m != mess).ToList().ForEach(m =>
            {
                m.Item1.Location = new Point(0,m.Item1.Location.Y - Hig_delta);
            });

            mess.Item1.Location = new Point(0, mess.Item1.Location.Y - (mess.Item1.Height - mess_pan_hig));

            textBox1.Text = string.Empty;
            mess_update = false;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (!log) return;
            int delta = e.OldValue - e.NewValue;
            mes.ForEach((me) =>
            {
                me.Item1.Location = new Point(
                    0,
                    me.Item1.Location.Y + delta
                    );
            });
            start_mes += delta; ;
        }

        private void MessageRefreh_Tick(object sender, EventArgs e)
        {
#if !DEBUG
            if (!API.GetIsLogin())
            {
                if (Application.OpenForms["Login"] == null)
                {
                    LoginForm = new Login(API);
                    LoginForm.Show();
                }
                return;
            }
            log = true;
            MessageRefresh.Enabled = false;
            LoginForm.Close();
#endif
        }

        private void AddFrend()
        {
            if (!log) return;
            var u1 = new Label()
            {
                Text = "C" + start_fre,
                AutoSize = true,
                AutoEllipsis = true,
                Location = new Point(45/2 - 10, 45/2 - 10),
                Font = new Font(DefaultFont.FontFamily, 20, FontStyle.Regular),
            };
            var ico = new LogoPan()
            {
                Width = FrendPan.Width,
                Dock = DockStyle.Left,
                BackColor = Color.White,

            };
            var testpan = new Panel()
            {
                Height = FrendPan.Width,
                Width = FrendPan.Width,
                BackColor = Color.SlateGray,
                BorderStyle = BorderStyle.FixedSingle,
                Tag = "Chat"+start_fre,
            };
            start_fre++;

            testpan.Controls.Add(ico);
            ico.Controls.Add(u1);
            testpan.Location = new Point(0, buf_fre - ScrollBarFrend.Value);

            testpan.ContextMenuStrip = contextMenuFrend;

            FrendPan.Controls.Add(testpan);

            buf_fre += testpan.Height;

            frends.Add( testpan );

            if (buf_fre > FrendPan.Height)
            {
                ScrollBarFrend.Maximum = buf_fre - FrendPan.Height;
                frends.ForEach(ch => {
                    ch.Width = FrendPan.Width;
                    ch.Height = FrendPan.Width;
                });
                if (!ScrollBarFrend.Visible)
                {
                    ScrollBarFrend.Visible = true;
                }
            }
        }

        private void CreateChat_Click(object sender, EventArgs e)
        {
            var frends_tag = frends.Select(f => f.Tag.ToString()).Where(t => !t.Equals(null)).ToList();
            var chats_name = chats.Select(c => c.Item3.Text).ToList();
            var name = frends_tag.Except(chats_name);

            if (!name.Any()) return;

            var u1 = new Label()
            {
                Text = name.ToList()[0],
                Padding = new Padding(45, 0, 0, 0),
                AutoSize = true,
                AutoEllipsis = true,
            };
            var ico = new LogoPan()
            {
                Width = 45,
                Dock = DockStyle.Left,
                BackColor = Color.White,

            };
            var testpan = new Panel()
            {
                Height = 45,
                Width = ChatsPan.Width,
                BackColor = Color.SlateGray,
                BorderStyle = BorderStyle.FixedSingle,
            };

            testpan.Controls.Add(ico);
            testpan.Controls.Add(u1);
            testpan.Location = new Point(0, buf_chat - ScrollBarChat.Value);

            testpan.Click += SelectChat_Click;
            ico.Click += SelectChat_Click;
            u1.Click += SelectChat_Click;

            ChatsPan.Controls.Add(testpan);

            buf_chat += testpan.Height;
            chats.Add((new(), testpan, u1, new(), 0, const_start_mes));

            if (buf_chat > ChatsPan.Height)
            {
                ScrollBarChat.Maximum = buf_chat - ChatsPan.Height;

                if (!ScrollBarChat.Visible)
                {
                    ScrollBarChat.Visible = true;
                }
            }
        }

        private void DeleteFrend_Click(object sender, EventArgs e)
        {
            var t = contextMenuFrend.SourceControl as Panel;
            var pan = chats.Where(c => c.Item3.Text == t.Tag.ToString()).Select(s => s.Item2).First();

            ChatsPan.Controls.Remove(pan);
            chats.Remove(chats.Where(c => c.Item3.Text == t.Tag.ToString()).First());
            FrendPan.Controls.Remove(t);
            frends.Remove(t);
            mes.Clear();
            panel2.Visible = false;

            buf_chat -= pan.Height;
            buf_fre -= t.Height;

            chats.ForEach(chat => 
            {
                chat.Item2.Location = new Point(0, chat.Item2.Location.Y - pan.Height);
            });

            frends.ForEach(frend =>
            {
                frend.Location = new Point(0, frend.Location.Y - t.Height);
            });
        }

        private void UpdateMess_Click(object sender, EventArgs e)
        {
            var upd_mes = contextMenuMess.SourceControl as Label;
            if (upd_mes == null) return;
            textBox1.Text = upd_mes.Text;
            update_lable = upd_mes;
            mess_update = true;
        }

        private void FrendAddbutton_Click(object sender, EventArgs e)
        {
            if (!log) return;
            AddFrend();
        }

        private void ScrollBarChat_Scroll(object sender, ScrollEventArgs e)
        {
            if (!log) return;
            int delta = e.OldValue - e.NewValue;
            chats.ForEach((ch) =>
            {
                ch.Item2.Location = new Point(
                    0,
                    ch.Item2.Location.Y + delta
                    );
            });
        }

        private void MessagesPan_SizeChanged(object sender, EventArgs e)
        {
            if (!log) return;
            if (buf_mes > MessagesPan.Height)
            {
                if (!ScrollBarMess.Visible)
                    ScrollBarMess.Visible = true;
            }
            else
                if (ScrollBarMess.Visible) ScrollBarMess.Visible = false;

            if (MessagesPan.Width != MessPanWidth)
                mes.ForEach(m =>
                {
                    m.Item1.Width = MessagesPan.Width;
                });

            if (MessagesPan.Height != MessPanHeight)
                mes.ForEach(m =>
                {
                    m.Item1.Location = new Point(0,
                        m.Item1.Location.Y + (MessagesPan.Height - MessPanHeight)
                        + (ScrollBarMess.Maximum - ScrollBarMess.Value)
                        );
                });

            MessPanWidth = MessagesPan.Width;
            MessPanHeight = MessagesPan.Height;
            start_mes = MessagesPan.Height;
            const_start_mes = MessagesPan.Height;
        }

        private void AddMessbutton_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!log) return;
            if (e.KeyCode == Keys.Enter && e.Modifiers != Keys.Shift)
                button2_Click(sender, e);
            else if (e.KeyCode == Keys.Enter && e.Modifiers == Keys.Shift)
            {
                textBox1.Lines = textBox1.Lines.Where(s => s != "\r" || s != "\n" || s != "\r\n").ToArray();
                textBox1.Lines[textBox1.Lines.Length - 1] += Environment.NewLine;
            }

        }

        private void SelectChat_Click(object sender, EventArgs e)
        {
            obj.Item4 = mes;
            obj.Item5 = buf_mes;
            obj.Item6 = start_mes;

            for (int i = 0; i < chats.Count; i++)
            {
                if (chats[i].Item2.Equals(obj.Item2))
                {
                    chats[i] = obj;
                    break;
                }
            }

            if (sender.GetType().Equals(typeof(Panel)))
            {
                var s = sender as Panel;
                obj = chats.Where(e => e.Item2.Equals(s)).First();
            }
            else if (sender.GetType().Equals(typeof(LogoPan)))
            {
                var s = sender as LogoPan;
                obj = chats.Where(e => e.Item2.Contains(s)).First();
            }
            else
            {
                var s = sender as Label;
                obj = chats.Where(e => e.Item3.Equals(s)).First();
            }

            if (obj.Equals(null)) return;
            if (!panel2.Visible) panel2.Visible = true;

            ContentLable.Text = obj.Item2.Text;

            mes = obj.Item4;
            MessagesPan.Controls.Clear();
            buf_mes = obj.Item5;
            start_mes = MessagesPan.Height;

            ContentLable.Text = obj.Item3.Text;

            foreach (var item in obj.Item4)
            {
                MessagesPan.Controls.Add(item.Item1);
            }

            UpdateScrollBar();
        }

        private void ScrollBarFrend_Scroll(object sender, ScrollEventArgs e)
        {
            if (!log) return;
            int delta = e.OldValue - e.NewValue;
            frends.ForEach((ch) =>
            {
                ch.Location = new Point(
                    0,
                    ch.Location.Y + delta
                    );
            });
        }
    }
}
