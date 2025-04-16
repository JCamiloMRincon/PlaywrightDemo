using EAFramework.Driver;

namespace EAFramework.Config
{
    public class TestSettings
    {
        public string? ApplicationUrl { get; set; }
        public string[]? Args { get; set; }
        public float? Timeout { get; set; }
        public bool Headless { get; set; }
        public float? SlowMo { get; set; }
        public DriverType DriverType { get; set; }
    }
}
