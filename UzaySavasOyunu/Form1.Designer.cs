namespace UzaySavasOyunu
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
            pictureBoxGalaxy = new PictureBox();
            oyuncuGemi = new PictureBox();
            labelPuan = new Label();
            timerOyuncu = new System.Windows.Forms.Timer(components);
            timerMermiFirlat = new System.Windows.Forms.Timer(components);
            timerDusmanDusur = new System.Windows.Forms.Timer(components);
            timerDusmanOlustur = new System.Windows.Forms.Timer(components);
            timerMermiKontrol = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBoxGalaxy).BeginInit();
            ((System.ComponentModel.ISupportInitialize)oyuncuGemi).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxGalaxy
            // 
            pictureBoxGalaxy.Dock = DockStyle.Fill;
            pictureBoxGalaxy.Image = Resource1.Evren_04;
            pictureBoxGalaxy.Location = new Point(0, 0);
            pictureBoxGalaxy.Name = "pictureBoxGalaxy";
            pictureBoxGalaxy.Size = new Size(589, 673);
            pictureBoxGalaxy.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxGalaxy.TabIndex = 0;
            pictureBoxGalaxy.TabStop = false;
            // 
            // oyuncuGemi
            // 
            oyuncuGemi.BackColor = Color.Transparent;
            oyuncuGemi.Image = Resource1.Gemi_01;
            oyuncuGemi.Location = new Point(170, 496);
            oyuncuGemi.Name = "oyuncuGemi";
            oyuncuGemi.Size = new Size(100, 74);
            oyuncuGemi.SizeMode = PictureBoxSizeMode.StretchImage;
            oyuncuGemi.TabIndex = 1;
            oyuncuGemi.TabStop = false;
            // 
            // labelPuan
            // 
            labelPuan.AutoSize = true;
            labelPuan.BackColor = Color.Transparent;
            labelPuan.Font = new Font("Consolas", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            labelPuan.ForeColor = Color.White;
            labelPuan.Location = new Point(22, 34);
            labelPuan.Name = "labelPuan";
            labelPuan.Size = new Size(116, 27);
            labelPuan.TabIndex = 2;
            labelPuan.Text = "Puan : 0";
            // 
            // timerOyuncu
            // 
            timerOyuncu.Interval = 1;
            timerOyuncu.Tick += timerOyuncu_Tick;
            // 
            // timerMermiFirlat
            // 
            timerMermiFirlat.Interval = 10;
            timerMermiFirlat.Tick += timerMermiFirlat_Tick;
            // 
            // timerDusmanDusur
            // 
            timerDusmanDusur.Interval = 50;
            timerDusmanDusur.Tick += timerDusmanDusur_Tick;
            // 
            // timerDusmanOlustur
            // 
            timerDusmanOlustur.Interval = 2000;
            timerDusmanOlustur.Tick += timerDusmanOlustur_Tick;
            // 
            // timerMermiKontrol
            // 
            timerMermiKontrol.Tick += timerMermiKontrol_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(589, 673);
            Controls.Add(labelPuan);
            Controls.Add(oyuncuGemi);
            Controls.Add(pictureBoxGalaxy);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Uzay Savaşı";
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
            KeyUp += Form1_KeyUp;
            ((System.ComponentModel.ISupportInitialize)pictureBoxGalaxy).EndInit();
            ((System.ComponentModel.ISupportInitialize)oyuncuGemi).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBoxGalaxy;
        private PictureBox oyuncuGemi;
        private Label labelPuan;
        private System.Windows.Forms.Timer timerOyuncu;
        private System.Windows.Forms.Timer timerMermiFirlat;
        private System.Windows.Forms.Timer timerDusmanDusur;
        private System.Windows.Forms.Timer timerDusmanOlustur;
        private System.Windows.Forms.Timer timerMermiKontrol;
    }
}
