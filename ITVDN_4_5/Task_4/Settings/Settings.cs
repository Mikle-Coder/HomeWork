using System.Windows.Media;

namespace Task_4.Settings
{
    public abstract class Settings
    {
        public Brush BackColor { get; set; }
        public Brush TextColor { get; set; }
        public int TextSize { get; set; }
        public FontFamily TextFont { get; set; }

        public readonly string[] Keys;
        public string[] Values { get => new string[] { BackColor.ToString(), TextColor.ToString(), TextSize.ToString(), TextFont.ToString() }; }
        public Settings()
        {
            SetDefault();
            Keys = new string[] { "BackColor", "TextColor", "TextSize", "TextFont" };
        }

        public void SetDefault() 
        {
            BrushConverter bc = new BrushConverter();

            BackColor = (Brush)bc.ConvertFromString(Colors.White.ToString());
            TextColor = (Brush)bc.ConvertFromString(Colors.Black.ToString());
            TextSize = 10;
            TextFont = new FontFamily("Arial");
        }
        public abstract void SaveSettings();
    }
}
