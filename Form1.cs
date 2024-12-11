using MessangerAPI.Core;
using MyMessager.Model;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace MyMessager
{
    public partial class Form1 : Form
    {
        bool f = true;
        int buf_mes;
        int buf_fre;
        List<(Panel, Label)> mes = new List<(Panel, Label)>();
        List<(Panel, Label)> chats = new List<(Panel, Label)>();
        int MessPanWidth;
        int MessPanHeight;
        int butomPad;
        int start_mes;
        int start_fre;
        int mes_max_size;
        SelectChat SC;
        MessangerAPI.Core.MessangerAPI API;
        Login l;

        bool log;

        public Form1()
        {
            InitializeComponent();
            MessPanWidth = MessagesPan.Width;
            MessPanHeight = MessagesPan.Height;
            ScrollBarMess.Visible = false;
            ScrollBarMess.LargeChange = 1;
            ScrollBarMess.Value = ScrollBarMess.Maximum;
            ScrollBarChat.LargeChange = 1;
            ScrollBarChat.Visible = false;
            butomPad = 15;
            buf_mes = 0;
            start_mes = MessagesPan.Height;
            start_fre = 0;
            mes_max_size = 40;
            buf_fre = 0;
            log = false;

            API = new MessangerAPI.Core.MessangerAPI("http://localhost:5000");

            SC = new SelectChat(MessagesPan.Height);
            l = new Login(API);
            l.Show();
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
            if (string.IsNullOrEmpty(Regex.Replace(_mess, @"\t|\r|\n", ""))) throw new ArgumentNullException();
            string message = string.Empty;
            int mess_width = 0;
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
                else message += mes;
                if (mess_width != mes_max_size)
                {
                    mess_width = Math.Max(mess_width, mes.Length);
                }
                message += "\n";
            }
            var u1 = new Label()
            {
                Dock = (DockStyle)position,
                Text = message,
                AutoEllipsis = true,
                AutoSize = true,
                BackColor = position == MessPosition.Right ? Color.LightGray : Color.LightSlateGray,
            };
            u1.Height *= message.Split("\n").Length;
            var d = new Label()
            {
                Text = new string('\n', message.Split("\n").Length-2) + DateTime.Now.ToShortTimeString(),
                AutoEllipsis = true,
                AutoSize = true,
                BackColor = position == MessPosition.Right ? Color.LightGray : Color.LightSlateGray,
                Dock = (DockStyle)(position == MessPosition.Right ? MessPosition.Right:MessPosition.Left),
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

        private void button2_Click(object sender, EventArgs e)
        {
            if(!log) return;
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
            start_mes += delta;
        }

        private void MessageRefreh_Tick(object sender, EventArgs e)
        {
            if (!API.GetIsLogin())
            {
                if (Application.OpenForms["Login"] == null)
                {
                    l = new Login(API);
                    l.Show();
                }
                return;
            }
            log = true;
            MessageRefresh.Enabled = false;
            l.Close();
        }

        private void FrendAddbutton_Click(object sender, EventArgs e)
        {
            if (!log) return;
            var u1 = new Label()
            {
                Dock = DockStyle.Fill,
                Text = "Привет" + start_fre,
                Padding = new Padding(45, 0, 0, 0)
            };
            start_fre++;
            var ico = new Panel()
            {
                Width = 45,
                Dock = DockStyle.Left,
                BackColor = Color.White,

            };
            var testpan = new Panel()
            {
                Height = 45,
                Width = ChatsPan.Width,
                BackColor = Color.Red,
                BorderStyle = BorderStyle.FixedSingle,
            };
            testpan.Controls.Add(ico);
            testpan.Controls.Add(u1);
            testpan.Location = new Point(0, buf_fre - ScrollBarChat.Value);
            ChatsPan.Controls.Add(testpan);

            buf_fre += testpan.Height;
            chats.Add((testpan, u1));

            if (buf_fre > ChatsPan.Height)
            {
                ScrollBarChat.Maximum = buf_fre - ChatsPan.Height;
                //ScrollBarChat.Value = 0;
                if (!ScrollBarChat.Visible)
                {
                    ScrollBarChat.Visible = true;
                    //SkrollWidth = ScrollBarChat.Width;
                    //chats.ForEach(me => { me.Item1.Width -= ScrollBarChat.Width; });
                }
            }

            //f = !f;

            //if (fre.Count > 0)
            //    fre.ForEach(fr => { fr.Item1.Location = new Point(0, fr.Item1.Location.Y + testpan.Height); });
            //fre.Add((testpan, u1));
        }

        private void ScrollBarChat_Scroll(object sender, ScrollEventArgs e)
        {
            if (!log) return;
            int delta = e.OldValue - e.NewValue;
            chats.ForEach((ch) =>
            {
                ch.Item1.Location = new Point(
                    0,
                    ch.Item1.Location.Y + delta
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

            //UpdateScrollBar();

            MessPanWidth = MessagesPan.Width;
            MessPanHeight = MessagesPan.Height;
            start_mes = MessagesPan.Height;
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
    }
}
