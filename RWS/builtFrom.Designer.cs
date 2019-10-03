namespace RWS
{
    partial class builtFrom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(builtFrom));
            this.label6 = new System.Windows.Forms.Label();
            this.bfnum = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.forceNano = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pos = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.islocked = new System.Windows.Forms.ComboBox();
            this.lockedmess = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bfnum)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(69, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 20);
            this.label6.TabIndex = 19;
            this.label6.Text = "builtFrom_";
            // 
            // bfnum
            // 
            this.bfnum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bfnum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bfnum.Location = new System.Drawing.Point(149, 7);
            this.bfnum.Name = "bfnum";
            this.bfnum.Size = new System.Drawing.Size(38, 26);
            this.bfnum.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Unit can be builded in:";
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(131, 50);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(112, 20);
            this.name.TabIndex = 22;
            // 
            // forceNano
            // 
            this.forceNano.AutoSize = true;
            this.forceNano.Location = new System.Drawing.Point(163, 79);
            this.forceNano.Name = "forceNano";
            this.forceNano.Size = new System.Drawing.Size(80, 17);
            this.forceNano.TabIndex = 23;
            this.forceNano.Text = "Force nano";
            this.forceNano.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Position in list";
            // 
            // pos
            // 
            this.pos.Location = new System.Drawing.Point(86, 77);
            this.pos.Name = "pos";
            this.pos.Size = new System.Drawing.Size(51, 20);
            this.pos.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Is locked";
            // 
            // islocked
            // 
            this.islocked.FormattingEnabled = true;
            this.islocked.Items.AddRange(new object[] {
            "True",
            "False"});
            this.islocked.Location = new System.Drawing.Point(66, 109);
            this.islocked.Name = "islocked";
            this.islocked.Size = new System.Drawing.Size(121, 21);
            this.islocked.TabIndex = 27;
            // 
            // lockedmess
            // 
            this.lockedmess.Location = new System.Drawing.Point(106, 143);
            this.lockedmess.Multiline = true;
            this.lockedmess.Name = "lockedmess";
            this.lockedmess.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.lockedmess.Size = new System.Drawing.Size(137, 52);
            this.lockedmess.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Locked message";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(189, 208);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(74, 23);
            this.button4.TabIndex = 79;
            this.button4.Text = "Apply";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(109, 208);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(74, 23);
            this.button5.TabIndex = 78;
            this.button5.Text = "Cancel";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // builtFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 243);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.lockedmess);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.islocked);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.forceNano);
            this.Controls.Add(this.name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bfnum);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "builtFrom";
            this.Text = "RWStudio: Built from";
            this.Load += new System.EventHandler(this.builtFrom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bfnum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown bfnum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.CheckBox forceNano;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox pos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox islocked;
        private System.Windows.Forms.TextBox lockedmess;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}