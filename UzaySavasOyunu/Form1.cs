namespace UzaySavasOyunu
{
    public partial class Form1 : Form
    {

        List<PictureBox> Mermiler = new List<PictureBox>();
        List<PictureBox> Dusmanlar = new List<PictureBox>();

        int formYukseklik = 700, formGenislik = 500, puan;
        int Oyuncu_X = 200, Oyuncu_Y = 400;  //Oyuncu koordinatlarý
        int OyuncuHiz_Yatay = 0, OyuncuHiz_Dusey = 0;
        int MermiHiz = 10;
        int DusmanHiz = 2;
        Random rnd = new Random();

        public Form1()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = formGenislik;
            this.Height = formYukseklik;
            // objelerimizi galaksimize alýyoruz
            oyuncuGemi.Parent = pictureBoxGalaxy;
            labelPuan.Parent = pictureBoxGalaxy;
            labelPuan.BringToFront();

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int hiz = 1;
            switch (e.KeyCode)
            {
                case Keys.Left:
                    OyuncuHiz_Yatay -= hiz;
                    break;

                case Keys.Right:
                    OyuncuHiz_Yatay += hiz;
                    break;

                case Keys.Up:
                    OyuncuHiz_Dusey -= hiz;
                    break;

                case Keys.Down:
                    OyuncuHiz_Dusey += hiz;
                    break;

                case Keys.Enter:
                    puan = 0;
                    timerOyuncu.Start();
                    timerMermiFirlat.Start();
                    timerDusmanOlustur.Start();
                    timerDusmanDusur.Start();
                    timerMermiKontrol.Start();
                    break;

                case Keys.Space:
                    MermiOlustur();
                    MermileriFýrlat();
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    OyuncuHiz_Yatay = 0;
                    break;

                case Keys.Right:
                    OyuncuHiz_Yatay = 0;
                    break;

                case Keys.Up:
                    OyuncuHiz_Dusey = 0;
                    break;

                case Keys.Down:
                    OyuncuHiz_Dusey = 0;
                    break;
            }
        }
        bool sagaidilebilirmi = true;
        private void timerOyuncu_Tick(object sender, EventArgs e)
        {
            Oyuncu_X += OyuncuHiz_Yatay;
            Oyuncu_Y += OyuncuHiz_Dusey;

            oyuncuGemi.Location = new Point(Oyuncu_X, Oyuncu_Y);
            
        }


        public void MermiOlustur()
        {

            PictureBox Mermi = new PictureBox
            {
                Size = new Size(15, 15),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = Resource1.Laser_08,
                BackColor = Color.Transparent,

            };

            int mermiLocX = oyuncuGemi.Location.X + oyuncuGemi.Width / 2 - 5;
            int mermiLocY = oyuncuGemi.Top - 1;
            Mermi.Location = new Point(mermiLocX, mermiLocY);
            this.Controls.Add(Mermi);
            Mermi.Parent = pictureBoxGalaxy;
            Mermi.BringToFront(); // Galaksi resminin üstüne çýkarma metodu
            Mermiler.Add(Mermi);
        }

        public void MermileriFýrlat()
        {
            for (int i = 0; i < Mermiler.Count; i++)
            {
                Mermiler[i].Top -= MermiHiz;
            }
        }

        private void timerMermiFirlat_Tick(object sender, EventArgs e)
        {
            MermileriFýrlat();
        }

        public void DusmanOlustur()
        {
            int yer = rnd.Next(10, formGenislik - 50);

            PictureBox dusman = new PictureBox
            {
                Size = new Size(50, 50),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = Resource1.Gemi_03,
                BackColor = Color.Transparent,
                Location = new Point(yer, 0),
                Visible = true,
            };

            this.Controls.Add(dusman); // forma ekledik
            dusman.Parent = pictureBoxGalaxy; // galaksi içine ekledik
            dusman.BringToFront();
            Dusmanlar.Add(dusman);

        }
        public void DusmanDusur()
        {
            for (int i = 0; i < Dusmanlar.Count; i++)
            {
                Dusmanlar[i].Top += DusmanHiz;

                // Düþman gemisi formun dýþýna çýkmasý vaya oyuncuya çarpmasý halinde oyun bitmeli

                if (Dusmanlar[i].Top > formYukseklik || Dusmanlar[i].Bounds.IntersectsWith(oyuncuGemi.Bounds))
                {
                    //todo Oyun bitti
                    OyunBitir();

                }
            }
        }

        private void timerDusmanDusur_Tick(object sender, EventArgs e)
        {
            DusmanDusur();
        }

        private void timerDusmanOlustur_Tick(object sender, EventArgs e)
        {
            DusmanOlustur();
        }

        private void timerMermiKontrol_Tick(object sender, EventArgs e)
        {
            for (int m = 0; m < Mermiler.Count; m++)
            {
                for(int d = 0; d < Dusmanlar.Count; d++)
                {

                    try
                    {
                        // mermi ile dusman çarpistimi 
                        if (Mermiler[m].Bounds.IntersectsWith(Dusmanlar[d].Bounds))
                        {
                            puan += 1;
                            labelPuan.Text = "Puan: " + puan.ToString();
                            pictureBoxGalaxy.Controls.Remove(Mermiler[m]);
                            Mermiler.Remove(Mermiler[m]);
                            pictureBoxGalaxy.Controls.Remove(Dusmanlar[d]);
                            Dusmanlar.Remove(Dusmanlar[d]);

                            // Ram Temizliði
                            GC.Collect(); //  Garbage Collector(çöp toplayýcýsý)
                            GC.WaitForPendingFinalizers(); // Çöpleri yok et
                        }
                    }
                    // picturebox listesinden eleman silindiðinde ayný indiste tekrar kontrol edildiði zaman eleman olmayacaðý taktirde görmezden geleceðiz
                    catch (ArgumentOutOfRangeException ex)
                    {
                        return;
                    }

                }
            }
        }

        public void OyunBitir()
        {
            timerOyuncu.Stop();
            timerDusmanDusur.Stop();
            timerMermiFirlat.Stop();
            timerMermiKontrol.Stop();
            timerDusmanOlustur.Stop();
            timerDusmanDusur.Stop();

            MessageBox.Show("Oyun Bitti...");
        }

    }
}
