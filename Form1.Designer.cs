namespace MyMessager
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            ChatsPan = new Panel();
            ScrollBarChat = new VScrollBar();
            SettingsPan = new Panel();
            FrendPan = new Panel();
            ScrollBarFrend = new VScrollBar();
            panel6 = new Panel();
            label1 = new Label();
            FrendAddbutton = new Button();
            panel2 = new Panel();
            MessagesPan = new Panel();
            ScrollBarMess = new VScrollBar();
            panel3 = new Panel();
            panel5 = new Panel();
            textBox1 = new TextBox();
            panel4 = new Panel();
            AddMessbutton = new Button();
            ContextPan = new Panel();
            ContentLable = new Label();
            MessageRefresh = new System.Windows.Forms.Timer(components);
            contextMenuFrend = new ContextMenuStrip(components);
            contextMenuMess = new ContextMenuStrip(components);
            UpdateFrendTimer = new System.Windows.Forms.Timer(components);
            UpdateChatsTimer = new System.Windows.Forms.Timer(components);
            UpdateMessageTimer = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            SettingsPan.SuspendLayout();
            FrendPan.SuspendLayout();
            panel6.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            ContextPan.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(ChatsPan);
            panel1.Controls.Add(ScrollBarChat);
            panel1.Controls.Add(SettingsPan);
            panel1.Controls.Add(FrendAddbutton);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(308, 450);
            panel1.TabIndex = 0;
            // 
            // ChatsPan
            // 
            ChatsPan.AutoScrollMargin = new Size(0, 1);
            ChatsPan.BackColor = Color.Gainsboro;
            ChatsPan.Dock = DockStyle.Fill;
            ChatsPan.Location = new Point(76, 0);
            ChatsPan.Name = "ChatsPan";
            ChatsPan.Size = new Size(219, 406);
            ChatsPan.TabIndex = 1;
            // 
            // ScrollBarChat
            // 
            ScrollBarChat.Dock = DockStyle.Right;
            ScrollBarChat.Location = new Point(295, 0);
            ScrollBarChat.Name = "ScrollBarChat";
            ScrollBarChat.Size = new Size(13, 406);
            ScrollBarChat.TabIndex = 3;
            ScrollBarChat.Visible = false;
            ScrollBarChat.Scroll += ScrollBarChat_Scroll;
            // 
            // SettingsPan
            // 
            SettingsPan.BackColor = Color.Silver;
            SettingsPan.Controls.Add(FrendPan);
            SettingsPan.Controls.Add(panel6);
            SettingsPan.Dock = DockStyle.Left;
            SettingsPan.Location = new Point(0, 0);
            SettingsPan.Name = "SettingsPan";
            SettingsPan.Size = new Size(76, 406);
            SettingsPan.TabIndex = 2;
            // 
            // FrendPan
            // 
            FrendPan.Controls.Add(ScrollBarFrend);
            FrendPan.Dock = DockStyle.Fill;
            FrendPan.Location = new Point(0, 71);
            FrendPan.Name = "FrendPan";
            FrendPan.Size = new Size(76, 335);
            FrendPan.TabIndex = 1;
            // 
            // ScrollBarFrend
            // 
            ScrollBarFrend.Dock = DockStyle.Right;
            ScrollBarFrend.Location = new Point(59, 0);
            ScrollBarFrend.Name = "ScrollBarFrend";
            ScrollBarFrend.Size = new Size(17, 335);
            ScrollBarFrend.TabIndex = 0;
            ScrollBarFrend.Scroll += ScrollBarFrend_Scroll;
            // 
            // panel6
            // 
            panel6.BackColor = Color.DarkGray;
            panel6.Controls.Add(label1);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(76, 71);
            panel6.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.DarkGray;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(1, 12);
            label1.Name = "label1";
            label1.Size = new Size(75, 46);
            label1.TabIndex = 0;
            label1.Text = "You";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FrendAddbutton
            // 
            FrendAddbutton.BackColor = Color.DarkGray;
            FrendAddbutton.Dock = DockStyle.Bottom;
            FrendAddbutton.Location = new Point(0, 406);
            FrendAddbutton.Name = "FrendAddbutton";
            FrendAddbutton.Size = new Size(308, 44);
            FrendAddbutton.TabIndex = 0;
            FrendAddbutton.Text = "Найти друга";
            FrendAddbutton.UseVisualStyleBackColor = false;
            FrendAddbutton.Click += FrendAddbutton_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(MessagesPan);
            panel2.Controls.Add(ScrollBarMess);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(ContextPan);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(308, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(492, 450);
            panel2.TabIndex = 1;
            // 
            // MessagesPan
            // 
            MessagesPan.AutoScrollMargin = new Size(0, 20);
            MessagesPan.BackColor = Color.DimGray;
            MessagesPan.Dock = DockStyle.Fill;
            MessagesPan.Location = new Point(0, 51);
            MessagesPan.Name = "MessagesPan";
            MessagesPan.Size = new Size(472, 355);
            MessagesPan.TabIndex = 1;
            MessagesPan.SizeChanged += MessagesPan_SizeChanged;
            // 
            // ScrollBarMess
            // 
            ScrollBarMess.Dock = DockStyle.Right;
            ScrollBarMess.Location = new Point(472, 51);
            ScrollBarMess.Name = "ScrollBarMess";
            ScrollBarMess.Size = new Size(20, 355);
            ScrollBarMess.TabIndex = 1;
            ScrollBarMess.Scroll += vScrollBar1_Scroll;
            // 
            // panel3
            // 
            panel3.Controls.Add(panel5);
            panel3.Controls.Add(panel4);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 406);
            panel3.Name = "panel3";
            panel3.Size = new Size(492, 44);
            panel3.TabIndex = 0;
            // 
            // panel5
            // 
            panel5.Controls.Add(textBox1);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(360, 44);
            panel5.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Fill;
            textBox1.Location = new Point(0, 0);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(360, 44);
            textBox1.TabIndex = 0;
            textBox1.KeyDown += textBox1_KeyDown;
            // 
            // panel4
            // 
            panel4.Controls.Add(AddMessbutton);
            panel4.Dock = DockStyle.Right;
            panel4.Location = new Point(360, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(132, 44);
            panel4.TabIndex = 1;
            // 
            // AddMessbutton
            // 
            AddMessbutton.BackColor = SystemColors.ActiveCaption;
            AddMessbutton.Dock = DockStyle.Fill;
            AddMessbutton.Location = new Point(0, 0);
            AddMessbutton.Name = "AddMessbutton";
            AddMessbutton.Size = new Size(132, 44);
            AddMessbutton.TabIndex = 0;
            AddMessbutton.Text = "Отправить";
            AddMessbutton.UseVisualStyleBackColor = false;
            AddMessbutton.Click += button2_Click;
            // 
            // ContextPan
            // 
            ContextPan.BackColor = SystemColors.ControlDark;
            ContextPan.Controls.Add(ContentLable);
            ContextPan.Dock = DockStyle.Top;
            ContextPan.Location = new Point(0, 0);
            ContextPan.Name = "ContextPan";
            ContextPan.Size = new Size(492, 51);
            ContextPan.TabIndex = 2;
            // 
            // ContentLable
            // 
            ContentLable.AutoSize = true;
            ContentLable.Dock = DockStyle.Left;
            ContentLable.Font = new Font("Segoe UI", 14F);
            ContentLable.Location = new Point(0, 0);
            ContentLable.Name = "ContentLable";
            ContentLable.Size = new Size(78, 32);
            ContentLable.TabIndex = 0;
            ContentLable.Text = "label1";
            // 
            // MessageRefresh
            // 
            MessageRefresh.Enabled = true;
            MessageRefresh.Tick += MessageRefreh_Tick;
            // 
            // contextMenuFrend
            // 
            contextMenuFrend.ImageScalingSize = new Size(20, 20);
            contextMenuFrend.Name = "contextMenuFrend";
            contextMenuFrend.Size = new Size(61, 4);
            // 
            // contextMenuMess
            // 
            contextMenuMess.ImageScalingSize = new Size(20, 20);
            contextMenuMess.Name = "contextMenuMess";
            contextMenuMess.Size = new Size(61, 4);
            // 
            // UpdateFrendTimer
            // 
            UpdateFrendTimer.Interval = 1500;
            UpdateFrendTimer.Tick += UpdateFrendTimer_Tick;
            // 
            // UpdateChatsTimer
            // 
            UpdateChatsTimer.Interval = 2000;
            UpdateChatsTimer.Tick += UpdateChatsTimer_Tick;
            // 
            // UpdateMessageTimer
            // 
            UpdateMessageTimer.Interval = 1000;
            UpdateMessageTimer.Tick += UpdateMessageTimer_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(800, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Messanger";
            FormClosing += Form1_FormClosing;
            panel1.ResumeLayout(false);
            SettingsPan.ResumeLayout(false);
            FrendPan.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            ContextPan.ResumeLayout(false);
            ContextPan.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button FrendAddbutton;
        private Panel panel2;
        private Panel panel3;
        private Panel panel5;
        private Panel panel4;
        private TextBox textBox1;
        private Button AddMessbutton;
        private Panel ChatsPan;
        private Panel MessagesPan;
        private Panel ContextPan;
        private VScrollBar ScrollBarMess;
        private System.Windows.Forms.Timer MessageRefresh;
        private Panel SettingsPan;
        private VScrollBar ScrollBarChat;
        private Label ContentLable;
        private Panel FrendPan;
        private VScrollBar ScrollBarFrend;
        private Panel panel6;
        private ContextMenuStrip contextMenuFrend;
        private Label label1;
        private ContextMenuStrip contextMenuMess;
        private System.Windows.Forms.Timer UpdateFrendTimer;
        private System.Windows.Forms.Timer UpdateChatsTimer;
        private System.Windows.Forms.Timer UpdateMessageTimer;
    }
}
