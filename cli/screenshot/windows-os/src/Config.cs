using Newtonsoft.Json;

class Config
{
    private static Item getJSON()
    {
        using (StreamReader r = new StreamReader("../config.json"))
        {
            string json = r.ReadToEnd();
            Item items = JsonConvert.DeserializeObject<Item>(json);

            return items;
        }
    }

    public static Item get()
    {
        return Config.getJSON();
    }

    public class Item
    {
        public string windowName;
        public int delay;
        public int cropX;
        public int cropY;
        public int cropWidth;
        public int cropHeight;
    }
}