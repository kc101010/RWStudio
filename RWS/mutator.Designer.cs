namespace RWS
{
    partial class mutator
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mutator));
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.nam = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.uwt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.uwtot = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ad = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nam)).BeginInit();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(187, 163);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(85, 24);
            this.button4.TabIndex = 92;
            this.button4.Text = "Apply";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(95, 163);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(85, 24);
            this.button5.TabIndex = 91;
            this.button5.Text = "Cancel";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // nam
            // 
            this.nam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.nam.Location = new System.Drawing.Point(154, 13);
            this.nam.Name = "nam";
            this.nam.Size = new System.Drawing.Size(38, 26);
            this.nam.TabIndex = 81;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(92, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 20);
            this.label6.TabIndex = 80;
            this.label6.Text = "mutator";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 93;
            this.label1.Text = "If unit with tags";
            // 
            // uwt
            // 
            this.uwt.Location = new System.Drawing.Point(96, 49);
            this.uwt.Name = "uwt";
            this.uwt.Size = new System.Drawing.Size(153, 20);
            this.uwt.TabIndex = 94;
            this.uwt.Tag = "life";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 95;
            this.label2.Text = "If unit without tags";
            // 
            // uwtot
            // 
            this.uwtot.Location = new System.Drawing.Point(111, 75);
            this.uwtot.Name = "uwtot";
            this.uwtot.Size = new System.Drawing.Size(153, 20);
            this.uwtot.TabIndex = 96;
            this.uwtot.Tag = "life";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 13);
            this.label3.TabIndex = 97;
            this.label3.Text = "Direct damage multiplier";
            this.toolTip1.SetToolTip(this.label3, "Changes directDamage. Defaults to 1. Be careful not to confuse players using this" +
        " as the effect may not be clear. Use amour instead when possible.");
            // 
            // dd
            // 
            this.dd.Location = new System.Drawing.Point(137, 129);
            this.dd.Name = "dd";
            this.dd.Size = new System.Drawing.Size(37, 20);
            this.dd.TabIndex = 98;
            this.dd.Tag = "life";
            this.dd.Text = "1";
            this.toolTip1.SetToolTip(this.dd, "Changes directDamage. Defaults to 1. Be careful not to confuse players using this" +
        " as the effect may not be clear. Use amour instead when possible.");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 13);
            this.label4.TabIndex = 99;
            this.label4.Text = "Area damage multiplier";
            this.toolTip1.SetToolTip(this.label4, "Same as directDamageMultiplier but for areaDamage. Defaults to 1.");
            // 
            // ad
            // 
            this.ad.Location = new System.Drawing.Point(131, 103);
            this.ad.Name = "ad";
            this.ad.Size = new System.Drawing.Size(38, 20);
            this.ad.TabIndex = 100;
            this.ad.Tag = "life";
            this.ad.Text = "1";
            this.toolTip1.SetToolTip(this.ad, "Same as directDamageMultiplier but for areaDamage. Defaults to 1.");
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 10000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Help";
            // 
            // mutator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 199);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ad);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.uwtot);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uwt);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.nam);
            this.Controls.Add(this.label6);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(384, 241);
            this.Name = "mutator";
            this.Text = "RWStudio: Mutator";
            ((System.ComponentModel.ISupportInitialize)(this.nam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.NumericUpDown nam;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox uwt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox uwtot;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox dd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ad;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}