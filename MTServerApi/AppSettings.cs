using Newtonsoft.Json;

namespace mtvendors_api
{
    public class AppSettings
    {
        public static string GetValue(string key, string appSettingsJsonFilePath = null)
        {
            if (appSettingsJsonFilePath == null)
            {
                appSettingsJsonFilePath = Path.Combine(AppContext.BaseDirectory, "appsettings.json");
            }

            var json = File.ReadAllText(appSettingsJsonFilePath);
            dynamic jsonObj = JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject>(json);

            return jsonObj[key];
        }

        public static void SetValue(string key, string value, string appSettingsJsonFilePath = null)
        {
            if (appSettingsJsonFilePath == null)
            {
                appSettingsJsonFilePath = Path.Combine(AppContext.BaseDirectory, "appsettings.json");
            }

            var json = File.ReadAllText(appSettingsJsonFilePath);
            dynamic jsonObj = JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject>(json);

            jsonObj[key] = value;

            string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);

            File.WriteAllText(appSettingsJsonFilePath, output);
        }
    }
}
