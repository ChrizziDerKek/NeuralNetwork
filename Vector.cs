using System;
using System.Collections.Generic;
using System.Drawing;

namespace NeuralNetwork
{
    public class Vector
    {
        private readonly double[][] Matrix;

        public int Size => Matrix.Length * Matrix[0].Length;

        public Vector(double[][] matrix) => Matrix = matrix;

        public Vector(double[] vector)
        {
            Matrix = new double[1][];
            Matrix[0] = vector;
        }

        public Vector(char letter, int width, int height)
        {
            using (Bitmap bmp = new Bitmap(width, height))
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                using (Font font = new Font("Arial", height - 2, FontStyle.Bold, GraphicsUnit.Pixel))
                    g.DrawString(letter.ToString().ToUpper(), font, Brushes.Black, 0, 0);
                List<double[]> result = new List<double[]>();
                for (int y = 0; y < height; y++)
                {
                    double[] vector = new double[width];
                    for (int x = 0; x < width; x++)
                    {
                        Color pixel = bmp.GetPixel(x, y);
                        vector[x] = pixel.GetBrightness() < 0.5 ? 0.5 : -0.5;
                    }
                    result.Add(vector);
                }
                Matrix = result.ToArray();
            }
        }

        public double[][] GetMatrix() => Matrix;

        public double[] GetVector()
        {
            List<double> result = new List<double>();
            foreach (double[] vector in Matrix)
                result.AddRange(vector);
            return result.ToArray();
        }

        public void Print() => Console.WriteLine(ToString());

        public override string ToString()
        {
            string result = "";
            foreach (double[] vector in Matrix)
            {
                foreach (double pixel in vector)
                    result += pixel < 0 ? " " : "X";
                result += "\n";
            }
            return result;
        }
    }
}