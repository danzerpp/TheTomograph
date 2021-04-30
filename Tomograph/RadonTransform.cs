using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dicom;
using NumSharp;

namespace Tomograph
{
    public class RadonTransform
    {

        public Bitmap InBitmap;

        public Bitmap Sinogram;
        public Bitmap SinogramFiltered;
        public int[,] SinogramValues;
        public int[,] SinogramFilteredValues;
        // nowa tablica do rozmania

        int[,] OutBitmapValues;
        int[,] OutFilteredBitmapValues;


        public int Scans;
        public int Detectors;
        public int BeamExtend;

        public RadonTransform(Bitmap inBitmap, int scans, int detectors, int beamExtend)
        {

            this.InBitmap = inBitmap;
            // tworzymy 100% skalę szarości
            for (int i = 0; i < inBitmap.Width; i++)
            {
                for (int j = 0; j < inBitmap.Height; j++)
                {
                    Color oc = inBitmap.GetPixel(i, j);
                    int grayScale = (int)((oc.R * 0.3) + (oc.G * 0.59) + (oc.B * 0.11));
                    Color nc = Color.FromArgb(oc.A, grayScale, grayScale, grayScale);
                    inBitmap.SetPixel(i, j, nc);
                }
            }


            this.Scans = scans;
            this.Detectors = detectors;
            this.BeamExtend = beamExtend;

            SinogramValues = new int[scans, detectors];
            SinogramFilteredValues = new int[scans, detectors];

            OutBitmapValues =  new int[InBitmap.Width, InBitmap.Height];
            OutFilteredBitmapValues = new int[InBitmap.Width, InBitmap.Height];

            for (int i = 0; i < InBitmap.Width; i++)
            {
                for (int j = 0; j < InBitmap.Height; j++)
                {
                    OutBitmapValues[i, j] = 0;
                    OutFilteredBitmapValues[i, j] = 0;
                }
            }
            
        }

        public Bitmap CreateOutImage(int iteration)
        {
            Bitmap outBitmap = new Bitmap(InBitmap.Width,InBitmap.Height);
            for (int i = 0; i < InBitmap.Width; i++)
            {
                for (int j = 0; j < InBitmap.Height; j++)
                {
                      outBitmap.SetPixel(i,j, Color.FromArgb(0,0,0));
                }
            }

            int r = InBitmap.Width > InBitmap.Height ? InBitmap.Width / 2 : InBitmap.Height / 2;
            double angle = 360 / (double)Scans;

            int count = 0;
            for (double alfa = 0; alfa < iteration*30; alfa = alfa + angle)
            {
                //x,y - Emiter
                int eX = (int)(r * Math.Cos(GetRadians(alfa)));
                int eY = (int)(r * Math.Sin(GetRadians(alfa)));

                //x,y - D0 
                int dX = (int)(r * Math.Cos(GetRadians(alfa) + Math.PI - (GetRadians(BeamExtend) / 2)));
                int dY = (int)(r * Math.Sin(GetRadians(alfa) + Math.PI - (GetRadians(BeamExtend) / 2)));

                //Przy wyszukiwaniu punktów dodajemy do x i y "r", bo wzór jest ustawiony tak, że środek koła
                // znajduje się w punkcie (0,0). Dodając "r" przenosimy się w przestrzeń bitmapy tj. tylko pierwsza ćwiartka układu
                List<Point> points = GetPointsOnLine(eX + r, eY + r, dX + r, dY + r);
                SetColorsToBitmapPixels(outBitmap, points, SinogramValues[count,0]);

                //x,y - Di
                for (int i = 1; i < Detectors - 1; i++)
                {
                    dX = (int)(r * Math.Cos(GetRadians(alfa) + Math.PI - (GetRadians(BeamExtend) / 2) + i * (GetRadians(BeamExtend) / (Detectors - 1))));
                    dY = (int)(r * Math.Sin(GetRadians(alfa) + Math.PI - (GetRadians(BeamExtend) / 2) + i * (GetRadians(BeamExtend) / (Detectors - 1))));

                    points = GetPointsOnLine(eX + r, eY + r, dX + r, dY + r);
                    SetColorsToBitmapPixels(outBitmap, points, SinogramValues[count, i]);
                }

                //Dn-1
                dX = (int)(r * Math.Cos(GetRadians(alfa) + Math.PI + (GetRadians(BeamExtend) / 2)));
                dY = (int)(r * Math.Sin(GetRadians(alfa) + Math.PI + (GetRadians(BeamExtend) / 2)));

                points = GetPointsOnLine(eX + r, eY + r, dX + r, dY + r); // pobieramy punkty znajdujące się na linii emiter-detektor
                SetColorsToBitmapPixels(outBitmap, points, SinogramValues[count, Detectors - 1]);

                count++; // który scan w sinogramie
            }
            //znowu min max
            int min = 255;
            int max = 0;

            foreach (var value in OutBitmapValues)
            {
                if (value > max)
                {
                    max = value;
                }
                if (min > value)
                {
                    min = value;
                }
            }
            // tworzymy wartości w zakresie
            for(int i = 0; i < InBitmap.Width; i++)
            {
                for (int j = 0; j < InBitmap.Height; j++)
                {
                  
                    OutBitmapValues[i, j] = Constraint(OutBitmapValues[i, j], 0, 255, min, max);  
                }
            }
            // i je wyrzucamy w koncowej bitmapie
            for (int i = 0; i < InBitmap.Width; i++)
            {
                for (int j = 0; j < InBitmap.Height; j++)
                {
                    Color color =  Color.FromArgb(OutBitmapValues[i, j], OutBitmapValues[i, j], OutBitmapValues[i, j]);
                    outBitmap.SetPixel(i, j, color); 
                }
            }


            return outBitmap;
        }


