using PlaywrightDemo.Driver;

namespace PlaywrightDemo.Config
{
    public class TestSettings
    {
        public bool Headless { get; set; }
        public string? Channel { get; set; }
        public int SlowMo { get; set; }
        public DriverType DriverType { get; set; }
    }
}
