using EAFramework.Driver;

namespace EAFramework.Config
{
    public class TestSettings
    {
        public string[]? Args { get; set; }
        public float? Timeout { get; set; }
        public bool Headless { get; set; }
        public int SlowMo { get; set; }
        public DriverType DriverType { get; set; }
    }
}
