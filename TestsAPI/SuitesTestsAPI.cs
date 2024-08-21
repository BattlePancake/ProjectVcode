using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjectVcode.ModelsAPI.Responses.SuitesResponses;
using ProjectVcode.API;
using ProjectVcode.RequestBuilders.SuitesBuilders;
using NUnit.Allure.Core;

namespace ProjectVcode.TestsAPI
{
    [AllureNUnit]
    internal class SuitesTestsAPI
    {
        private const string BaseUrl = "https://api.qase.io/v1/";
        private const string ProjectsUrl = "suite";

        [TestCase("DEMO")]
        [Description("Get All suites - Positive")]
        public void GetAllSuitesPositive(string projectCode)
        {
            var response = SetAndExecute.Request(BaseUrl, $"{ProjectsUrl}/{projectCode}", Method.Get);

            Assert.That((int)response.StatusCode, Is.EqualTo(200));

            var modelResponse = JsonConvert.DeserializeObject<AllSuitesResponse>(response.Content);
            var jsonResponse = JObject.Parse(response.Content);
            Console.WriteLine("{0}", jsonResponse);

            Assert.That(modelResponse.Status, Is.True);
            Assert.That(modelResponse.Result.total, Is.EqualTo(3));
            Assert.That(modelResponse.Result.entities[0].id, Is.EqualTo(1));
            Assert.That(modelResponse.Result.entities[0].title, Is.EqualTo("Authorization"));
            Assert.That(modelResponse.Result.entities[0].cases_count, Is.EqualTo(4));
        }

        [TestCase("DEMO", "TestAPISuite1")]
        [Description("Create Suite - Positive")]
        public void CreateSuitePositive(string projectCode, string suiteTitle)
        {
            var requestBody = new CreateSuiteRequestBuilder()
                                    .Title(suiteTitle)
                                    .Build();
            var response = SetAndExecute.RequestWithBody(BaseUrl, $"{ProjectsUrl}/{projectCode}", Method.Post, requestBody);

            Assert.That((int)response.StatusCode, Is.EqualTo(200));

            var modelResponse = JsonConvert.DeserializeObject<CreateSuiteResponse>(response.Content);
            var jsonResponse = JObject.Parse(response.Content);
            Console.WriteLine("{0}", jsonResponse);

            Assert.That(modelResponse.Status, Is.True);
        }

        [TestCase("1", "1")]
        [Description("Create Suite - Positive")]
        public void CreateSuiteNegative(string projectCode, string suiteTitle)
        {
            var requestBody = new CreateSuiteRequestBuilder()
                                    .Title(suiteTitle)
                                    .Build();
            var response = SetAndExecute.RequestWithBody(BaseUrl, $"{ProjectsUrl}/{projectCode}", Method.Post, requestBody);

            Assert.That((int)response.StatusCode, Is.EqualTo(404));

            var modelResponse = JsonConvert.DeserializeObject<CreateSuiteResponse>(response.Content);
            var jsonResponse = JObject.Parse(response.Content);
            Console.WriteLine("{0}", jsonResponse);

            Assert.That(modelResponse.Status, Is.False);
            Assert.That(modelResponse.ErrorMessage, Is.EqualTo("Project not found"));
        }

        [TestCase("DEMO", 3)]
        [Description("Get Suite - Positive")]
        public void GetSuitePositive(string projectCode, int suiteId)
        {
            var response = SetAndExecute.Request(BaseUrl, $"{ProjectsUrl}/{projectCode}/{suiteId}", Method.Get);

            Assert.That((int)response.StatusCode, Is.EqualTo(200));

            var modelResponse = JsonConvert.DeserializeObject<GetSuiteResponse>(response.Content);
            var jsonResponse = JObject.Parse(response.Content);
            Console.WriteLine("{0}", jsonResponse);

            Assert.That(modelResponse.Status, Is.True);
            Assert.That(modelResponse.Result.id, Is.EqualTo(3));
            Assert.That(modelResponse.Result.title, Is.EqualTo("Workspace"));
            Assert.That(modelResponse.Result.cases_count, Is.EqualTo(3));
        }

