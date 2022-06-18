using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

public class Screenshot
{
    [DllImport("user32.dll")]
    static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);
    [DllImport("user32.dll")]
    static extern bool PrintWindow(IntPtr hWnd, IntPtr hdcBlt, int nFlags);

    public static Bitmap getWindowScreenshot(IntPtr hwnd)
    {
        RECT rc;
        GetWindowRect(hwnd, out rc);

        float scalingFactor = UI.getScalingFactor();
        float rcWidth = (rc.Right - rc.Left) * scalingFactor;
        float rcHeight = (rc.Bottom - rc.Top) * scalingFactor;

        Bitmap bmp = new Bitmap((int)rcWidth, (int)rcHeight, PixelFormat.Format32bppArgb);
        Graphics gfxBmp = Graphics.FromImage(bmp);
        IntPtr hdcBitmap = gfxBmp.GetHdc();

        PrintWindow(hwnd, hdcBitmap, 0);

        gfxBmp.ReleaseHdc(hdcBitmap);
        gfxBmp.Dispose();

        return bmp;
    }

    [StructLayout(LayoutKind.Sequential)]
    struct RECT
    {
        public int Left;   // x position of upper-left corner
        public int Top;    // y position of upper-left corner
        public int Right;  // x position of lower-right corner
        public int Bottom; // y position of lower-right corner
    }
}