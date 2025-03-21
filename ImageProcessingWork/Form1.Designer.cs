namespace ImageProcessingWork
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.selectImageButton = new System.Windows.Forms.Button();
            this.uzaysalFiltre_Btn = new System.Windows.Forms.Button();
            this.yuksekFiltre_Btn = new System.Windows.Forms.Button();
            this.clr_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 54);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(610, 411);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(637, 54);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(610, 411);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // selectImageButton
            // 
            this.selectImageButton.Location = new System.Drawing.Point(134, 718);
            this.selectImageButton.Name = "selectImageButton";
            this.selectImageButton.Size = new System.Drawing.Size(185, 59);
            this.selectImageButton.TabIndex = 2;
            this.selectImageButton.Text = "Fotoğraf Seç";
            this.selectImageButton.UseVisualStyleBackColor = true;
            this.selectImageButton.Click += new System.EventHandler(this.selectImageButton_Click);
            // 
            // uzaysalFiltre_Btn
            // 
            this.uzaysalFiltre_Btn.Location = new System.Drawing.Point(389, 718);
            this.uzaysalFiltre_Btn.Name = "uzaysalFiltre_Btn";
            this.uzaysalFiltre_Btn.Size = new System.Drawing.Size(185, 59);
            this.uzaysalFiltre_Btn.TabIndex = 3;
            this.uzaysalFiltre_Btn.Text = "Ortalama Filtreleme";
            this.uzaysalFiltre_Btn.UseVisualStyleBackColor = true;
            this.uzaysalFiltre_Btn.Click += new System.EventHandler(this.uzaysalFiltre_Btn_Click);
            // 
            // yuksekFiltre_Btn
            // 
            this.yuksekFiltre_Btn.Location = new System.Drawing.Point(648, 718);
            this.yuksekFiltre_Btn.Name = "yuksekFiltre_Btn";
            this.yuksekFiltre_Btn.Size = new System.Drawing.Size(185, 59);
            this.yuksekFiltre_Btn.TabIndex = 4;
            this.yuksekFiltre_Btn.Text = "Yüksek Geçiren\n";
            this.yuksekFiltre_Btn.UseVisualStyleBackColor = true;
            this.yuksekFiltre_Btn.Click += new System.EventHandler(this.yuksekFiltre_Btn_Click);
            // 
            // clr_Button
            // 
            this.clr_Button.Location = new System.Drawing.Point(918, 718);
            this.clr_Button.Name = "clr_Button";
            this.clr_Button.Size = new System.Drawing.Size(185, 59);
            this.clr_Button.TabIndex = 5;
            this.clr_Button.Text = "Clear";
            this.clr_Button.UseVisualStyleBackColor = true;
            this.clr_Button.Click += new System.EventHandler(this.clr_Button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 800);
            this.Controls.Add(this.clr_Button);
            this.Controls.Add(this.yuksekFiltre_Btn);
            this.Controls.Add(this.uzaysalFiltre_Btn);
            this.Controls.Add(this.selectImageButton);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button selectImageButton;
        private System.Windows.Forms.Button uzaysalFiltre_Btn;
        private System.Windows.Forms.Button yuksekFiltre_Btn;
        private System.Windows.Forms.Button clr_Button;
    }
}

