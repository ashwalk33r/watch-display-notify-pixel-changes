using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

public class Image
{

    public static void saveScreenshot(Bitmap bmp, string path)
    {
        bmp.Save(path, ImageFormat.Png);
    }

    public static Bitmap crop(Bitmap bmp, Rectangle cropArea)
    {
        return bmp.Clone(cropArea, bmp.PixelFormat);
    }

    public static int compare(Bitmap bitmapA, Bitmap bitmapB)
    {
        int count = 0;

        Rectangle bounds = new Rectangle(0, 0, bitmapA.Width, bitmapA.Height);
        var bmpDataA = bitmapA.LockBits(bounds, ImageLockMode.ReadWrite, bitmapA.PixelFormat);
        var bmpDataB = bitmapB.LockBits(bounds, ImageLockMode.ReadWrite, bitmapB.PixelFormat);

        int npixels = bmpDataA.Height * bmpDataA.Stride / 4;

        unsafe
        {
            int* pPixelsA = (int*)bmpDataA.Scan0.ToPointer();
            int* pPixelsB = (int*)bmpDataB.Scan0.ToPointer();

            for (int i = 0; i < npixels; ++i)
            {
                if (pPixelsA[i] != pPixelsB[i])
                {
                    count = count + 1;
                }
            }
        }
        bitmapA.UnlockBits(bmpDataA);
        bitmapB.UnlockBits(bmpDataB);

        return count;
    }
}