        private void SetColorsToBitmapPixels(Bitmap bitmap, List<Point> points, int value)
        {
            foreach (var point in points)
            {
                if (point.X > 0 && point.X < InBitmap.Width && point.Y > 0 && point.Y < InBitmap.Height)
                {
                    OutBitmapValues[point.X, point.Y] += value;
                }
                
                // tu aktualziacja wartosci
            }
        }





        public Bitmap CreateSinogram()
        {
            int r = InBitmap.Width > InBitmap.Height  ? InBitmap.Width/2 : InBitmap.Height /2;
            double angle = 360 / (double)Scans;

            Bitmap tempSinogram = new Bitmap(Detectors, Scans);
           
            int count = 0;
            for (double alfa = 0; alfa < 360; alfa = alfa + angle)
            {
                //x,y - Emiter
                int eX = (int)(r * Math.Cos(GetRadians(alfa)));
                int eY = (int)(r * Math.Sin(GetRadians(alfa)));
               
                //x,y - D0 
                int dX = (int)(r * Math.Cos(GetRadians(alfa) + Math.PI - (GetRadians(BeamExtend) / 2)));
                int dY = (int)(r * Math.Sin(GetRadians(alfa) + Math.PI - (GetRadians(BeamExtend) / 2)));

                //Przy wyszukiwaniu punktów dodajemy do x i y "r", bo wzór jest ustawiony tak, że środek koła
                // znajduje się w punkcie (0,0). Dodając "r" przenosimy się w przestrzeń bitmapy tj. tylko pierwsza ćwiartka układu
                List<Point> points = GetPointsOnLine(eX + r, eY + r, dX + r, dY + r);
                int color = GetColorFromPoints(points);
                tempSinogram.SetPixel(0, count, Color.FromArgb(color, color, color));
                SinogramValues[count, 0] = color;
                //x,y - Di
                for (int i = 1; i < Detectors - 1; i++)
                {
                    dX = (int)(r * Math.Cos(GetRadians(alfa) + Math.PI - (GetRadians(BeamExtend) / 2) + i * (GetRadians(BeamExtend) / (Detectors - 1))));
                    dY = (int)(r * Math.Sin(GetRadians(alfa) + Math.PI - (GetRadians(BeamExtend) / 2) + i * (GetRadians(BeamExtend) / (Detectors - 1))));
                   
                    points = GetPointsOnLine(eX + r, eY + r, dX + r, dY + r);
                    color = GetColorFromPoints(points);
                    tempSinogram.SetPixel(i, count, Color.FromArgb(color, color, color));
                    SinogramValues[count, i] = color;
                }

                //Dn-1
                dX = (int)(r * Math.Cos(GetRadians(alfa) + Math.PI + (GetRadians(BeamExtend) / 2)));
                dY = (int)(r * Math.Sin(GetRadians(alfa) + Math.PI + (GetRadians(BeamExtend) / 2)));
               
                points = GetPointsOnLine(eX + r, eY + r, dX + r, dY + r); // pobieramy punkty znajdujące się na linii emiter-detektor
                color = GetColorFromPoints(points);// obliczamy kolor
                tempSinogram.SetPixel(Detectors - 1, count, Color.FromArgb(color, color, color));
                SinogramValues[count, Detectors - 1] = color;

                count ++; // który scan w sinogramie
            }
            //tworzymy chwilową tablicę, żeby przeskalować
            var tempSinogramValues = new int[Scans, Detectors];
            for (int i = 0; i < Scans; i++)
            {
                for (int j = 0; j < Detectors; j++)
                {
                    tempSinogramValues[i, j] = SinogramValues[i, j];
                }
            }
            //pobieramy min max
            int min = 255;
            int max = 0;
            foreach (var value in tempSinogramValues)
            {
                if (value > max)
                {
                    max = value;
                }
                if (min > value)
                {
                    min = value;
                }
            }

            
            //dla temp tworzymy wartości z przedziału 0..255
            for (int i = 0; i < 90; i++)
            {
                for (int j = 0; j < 180; j++)
                {
                    tempSinogramValues[i, j] = Constraint(tempSinogramValues[i, j], 0, 255, min, max);
                }
            }
            //i tu przybijamy to do bitmapy, żeby zawsze mieć do niej dostęp
            Bitmap sinogram = new Bitmap(Detectors, Scans);
          
            for (int i = 0; i < Detectors; i++)
            {
                for (int j =0; j < Scans; j++)
                {
                    //Odwracamy sinogram do odpowiedniej pozycji
                    Color color = Color.FromArgb(tempSinogramValues[Scans - 1 - j, Detectors - 1 - i], tempSinogramValues[Scans - 1 - j, Detectors - 1 - i], tempSinogramValues[Scans - 1 - j, Detectors - 1 - i]);
                    sinogram.SetPixel(i, j, color);
                }
            }


            this.Sinogram = sinogram;          

            return sinogram;
        }
         public Bitmap CreateFilteredSinogram()
        {

            var newSinogram = new int[Scans, Detectors];
            for (int i = 0; i < Scans; i++)
            {
                var sinogramRow = new int[Detectors];
                var sinogramKernel= new int[Detectors];

                for (int j = 0; j < Detectors; j++)
                {
                    sinogramRow[j] = SinogramValues[i, j];
                    if (j == 0)
                    {
                        sinogramKernel[j] = 1;

                    }
                    else if (j % 2 ==0)
                    {
                        sinogramKernel[j] = 0;
                    }
                    else
                    {
                        sinogramKernel[j] = (int)((-4 * Math.Pow(Math.PI,2)) / Math.Pow(j,2));

                    }
                }
                var x = np.convolve(sinogramRow, sinogramKernel, "same");

            }

            Bitmap sinogram = new Bitmap(Detectors, Scans);

            int min = 255;
            int max = 0;
            foreach (var value in newSinogram)
            {
                if (value > max)
                {
                    max = value;
                }
                if (min > value)
                {
                    min = value;
                }
            }


            //dla temp tworzymy wartości z przedziału 0..255
            for (int i = 0; i < 90; i++)
            {
                for (int j = 0; j < 180; j++)
                {
                    newSinogram[i, j] = Constraint(newSinogram[i, j], 0, 255, min, max);
                }
            }
             min = 255;
             max = 0;
            foreach (var value in newSinogram)
            {
                if (value > max)
                {
                    max = value;
                }
                if (min > value)
                {
                    min = value;
                }
            }

            for (int i = 0; i < Detectors; i++)
            {
                for (int j = 0; j < Scans; j++)
                {
                    //Odwracamy sinogram do odpowiedniej pozycji
                    Color color = Color.FromArgb(newSinogram[Scans - 1 - j, Detectors - 1 - i], newSinogram[Scans - 1 - j, Detectors - 1 - i], newSinogram[Scans - 1 - j, Detectors - 1 - i]);
                    sinogram.SetPixel(i, j, color);
                }
            }
            return sinogram;
        }
        private static int Constraint(double value, double minRange, double maxRange,
                                           double minVal, double maxVal)
        {
            return (int)(((value - minVal) / (maxVal - minVal)) *
                      (maxRange - minRange) + minRange);
        }

