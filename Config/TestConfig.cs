using Newtonsoft.Json;

namespace TibaEvaluationExercise.Config
{
    public class TestConfig
    {
        public string Language { get; set; }
        public string Browser { get; set; }
        public string Url { get; set; }
    }
    
    public static class ConfigLoader { 
        public static TestConfig LoadTestConfig()
        {
            var configPath = AppDomain.CurrentDomain.BaseDirectory;
            configPath = configPath + "Config\\config.json";
            var configText = File.ReadAllText(configPath);
            return JsonConvert.DeserializeObject<TestConfig>(configText);
        }

        public static Dictionary<string, string> LoadTestData(string language)
        {
            string fileName = $"testData{language}.json";
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData", fileName);
            string jsonData = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonData);
        }
    }
}
    