namespace Bank
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.sdvgsgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sgszToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sgsgfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sgzgsfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fgszzsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Salmon;
            this.groupBox1.Location = new System.Drawing.Point(972, 512);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(470, 432);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.menuStrip2.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Bold);
            this.menuStrip2.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sdvgsgToolStripMenuItem,
            this.sgszToolStripMenuItem,
            this.sgsgfToolStripMenuItem,
            this.sgzgsfToolStripMenuItem,
            this.fgszzsToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.menuStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.menuStrip2.Size = new System.Drawing.Size(227, 944);
            this.menuStrip2.TabIndex = 12;
            this.menuStrip2.Text = "menuStrip2";
            this.menuStrip2.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip2_ItemClicked);
            // 
            // sdvgsgToolStripMenuItem
            // 
            this.sdvgsgToolStripMenuItem.AutoSize = false;
            this.sdvgsgToolStripMenuItem.BackColor = System.Drawing.Color.CadetBlue;
            this.sdvgsgToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.sdvgsgToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.sdvgsgToolStripMenuItem.Name = "sdvgsgToolStripMenuItem";
            this.sdvgsgToolStripMenuItem.Padding = new System.Windows.Forms.Padding(16, 0, 6, 0);
            this.sdvgsgToolStripMenuItem.Size = new System.Drawing.Size(227, 53);
            this.sdvgsgToolStripMenuItem.Text = "Клиенты";
            this.sdvgsgToolStripMenuItem.Click += new System.EventHandler(this.sdvgsgToolStripMenuItem_Click);
            // 
            // sgszToolStripMenuItem
            // 
            this.sgszToolStripMenuItem.AutoSize = false;
            this.sgszToolStripMenuItem.BackColor = System.Drawing.Color.CadetBlue;
            this.sgszToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.sgszToolStripMenuItem.Name = "sgszToolStripMenuItem";
            this.sgszToolStripMenuItem.Size = new System.Drawing.Size(227, 53);
            this.sgszToolStripMenuItem.Text = "Продукты";
            this.sgszToolStripMenuItem.Click += new System.EventHandler(this.sgszToolStripMenuItem_Click);
            // 
            // sgsgfToolStripMenuItem
            // 
            this.sgsgfToolStripMenuItem.AutoSize = false;
            this.sgsgfToolStripMenuItem.BackColor = System.Drawing.Color.CadetBlue;
            this.sgsgfToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.sgsgfToolStripMenuItem.Name = "sgsgfToolStripMenuItem";
            this.sgsgfToolStripMenuItem.Size = new System.Drawing.Size(227, 33);
            this.sgsgfToolStripMenuItem.Text = "Тарифы";
            this.sgsgfToolStripMenuItem.Click += new System.EventHandler(this.sgsgfToolStripMenuItem_Click);
            // 
            // sgzgsfToolStripMenuItem
            // 
            this.sgzgsfToolStripMenuItem.AutoSize = false;
            this.sgzgsfToolStripMenuItem.BackColor = System.Drawing.Color.CadetBlue;
            this.sgzgsfToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.sgzgsfToolStripMenuItem.Name = "sgzgsfToolStripMenuItem";
            this.sgzgsfToolStripMenuItem.Size = new System.Drawing.Size(227, 53);
            this.sgzgsfToolStripMenuItem.Text = "Операции";
            // 
            // fgszzsToolStripMenuItem
            // 
            this.fgszzsToolStripMenuItem.AutoSize = false;
            this.fgszzsToolStripMenuItem.BackColor = System.Drawing.Color.CadetBlue;
            this.fgszzsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.fgszzsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.fgszzsToolStripMenuItem.Name = "fgszzsToolStripMenuItem";
            this.fgszzsToolStripMenuItem.Size = new System.Drawing.Size(227, 33);
            this.fgszzsToolStripMenuItem.Text = "Настройки";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.AutoSize = false;
            this.выходToolStripMenuItem.BackColor = System.Drawing.Color.LightCoral;
            this.выходToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(227, 53);
            this.выходToolStripMenuItem.Text = "Выход";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.DarkSalmon;
            this.groupBox2.Location = new System.Drawing.Point(630, 512);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(335, 432);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Moccasin;
            this.groupBox3.Location = new System.Drawing.Point(230, 512);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(394, 432);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.pictureBox1.Location = new System.Drawing.Point(230, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1212, 506);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1478, 944);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip2);
            this.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1500, 800);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Главная";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem sdvgsgToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sgszToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sgsgfToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sgzgsfToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fgszzsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

