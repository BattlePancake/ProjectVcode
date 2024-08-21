using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjectVcode.ModelsAPI.Responses.DefectsResponses;
using ProjectVcode.RequestBuilders.DefectsBuilders;
using ProjectVcode.API;
using ProjectVcode.ModelsAPI.Responses.DefectsResponse;
using NUnit.Allure.Core;

namespace ProjectVcode.TestsAPI
{
    [AllureNUnit]
    internal class DefectsTestsAPI
    {
        private const string BaseUrl = "https://api.qase.io/v1/";
        private const string ProjectsUrl = "defect";

        [TestCase("DEMO")]
        [Description("Get All defects - Positive")]
        public void AllDefectstPositive(string projectCode)
        {
            var response = SetAndExecute.Request(BaseUrl, $"{ProjectsUrl}/{projectCode}", Method.Get);

            Assert.That((int)response.StatusCode, Is.EqualTo(200));

            var modelResponse = JsonConvert.DeserializeObject<AllDefectsResponse>(response.Content);
            var jsonResponse = JObject.Parse(response.Content);
            Console.WriteLine("{0}", jsonResponse);

            Assert.That(modelResponse.Status, Is.True);
            Assert.That(modelResponse.Result.total, Is.EqualTo(2));
            Assert.That(modelResponse.Result.entities[1].id, Is.EqualTo(2));
            Assert.That(modelResponse.Result.entities[1].title, Is.EqualTo("1APITestDefect1"));
            Assert.That(modelResponse.Result.entities[1].actual_result, Is.EqualTo("It's a feature"));
            Assert.That(modelResponse.Result.entities[1].status, Is.EqualTo("open"));
            Assert.That(modelResponse.Result.entities[1].severity, Is.EqualTo("blocker"));
            Assert.That(modelResponse.Result.entities[1].created, Is.EqualTo(DateTime.UtcNow).Within(TimeSpan.FromHours(5)));
        }

        [TestCase("TP", "TestDefectAPI1", "Bug is in your mind", 2)]
        [Description("Create project - Positive")]
        public void CreateProjectPositive(string projectCode, string defectTitle, string actual_result, int severity)
        {
            var requestBody = new CreateDefectRequestBuilder()
                                    .Title(defectTitle)
                                    .Actual_result(actual_result)
                                    .Severity(severity)
                                    .Build();
            var response = SetAndExecute.RequestWithBody(BaseUrl, $"{ProjectsUrl}/{projectCode}", Method.Post, requestBody);

            Assert.That((int)response.StatusCode, Is.EqualTo(200));

            var modelResponse = JsonConvert.DeserializeObject<CreateDefectResponse>(response.Content);
            var jsonResponse = JObject.Parse(response.Content);
            Console.WriteLine("{0}", jsonResponse);

            Assert.That(modelResponse.Status, Is.True);
        }
    }
}
