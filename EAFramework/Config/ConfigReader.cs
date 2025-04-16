using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EAFramework.Config
{
    public static class ConfigReader
    {
        public static TestSettings ReadConfig() 
        {
            var configFile = File.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/appsettings.json");
            
            var jsonSerializerSettings = new JsonSerializerOptions() 
            {
                PropertyNameCaseInsensitive = true
            };

            // It is because the TestSettings class contains an enum: the DriverType.
            jsonSerializerSettings.Converters.Add(new JsonStringEnumConverter());

            TestSettings? settings = JsonSerializer.Deserialize<TestSettings>(configFile, jsonSerializerSettings);

            if (settings == null)
                throw new InvalidOperationException("It was not possible to deserialize the settings file.");

            return settings;
        }
    }
}
