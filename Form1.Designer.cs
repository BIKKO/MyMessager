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
            MessageRefresh = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
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
            ChatsPan.Dock = DockStyle.Fill;
            ChatsPan.Location = new Point(99, 0);
            ChatsPan.Name = "ChatsPan";
            ChatsPan.Size = new Size(196, 406);
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
            SettingsPan.Dock = DockStyle.Left;
            SettingsPan.Location = new Point(0, 0);
            SettingsPan.Name = "SettingsPan";
            SettingsPan.Size = new Size(99, 406);
            SettingsPan.TabIndex = 2;
            // 
            // FrendAddbutton
            // 
            FrendAddbutton.Dock = DockStyle.Bottom;
            FrendAddbutton.Location = new Point(0, 406);
            FrendAddbutton.Name = "FrendAddbutton";
            FrendAddbutton.Size = new Size(308, 44);
            FrendAddbutton.TabIndex = 0;
            FrendAddbutton.Text = "button1";
            FrendAddbutton.UseVisualStyleBackColor = true;
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
            AddMessbutton.Dock = DockStyle.Fill;
            AddMessbutton.Location = new Point(0, 0);
            AddMessbutton.Name = "AddMessbutton";
            AddMessbutton.Size = new Size(132, 44);
            AddMessbutton.TabIndex = 0;
            AddMessbutton.Text = "button2";
            AddMessbutton.UseVisualStyleBackColor = true;
            AddMessbutton.Click += button2_Click;
            // 
            // ContextPan
            // 
            ContextPan.BackColor = SystemColors.ControlDark;
            ContextPan.Dock = DockStyle.Top;
            ContextPan.Location = new Point(0, 0);
            ContextPan.Name = "ContextPan";
            ContextPan.Size = new Size(492, 51);
            ContextPan.TabIndex = 2;
            // 
            // MessageRefresh
            // 
            MessageRefresh.Enabled = true;
            MessageRefresh.Tick += MessageRefreh_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Messanger";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
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
    }
}
