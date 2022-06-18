public class Sound {
    public static void play (string path)
    {
        WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
        wplayer.URL = path;
        wplayer.controls.play();
    }
}
