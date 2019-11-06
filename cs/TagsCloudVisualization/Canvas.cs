﻿using System;
using System.Collections.Generic;
using System.Drawing;

namespace TagsCloudVisualization
{
    class Canvas
    {
        Random random;
        Bitmap bitmap;

        public Canvas(int width, int height)
        {
            if (width < 0 || height < 0)
                throw new ArgumentException();

            random = new Random();
            bitmap = new Bitmap(height, width);
        }

        public void Draw(Rectangle rectangle, Brush brush = null)
        {
            var g = Graphics.FromImage(bitmap);
            if (brush == null) g.FillRectangle(RandomBrush(), rectangle);
            else g.FillRectangle(brush, rectangle);
        }

        Brush RandomBrush()
        {
            List<Brush> brushes = new List<Brush>()
            {
                new SolidBrush(Color.Green),
                new SolidBrush(Color.Blue),
                new SolidBrush(Color.Red),
                new SolidBrush(Color.Magenta),
                new SolidBrush(Color.Black),
                new SolidBrush(Color.Aqua),
                new SolidBrush(Color.Indigo),
            };

            return brushes[random.Next(0, brushes.Count)];
        }

        public void Save(string name)
        {
            bitmap.Save(name + ".png");
        }
    }
}
