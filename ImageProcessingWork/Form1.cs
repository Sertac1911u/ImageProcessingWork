using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ImageProcessingWork
{
    public partial class Form1 : Form
    {
        public Bitmap originalImage, processingImage;
        //Select image butonu
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


        // Ortalama (Mean) Filtresi
        private Bitmap MeanFilter(Bitmap image)
        {
            Bitmap filteredImage = new Bitmap(image.Width, image.Height);
            for (int x = 1; x < image.Width - 1; x++)
            {
                for (int y = 1; y < image.Height - 1; y++)
                {
                    int avgR = 0, avgG = 0, avgB = 0;
                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            Color pixel = image.GetPixel(x + i, y + j);
                            avgR += pixel.R;
                            avgG += pixel.G;
                            avgB += pixel.B;
                        }
                    }
                    avgR /= 9; avgG /= 9; avgB /= 9;
                    filteredImage.SetPixel(x, y, Color.FromArgb(avgR, avgG, avgB));
                }
            }
            return filteredImage;
        }

        // Gaussian Blurring Filtresi
        private Bitmap GaussianBlur(Bitmap image)
        {
            double[,] kernel = {
        { 1, 2, 1 },
        { 2, 4, 2 },
        { 1, 2, 1 }};

            Bitmap filteredImage = new Bitmap(image.Width, image.Height);

            for (int x = 1; x < image.Width - 1; x++)
            {
                for (int y = 1; y < image.Height - 1; y++)
                {
                    double sumR = 0, sumG = 0, sumB = 0;
                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            Color pixel = image.GetPixel(x + i, y + j);
                            sumR += pixel.R * kernel[i + 1, j + 1];
                            sumG += pixel.G * kernel[i + 1, j + 1];
                            sumB += pixel.B * kernel[i + 1, j + 1];
                        }
                    }
                    sumR /= 16; sumG /= 16; sumB /= 16;
                    filteredImage.SetPixel(x, y, Color.FromArgb((int)sumR, (int)sumG, (int)sumB));
                }
            }
            return filteredImage;
        }

        // Laplace Filtresi
        private Bitmap LaplaceFilter(Bitmap image)
        {
            int[,] kernel = {
        { 0,  1, 0 },
        { 1, -4, 1 },
        { 0,  1, 0 }};

            Bitmap filteredImage = new Bitmap(image.Width, image.Height);

            for (int x = 1; x < image.Width - 1; x++)
            {
                for (int y = 1; y < image.Height - 1; y++)
                {
                    int sum = 0;
                    for (int i = -1; i <= 1; i++)
                        for (int j = -1; j <= 1; j++)
                            sum += image.GetPixel(x + i, y + j).R * kernel[i + 1, j + 1];

                    sum = Math.Min(Math.Max(sum, 0), 255);
                    filteredImage.SetPixel(x, y, Color.FromArgb(sum, sum, sum));
                }
            }
            return filteredImage;
        }

        // Sobel Filtresi
        private Bitmap SobelFilter(Bitmap image)
        {
            int[,] gx = { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
            int[,] gy = { { 1, 2, 1 }, { 0, 0, 0 }, { -1, -2, -1 } };

            Bitmap filteredImage = new Bitmap(image.Width, image.Height);

            for (int x = 1; x < image.Width - 1; x++)
            {
                for (int y = 1; y < image.Height - 1; y++)
                {
                    int sumX = 0, sumY = 0;
                    for (int i = -1; i <= 1; i++)
                        for (int j = -1; j <= 1; j++)
                        {
                            int pixelVal = image.GetPixel(x + i, y + j).R;
                            sumX += gx[i + 1, j + 1] * pixelVal;
                            sumY += gy[i + 1, j + 1] * pixelVal;
                        }

                    int sum = (int)Math.Sqrt(sumX * sumX + sumY * sumY);
                    sum = Math.Min(Math.Max(sum, 0), 255);
                    filteredImage.SetPixel(x, y, Color.FromArgb(sum, sum, sum));
                }
            }
            return filteredImage;
        }
        // Prewitt Filtresi
        private Bitmap PrewittFilter(Bitmap image)
        {
            Bitmap filteredImage = new Bitmap(image.Width, image.Height);

            int[,] Gx = {{-1, 0, 1},
                  {-1, 0, 1},
                  {-1, 0, 1}};

            int[,] Gy = {{-1, -1, -1},
                  { 0,  0,  0},
                  { 1,  1,  1}};

            for (int x = 1; x < image.Width - 1; x++)
            {
                for (int y = 1; y < image.Height - 1; y++)
                {
                    int sumX = 0;
                    int sumY = 0;

                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            int gray = image.GetPixel(x + i, y + j).R;

                            sumX += gray * Gx[i + 1, j + 1];
                            sumY += gray * Gy[i + 1, j + 1];
                        }
                    }

                    int val = (int)Math.Sqrt(sumX * sumX + sumY * sumY);
                    val = Math.Max(0, Math.Min(255, val));

                    filteredImage.SetPixel(x, y, Color.FromArgb(val, val, val));
                }
            }

            return filteredImage;
        }
        //Minimum Filtre
        private Bitmap MinFilter(Bitmap image)
        {
            Bitmap filteredImage = new Bitmap(image.Width, image.Height);

            for (int x = 1; x < image.Width - 1; x++)
            {
                for (int y = 1; y < image.Height - 1; y++)
                {
                    int minR = 255, minG = 255, minB = 255;

                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            Color c = image.GetPixel(x + i, y + j);
                            if (c.R < minR) minR = c.R;
                            if (c.G < minG) minG = c.G;
                            if (c.B < minB) minB = c.B;
                        }
                    }

                    filteredImage.SetPixel(x, y, Color.FromArgb(minR, minG, minB));
                }
            }
            return filteredImage;
        }
        //Maksimum Filtre
        private Bitmap MaxFilter(Bitmap image)
        {
            Bitmap filteredImage = new Bitmap(image.Width, image.Height);

            for (int x = 1; x < image.Width - 1; x++)
            {
                for (int y = 1; y < image.Height - 1; y++)
                {
                    int maxR = 0, maxG = 0, maxB = 0;

                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            Color c = image.GetPixel(x + i, y + j);
                            if (c.R > maxR) maxR = c.R;
                            if (c.G > maxG) maxG = c.G;
                            if (c.B > maxB) maxB = c.B;
                        }
                    }

                    filteredImage.SetPixel(x, y, Color.FromArgb(maxR, maxG, maxB));
                }
            }
            return filteredImage;
        }
        //median Filtre
        private Bitmap MedianFilter(Bitmap image)
        {
            Bitmap filteredImage = new Bitmap(image.Width, image.Height);

            for (int x = 1; x < image.Width - 1; x++)
            {
                for (int y = 1; y < image.Height - 1; y++)
                {
                    List<int> reds = new List<int>();
                    List<int> greens = new List<int>();
                    List<int> blues = new List<int>();

                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            Color c = image.GetPixel(x + i, y + j);
                            reds.Add(c.R);
                            greens.Add(c.G);
                            blues.Add(c.B);
                        }
                    }

                    reds.Sort();
                    greens.Sort();
                    blues.Sort();

                    int medianR = reds[4];
                    int medianG = greens[4];
                    int medianB = blues[4];

                    filteredImage.SetPixel(x, y, Color.FromArgb(medianR, medianG, medianB));
                }
            }

            return filteredImage;
        }
        //K-en Yakın Komşu Filtre
        private Bitmap KNearestFilter(Bitmap image, int k = 5)
        {
            Bitmap filteredImage = new Bitmap(image.Width, image.Height);

            for (int x = 1; x < image.Width - 1; x++)
            {
                for (int y = 1; y < image.Height - 1; y++)
                {
                    Color center = image.GetPixel(x, y);
                    int centerR = center.R;
                    int centerG = center.G;
                    int centerB = center.B;

                    List<(double distance, Color pixelColor)> distances = new List<(double, Color)>();
                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            Color c = image.GetPixel(x + i, y + j);

                            double d = (c.R - centerR) * (c.R - centerR) +
                                       (c.G - centerG) * (c.G - centerG) +
                                       (c.B - centerB) * (c.B - centerB);

                            distances.Add((d, c));
                        }
                    }

                    distances.Sort((a, b) => a.distance.CompareTo(b.distance));

                    int sumR = 0, sumG = 0, sumB = 0;
                    for (int n = 0; n < k; n++)
                    {
                        sumR += distances[n].pixelColor.R;
                        sumG += distances[n].pixelColor.G;
                        sumB += distances[n].pixelColor.B;
                    }

                    int avgR = sumR / k;
                    int avgG = sumG / k;
                    int avgB = sumB / k;

                    filteredImage.SetPixel(x, y, Color.FromArgb(avgR, avgG, avgB));
                }
            }

            return filteredImage;
        }
        // Basit Alçak Geçiren Filtre
        private Bitmap LowPassFilter(Bitmap image)
        {
            return MeanFilter(image); 
        }

        // Basit Yüksek Geçiren Filtre
        private Bitmap HighPassFilter(Bitmap image)
        {
            Bitmap blurred = MeanFilter(image);
            Bitmap filteredImage = new Bitmap(image.Width, image.Height);

            for (int x = 0; x < image.Width; x++)
                for (int y = 0; y < image.Height; y++)
                {
                    Color origPixel = image.GetPixel(x, y);
                    Color blurPixel = blurred.GetPixel(x, y);

                    int r = Math.Min(Math.Max(origPixel.R - blurPixel.R + 128, 0), 255);
                    int g = Math.Min(Math.Max(origPixel.G - blurPixel.G + 128, 0), 255);
                    int b = Math.Min(Math.Max(origPixel.B - blurPixel.B + 128, 0), 255);

                    filteredImage.SetPixel(x, y, Color.FromArgb(r, g, b));
                }

            return filteredImage;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(new String[]
            {
                "Ortalama (Mean) Filtresi",
                "Gaussian Blurring Filtre",
                "Laplace Filtresi",
                "Sobel Filtresi",
                "Alçak Geçiren Filtre",
                "Yüksek Geçiren Filtre",
                "Prewitt Filtresi",
                "Minimum Filtre",
                "Maximum Filtre",
                "Median Filtre",
                "K-en Yakın Komşu Filtre"
            });
            comboBox1.SelectedIndex = 0;
        }

        private void apply_btn_Click(object sender, EventArgs e)
        {
            if (originalImage == null)
            {
                MessageBox.Show("Önce bir görüntü seçin!");
                return;
            }
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    // Ortalama (Mean) Filtresi
                    processingImage = MeanFilter(originalImage);
                    break;
                case 1:
                    // Gaussian Blurring
                    processingImage = GaussianBlur(originalImage);
                    break;
                case 2:
                    // Laplace Filtresi
                    processingImage = LaplaceFilter(originalImage);
                    break;
                case 3:
                    // Sobel Filtresi
                    processingImage = SobelFilter(originalImage);
                    break;
                case 4:
                    // Alçak Geçiren Filtre
                    processingImage = LowPassFilter(originalImage);
                    break;
                case 5:
                    // Yüksek Geçiren Filtre
                    processingImage = HighPassFilter(originalImage);
                    break;
                case 6:
                    // Prewitt Filtresi
                    processingImage = PrewittFilter(originalImage);
                    break;
                case 7:
                    // Minimum Filtre
                    processingImage = MinFilter(originalImage);
                    break;
                case 8:
                    // Maximum Filtre
                    processingImage = MaxFilter(originalImage);
                    break;
                case 9:
                    // Median Filtre
                    processingImage = MedianFilter(originalImage);
                    break;
                case 10:
                    // K-en Yakın Komşu Filtre
                    processingImage = KNearestFilter(originalImage, 5);
                    break;
                default:
                    MessageBox.Show("Geçerli bir filtre seçin.");
                    return;
            }

            pictureBox2.Image = processingImage;


        }

        private void clr_Button_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            originalImage = null;
            processingImage = null;
        }

    }
}
