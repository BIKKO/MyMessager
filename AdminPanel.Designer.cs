namespace MyMessager
{
    partial class AdminPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            comboBox1 = new ComboBox();
            numericUpDown1 = new NumericUpDown();
            buttonSave = new Button();
            buttonDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 12);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(167, 28);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(208, 12);
            numericUpDown1.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(39, 27);
            numericUpDown1.TabIndex = 1;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(12, 46);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(115, 53);
            buttonSave.TabIndex = 2;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(132, 46);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(115, 53);
            buttonDelete.TabIndex = 3;
            buttonDelete.Text = "Удалить пользователя";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // AdminPanel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(256, 109);
            Controls.Add(buttonDelete);
            Controls.Add(buttonSave);
            Controls.Add(numericUpDown1);
            Controls.Add(comboBox1);
            Name = "AdminPanel";
            Text = "AdminPanel";
            Load += AdminPanel_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox comboBox1;
        private NumericUpDown numericUpDown1;
        private Button buttonSave;
        private Button buttonDelete;
    }
}