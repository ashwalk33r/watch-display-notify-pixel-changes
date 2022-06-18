using System.Drawing;
using System.Runtime.InteropServices;

public static class UI
{
    public static float getScalingFactor()
    {
        [DllImport("gdi32.dll")]
        static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

        Graphics g = Graphics.FromHwnd(IntPtr.Zero);
        IntPtr desktop = g.GetHdc();

        int LogicalScreenHeight = GetDeviceCaps(desktop, 10);
        int PhysicalScreenHeight = GetDeviceCaps(desktop, 117);

        float ScreenScalingFactor = (float)PhysicalScreenHeight / (float)LogicalScreenHeight;

        return ScreenScalingFactor;
    }
}