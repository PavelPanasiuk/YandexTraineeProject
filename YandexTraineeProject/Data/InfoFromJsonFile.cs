using System.IO;
using Newtonsoft.Json;

namespace YandexTraineeProject.Data
{
    public class InfoFromJsonFile
    {
        private string _pathToLoginData;
        private string _loginTestDataFileName;

        public InfoFromJsonFile()
        {
            _loginTestDataFileName = "TestData.json";
            _pathToLoginData = Path.Combine(Directory.GetCurrentDirectory(), @"C:\Users\pavel\source\repos\YandexTraineeProject\YandexTraineeProject\Data", _loginTestDataFileName);
        }

        public TestData GetTestData()
        {
            var userString = File.ReadAllText(_pathToLoginData);
            return JsonConvert.DeserializeObject<TestData>(userString);
        }
    }
}
