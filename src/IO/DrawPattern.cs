using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace PathPattern
{
    public class DrawPattern
    {
        public DrawPattern()
        {
        }

        public void DrawPatternToFile(KandinskyPattern pattern, string filename)
        {
            int width = (int)pattern.Width;
            int height = (int)pattern.Height;

            Tuple<float, float>[] centers = pattern.Positions();
            float[] radii = pattern.Radii();

            Rectangle background = new Rectangle(0, 0, width, height);
            Brush backgroundFill = Brushes.Black;
            Brush nodeFill = Brushes.White;

            string filepath = Path.Combine(Directory.GetCurrentDirectory(), "images", filename);

            using (Bitmap newImage = new Bitmap(width, height)) {

                Graphics g = Graphics.FromImage(newImage);

                g.FillRectangle(backgroundFill, background);

                for (int i = 0; i < centers.Length; i++) {
                    Rectangle bounding = boundingRect(centers[i], radii[i]);
                    g.FillEllipse(nodeFill, bounding);
                }

                newImage.Save(filepath, ImageFormat.Png);
            }
        }

        Rectangle boundingRect(Tuple<float, float> center, float radius)
        {
            int topleft_x = (int)center.Item1;
            int topleft_y = (int)center.Item2;
            int r = (int)radius;
            int d = (int)(radius * 2);

            return new Rectangle(topleft_x - r, topleft_y - r, d, d);
        }

        internal void DrawBatchToFile(KandinskyBatch batch, string imageDirectory)
        {
            for (int i = 0; i < batch.Length; i++) {
                KandinskyPattern pattern = batch[i];
                string filename = $"{i:00000}_{pattern.patternData}.png";
                string filepath = Path.Combine(imageDirectory, filename);
                DrawPatternToFile(pattern, filepath);
                batch[i].LinkToFile(filename);
            }
        }
    }
}