        [TestCase("DEMO", 99)]
        [Description("Get Suite - Negative")]
        public void GetSuiteNegative(string projectCode, int suiteId)
        {
            var response = SetAndExecute.Request(BaseUrl, $"{ProjectsUrl}/{projectCode}/{suiteId}", Method.Get);

            Assert.That((int)response.StatusCode, Is.EqualTo(404));

            var modelResponse = JsonConvert.DeserializeObject<GetSuiteResponse>(response.Content);
            var jsonResponse = JObject.Parse(response.Content);
            Console.WriteLine("{0}", jsonResponse);

            Assert.That(modelResponse.Status, Is.False);
            Assert.That(modelResponse.ErrorMessage, Is.EqualTo("Suite not found"));
        }

        [TestCase("DEMO", 5)]
        [Description("Delete Suite - Positive")]
        public void DeleteSuitePositive(string projectCode, int suiteId)
        {
            var response = SetAndExecute.Request(BaseUrl, $"{ProjectsUrl}/{projectCode}/{suiteId}", Method.Delete);

            Assert.That((int)response.StatusCode, Is.EqualTo(200));

            var modelResponse = JsonConvert.DeserializeObject<DeleteSuiteResponse>(response.Content);
            var jsonResponse = JObject.Parse(response.Content);
            Console.WriteLine("{0}", jsonResponse);

            Assert.That(modelResponse.Status, Is.True);
        }

        [TestCase("DEMO", 5)]
        [Description("Delete Suite - Negative")]
        public void DeleteSuiteNegative(string projectCode, int suiteId)
        {
            var response = SetAndExecute.Request(BaseUrl, $"{ProjectsUrl}/{projectCode}/{suiteId}", Method.Delete);

            Assert.That((int)response.StatusCode, Is.EqualTo(404));

            var modelResponse = JsonConvert.DeserializeObject<DeleteSuiteResponse>(response.Content);
            var jsonResponse = JObject.Parse(response.Content);
            Console.WriteLine("{0}", jsonResponse);

            Assert.That(modelResponse.Status, Is.False);
            Assert.That(modelResponse.ErrorMessage, Is.EqualTo("Suite not found"));
        }

        [TestCase("DEMO", 3, "UpdateSuiteTitleAPI")]
        [Description("Update Suite - Positive")]
        public void UpdateSuitePositive(string projectCode, int suiteId, string suiteTitle)
        {
            var requestBody = new UpdateSuiteRequestBuilder()
                                    .Title(suiteTitle)
                                    .Build();
            var response = SetAndExecute.RequestWithBody(BaseUrl, $"{ProjectsUrl}/{projectCode}/{suiteId}", Method.Patch, requestBody);

            Assert.That((int)response.StatusCode, Is.EqualTo(200));

            var modelResponse = JsonConvert.DeserializeObject<UpdateSuiteResponse>(response.Content);
            var jsonResponse = JObject.Parse(response.Content);
            Console.WriteLine("{0}", jsonResponse);

            Assert.That(modelResponse.Status, Is.True);
            Assert.That(modelResponse.Result.id, Is.EqualTo(3));
        }

        [TestCase("DEMO", 99, "UpdateSuiteTitleAPI")]
        [Description("Update Suite - Negative")]
        public void UpdateSuiteNegative(string projectCode, int suiteId, string suiteTitle)
        {
            var requestBody = new UpdateSuiteRequestBuilder()
                                    .Title(suiteTitle)
                                    .Build();
            var response = SetAndExecute.RequestWithBody(BaseUrl, $"{ProjectsUrl}/{projectCode}/{suiteId}", Method.Patch, requestBody);

            Assert.That((int)response.StatusCode, Is.EqualTo(404));

            var modelResponse = JsonConvert.DeserializeObject<UpdateSuiteResponse>(response.Content);
            var jsonResponse = JObject.Parse(response.Content);
            Console.WriteLine("{0}", jsonResponse);

            Assert.That(modelResponse.Status, Is.False);
            Assert.That(modelResponse.ErrorMessage, Is.EqualTo("Suite not found"));
        }
    }
}
