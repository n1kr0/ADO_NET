using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personals_App
{
    public static class CompressImage
    {
        public static Bitmap CreateImage(Bitmap originalPic, int maxWidth, int maxHeight)
        {
            try
            {
                //Розмір старого зображення
                int width = originalPic.Width;
                int height = originalPic.Height;
                //Обчислюємо розмір нового зображення
                int widthDiff = (width - maxWidth);
                int heightDiff = (height - maxHeight);
                //Ширину будемо залишати, міняємо висоту
                bool doWidthResize = (maxWidth > 0 && width > maxWidth && widthDiff > -1 && widthDiff > heightDiff);
                //Висоту залишаємо, міняємо ширину
                bool doHeightResize = (maxHeight > 0 && height > maxHeight && heightDiff > -1 && heightDiff > widthDiff);
                //Обчисленя розміру
                if (doWidthResize || doHeightResize || (width.Equals(height)
                                            && widthDiff.Equals(heightDiff)))
                {
                    int iStart;
                    Decimal divider;
                    if (doWidthResize)
                    {
                        iStart = width;
                        divider = Math.Abs((Decimal)iStart / maxWidth);
                        width = maxWidth;
                        height = (int)Math.Round((height / divider));
                    }
                    else
                    {
                        iStart = height;
                        divider = Math.Abs((Decimal)iStart / maxHeight);
                        height = maxHeight;
                        width = (int)Math.Round((width / divider));
                    }
                }
                using (Bitmap outBmp = new Bitmap(width, height, PixelFormat.Format16bppRgb555))
                {
                    using (Graphics oGraphics = Graphics.FromImage(outBmp))
                    {
                        oGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        oGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        oGraphics.DrawImage(originalPic, 0, 0, width, height);



                        return new Bitmap(outBmp);
                    }
                }
            }
            catch
            {
                return null;
            }




        }
    }
}