        private double GetRadians(double angle)
        {
            return (Math.PI / 180) * angle;
        }

        private int GetColorFromPoints(List<Point> points)
        {
            int count = 0;
            int sum = 0;
            foreach (var point in points)
            {
                if (point.X > 0 && point.X < InBitmap.Width && point.Y > 0 && point.Y < InBitmap.Height)
                {
                    sum += InBitmap.GetPixel(point.X, point.Y).R; // sumujemy wartość 'wystarczy jedna bo dla rgb skali szarości wszystkie są równe'
                    count++;
                }
            }

            return Math.Min(sum / count , 255); // dzielimy przez ilość punktów

        }

        private List<Point> GetPointsOnLine(int x0, int y0, int x1, int y1) // funkcja z neta, ale tej nie musieliśmy pisać sami
        {
            List<Point> points = new List<Point>();
            bool steep = Math.Abs(y1 - y0) > Math.Abs(x1 - x0);
            if (steep)
            {
                int t;
                t = x0; // swap x0 and y0
                x0 = y0;
                y0 = t;
                t = x1; // swap x1 and y1
                x1 = y1;
                y1 = t;
            }
            if (x0 > x1)
            {
                int t;
                t = x0; // swap x0 and x1
                x0 = x1;
                x1 = t;
                t = y0; // swap y0 and y1
                y0 = y1;
                y1 = t;
            }
            int dx = x1 - x0;
            int dy = Math.Abs(y1 - y0);
            int error = dx / 2;
            int ystep = (y0 < y1) ? 1 : -1;
            int y = y0;
            for (int x = x0; x <= x1; x++)
            {
                points.Add(new Point((steep ? y : x), (steep ? x : y)));
                error = error - dy;
                if (error < 0)
                {
                    y += ystep;
                    error += dx;
                }
            }
            return points;
        }



    }
}
