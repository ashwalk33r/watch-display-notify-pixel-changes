using System.Diagnostics;
public class Window 
{    
    public static IntPtr getWindowByTitle(string wName)
    {
        IntPtr hWnd = IntPtr.Zero;
        foreach (Process pList in Process.GetProcesses())
        {
            if (pList.MainWindowTitle.Contains(wName))
            {
                hWnd = pList.MainWindowHandle;
            }
        }

        // Should contain the handle
        // warning! also may be 0 if the title doesn't match
        return hWnd;
    }

}