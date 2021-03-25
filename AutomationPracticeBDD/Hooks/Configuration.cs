using System;
using System.IO;
using System.Threading.Tasks;
using AutomationPracticeBDD.Common.Constants;
using AutomationPracticeBDD.Settings.Models;
using Newtonsoft.Json;
using TechTalk.SpecFlow;

namespace AutomationPracticeBDD.Hooks
{
    [Binding]
    internal class Configuration
    {
        [BeforeTestRun(Order = (int)HookRunOrder.Configuration)]
        public static async Task SetUpProjectConfigurationBeforeTestRun()
        {
            var configFilePath = Path.Combine(AppContext.BaseDirectory, "Settings","Configuration.json");
            var configBytes = await File.ReadAllBytesAsync(configFilePath);

            var configStream = new MemoryStream(configBytes);
            using var streamReader = new StreamReader(configStream);
            using var jsonTextReader = new JsonTextReader(streamReader);

            var jsonSerializer = new JsonSerializer();

            while (await jsonTextReader.ReadAsync())
            {
                switch (jsonTextReader.Value?.ToString())
                {
                    case var configSection when string.Equals(nameof(TestConfiguration),configSection, StringComparison.CurrentCultureIgnoreCase):
                        await jsonTextReader.ReadAsync();

                        ClientTestConfiguration.TestConfiguration =
                            jsonSerializer.Deserialize<TestConfiguration>(jsonTextReader);

                        break;

                }

            }
        }
    }
}
