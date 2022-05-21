using System;
using System.Drawing;

namespace ImageBW
{
    class Program
    {
        static void Main(string[] args)
        {
            const string src = @"C:\temp\FaviconForEditing.png";
            const string dest = @"C:\temp\FaviconForEditingOut.png";

            Color toSave1 = Color.FromArgb(255, 0, 255); //bright pink
            Color toSave2 = Color.Black;
            Color toReplace = Color.Black;

            try
            {
                Bitmap image1 = new Bitmap(src);

                int x, y;

                for (x = 0; x < image1.Width; x++)
                {
                    for (y = 0; y < image1.Height; y++)
                    {
                        Color pixelColor = image1.GetPixel(x, y);
                        if ((pixelColor.R == toSave1.R && pixelColor.G == toSave1.G && pixelColor.B == toSave1.B) ||
                            (pixelColor.R == toSave2.R && pixelColor.G == toSave2.G && pixelColor.B == toSave2.B))
                        {
                            //no-op, leave as-is
                        }
                        else
                        {
                            image1.SetPixel(x, y, toReplace);
                        }
                    }
                }

                image1.Save(dest);
                //PictureBox1.Image = image1;
                //Label1.Text = "Pixel format: " + image1.PixelFormat.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
        }
        //    }
        //    // load input image(bitmap)
        //    Bitmap image1 = new Bitmap(@"C:\image\image1.bmp");

        //    //create output image (bitmap) and set the new pixel format
        //    Bitmap image2 = new Bitmap(image1.Width, image1.Height,
        //        Imaging.PixelFormat.Format24bppRgb);

        //    //draw the input image on the output image within a specified rectangle (area)
        //    using (Graphics gr = Graphics.FromImage(image2))
        //    {
        //        gr.DrawImage(image1, new Rectangle(0, 0, image2.Width, image2.Height));
        //    }

        //    //save output image
        //    image2.Save(@"C:\image\image2.bmp");
        //}
    }
}
