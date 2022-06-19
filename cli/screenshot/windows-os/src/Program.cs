using System.Drawing;

Config.Item config = Config.get();
string debugSavePath = "../tmp/screenshot.png";

Console.WriteLine("ONE OF FOLLOWING WINDOW TITLES HAS TO MATCH PROVIDED WINDOW TITLE IN ./config.json");
Debug.listWindows(); // debug

Console.WriteLine("GET WINDOW BY TITLE: {0}", config.windowName);
IntPtr windowHandle = Window.getWindowByTitle(config.windowName);

Console.WriteLine("TMP SCREENSHOT SAVED.");
Bitmap screenshotA = getScreenshot(windowHandle, config.cropX, config.cropY, config.cropWidth, config.cropHeight);
Image.saveScreenshot(screenshotA, debugSavePath); // debug

Console.WriteLine("SCREENSHOT COMPARISON STARTED...");
PeriodicTimer periodicTimer = new PeriodicTimer(TimeSpan.FromMilliseconds(config.delay));
while (await periodicTimer.WaitForNextTickAsync()) {
    await Task.Delay(config.delay).ContinueWith(o => {
        Bitmap screenshotB = getScreenshot(windowHandle, config.cropX, config.cropY, config.cropWidth, config.cropHeight);

        int diff = Image.compare(screenshotA, screenshotB);

        Console.WriteLine(diff);

        if (config.saveOnTreshold > 0 && diff > config.saveOnTreshold)  {
            string date = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            string tresholdSavePath = String.Format("../tmp/{0}_{1}.png", date, diff.ToString());
            Image.saveScreenshot(screenshotA, tresholdSavePath);
        }

        // continous operation
        screenshotA = screenshotB;

        GarbageCollector.execute();
    });
}

static Bitmap getScreenshot (IntPtr windowHandle, int cropX, int cropY, int cropWidth, int cropHeight) {
    Bitmap screenshot = Screenshot.getWindowScreenshot(windowHandle);
    
    Rectangle crop = new Rectangle(cropX, cropY, cropWidth, cropHeight);
    Bitmap screenshotCropped = Image.crop(screenshot, crop);

    return screenshotCropped;
}
