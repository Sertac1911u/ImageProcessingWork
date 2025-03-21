using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImageProcessingWork
{
    public partial class Form1 : Form
    {
        public Bitmap originalImage, processingImage;
        //Select image buton
        private void selectImageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg;*.png;*.bmp)|*.jpg;*.png;*.bmp";

            if (open.ShowDialog() == DialogResult.OK)
            {
                originalImage = new Bitmap(open.FileName);
                pictureBox1.Image = originalImage;
            }
        }
        //Uzaysal fonksiyon ortalama
        private Bitmap OrtalamaFiltre(Bitmap original)
        {
            Bitmap processedImage = new Bitmap(original.Width, original.Height);

            int kernelSize = 3;
            int kernelSum = 9;

            for (int x = 1; x < original.Width - 1; x++)
            {
                for (int y = 1; y < original.Height - 1; y++)
                {
                    int summR = 0, summG = 0, summB = 0;

                    for (int kx = -1; kx <= 1; kx++)
                    {
                        for (int ky = -1; ky <= 1; ky++)
                        {
                            Color komsuPixel = original.GetPixel(x + kx, y + ky);
                            summR += komsuPixel.R;
                            summG += komsuPixel.G;
                            summB += komsuPixel.B;
                        }
                    }

                    Color newColor = Color.FromArgb(summR / kernelSum, summG / kernelSum, summB / kernelSum);
                    processedImage.SetPixel(x, y, newColor);
                }
            }

            return processedImage;
        }
        //Uzaysal filtreleme buton
        private void uzaysalFiltre_Btn_Click(object sender, EventArgs e)
        {
            if (originalImage == null)
                return;

            processingImage = OrtalamaFiltre(originalImage);
            pictureBox2.Image = processingImage;
        }
        //frekans fonksiyon
        private Bitmap YuksekGecirenFiltre(Bitmap original)
        {
            Bitmap yeniResim = new Bitmap(original.Width, original.Height);

            int[,] kernel = {
                { -1, -1, -1 },
                { -1,  9, -1 },
                { -1, -1, -1 }
                };

            for (int x = 1; x < original.Width - 1; x++)
            {
                for (int y = 1; y < original.Height - 1; y++)
                {
                    int toplamR = 0, toplamG = 0, toplamB = 0;

                    for (int kx = -1; kx <= 1; kx++)
                    {
                        for (int ky = -1; ky <= 1; ky++)
                        {
                            Color komsuPixel = original.GetPixel(x + kx, y + ky);
                            int kernelDeger = kernel[kx + 1, ky + 1];

                            toplamR += komsuPixel.R * kernelDeger;
                            toplamG += komsuPixel.G * kernelDeger;
                            toplamB += komsuPixel.B * kernelDeger;
                        }
                    }

                    toplamR = Math.Min(Math.Max(toplamR, 0), 255);
                    toplamG = Math.Min(Math.Max(toplamG, 0), 255);
                    toplamB = Math.Min(Math.Max(toplamB, 0), 255);

                    yeniResim.SetPixel(x, y, Color.FromArgb(toplamR, toplamG, toplamB));
                }
            }
            return yeniResim;
        }

        //frekans filtreleme btuonu
        private void yuksekFiltre_Btn_Click(object sender, EventArgs e)
        {
            if (originalImage == null)
                return;

            processingImage = YuksekGecirenFiltre(originalImage);
            pictureBox2.Image = processingImage;
        }

        private void clr_Button_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            originalImage = null;
            processingImage = null;
        }

        public Form1()
        {
            InitializeComponent();
        }


    }
}
