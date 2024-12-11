using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMessager.Model;

namespace MyMessager
{
    internal class SelectChat
    {
        private List<(Panel, Label)> mes = new List<(Panel, Label)>();
        int mes_max_size;
        int start_mes;
        int butomPad;
        int buf_mes;

        public int Width {  get; set; }

        public SelectChat(int h)
        {
            butomPad = 15;
            buf_mes = 0;
            start_mes = h;
            mes_max_size = 40;
        }

        public void AddNew(int HeightPan, ref VScrollBar ScrollBar)
        {
            int scrollBuf = buf_mes - HeightPan;
            int v = ScrollBar.Value;
            int m = ScrollBar.Maximum;

            if (ScrollBar.Value != ScrollBar.Maximum && ScrollBar.Maximum != 100)
            {
                mes.ForEach((me) =>
                {
                    me.Item1.Location = new Point(
                        0,
                        me.Item1.Location.Y - (m - v)
                        );
                });
            }

            ScrollBar.Maximum = scrollBuf;
            start_mes = HeightPan;
            ScrollBar.Value = ScrollBar.Maximum;
        }

        public Panel AddNewMess(string _mess, MessPosition position)
        {
            if (string.IsNullOrEmpty(_mess)) throw new ArgumentNullException();

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
                    //buf += "\n";
                    message += buf;
                }
                else message += mes;
                if (mess_width != mes_max_size)
                {
                    mess_width = Math.Max(mess_width, mes.Length);
                }
                message += "\n";
            }
            //message = Regex.Replace(message, @"\r\n", "");
            var u1 = new Label()
            {
                Dock = (DockStyle)position,
                //Width = mess_width * 3,
                Text = message,
                AutoEllipsis = true,
                AutoSize = true,
                BackColor = position == MessPosition.Right ? Color.LightGray : Color.LightSlateGray,
            };
            u1.Height *= message.Split("\n").Length - 1;


            var testpan = new Panel()
            {
                Height = u1.Height,
                Width = Width,
                //BackColor = Color.Red,
                Visible = true,
            };
            testpan.Controls.Add(u1);
            testpan.Location = new Point(0, start_mes - testpan.Height - butomPad);
            buf_mes += testpan.Height + butomPad;

            if (mes.Count > 0)
                mes.ForEach(me => { me.Item1.Location = new Point(0, me.Item1.Location.Y - testpan.Height - butomPad); });
            mes.Add((testpan, u1));

            return testpan;
        }
    }
}
