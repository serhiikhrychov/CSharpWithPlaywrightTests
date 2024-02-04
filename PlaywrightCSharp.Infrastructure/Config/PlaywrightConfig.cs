namespace PlaywrightCSharp.Infrastructure.Helpers
{
    public class Viewport
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public class Screenshots
    {
        public string Path { get; set; }
        public bool OnFailure { get; set; }
    }

    public class PlaywrightConfig
    {
        public string Browser { get; set; }
        public bool Headless { get; set; }
        public Viewport Viewport { get; set; }
        public Screenshots Screenshots { get; set; }

    }
}
