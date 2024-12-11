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
            buf_fre = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (f)
            {
                var u1 = new Label()
                {
                    Dock = DockStyle.Right,
                    Text = "Привет\nКак дела?" + buf_mes,
                };
                u1.Height *= u1.Text.Split("\n").Length;
                var testpan = new Panel()
                {
                    Height = u1.Height,
                    Width = MessagesPan.Width,
                    BackColor = Color.Red,
                    Visible = true,
                };
                testpan.Controls.Add(u1);
                testpan.Location = new Point(0, start_mes - testpan.Height - butomPad);
                MessagesPan.Controls.Add(testpan);

                f = !f;
                buf_mes += testpan.Height + butomPad;

                if (mes.Count > 0)
                    mes.ForEach(me => { me.Item1.Location = new Point(0, me.Item1.Location.Y - testpan.Height - butomPad); });
                mes.Add((testpan, u1));
            }
            else
            {
                var u1 = new Label()
                {
                    Dock = DockStyle.Left,
                    Text = "Привет" + buf_mes,
                };
                u1.Height *= u1.Text.Split("\n").Length;

                var testpan = new Panel()
                {
                    Height = u1.Height,
                    Width = MessagesPan.Width,
                    BackColor = Color.Beige,
                    Visible = true,

                };
                testpan.Controls.Add(u1);
                testpan.Location = new Point(0, start_mes - testpan.Height - butomPad);
                MessagesPan.Controls.Add(testpan);

                //u1.Text = testpan.Location.ToString();

                f = !f;
                buf_mes += testpan.Height + butomPad;

                if (mes.Count > 0)
                    mes.ForEach(me => { me.Item1.Location = new Point(0, me.Item1.Location.Y - testpan.Height - butomPad); });
                mes.Add((testpan, u1));
            }

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
                if(ScrollBarMess.Visible) ScrollBarMess.Visible = false;
            }
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
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
            
        }

        private void FrendAddbutton_Click(object sender, EventArgs e)
        {
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
        }
    }
}
