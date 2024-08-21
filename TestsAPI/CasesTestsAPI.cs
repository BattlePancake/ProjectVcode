using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjectVcode.Builders;
using ProjectVcode.ModelsAPI.Responses;
using ProjectVcode.API;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace ProjectVcode.TestsAPI
{
    internal class CasesTestsAPI
    {
        private const string BaseUrl = "https://api.qase.io/v1/";
        private const string CasesUrl = "case/";

        [TestCase("TP")]
        [Description("Get All test cases - Positive")]
        public void GetAllTestCasesPositive(string projectCode)
        {   
            var response = SetAndExecute.Request(BaseUrl, $"{CasesUrl}{projectCode}", Method.Get);

            Assert.That((int)response.StatusCode, Is.EqualTo(200));

            var modelResponse = JsonConvert.DeserializeObject<AllCasesResponse>(response.Content);
            var jsonResponse = JObject.Parse(response.Content);

            Console.WriteLine("{0}", jsonResponse["result"]);

            Assert.That(modelResponse.Status, Is.True);
            Assert.That(modelResponse.Result.total, Is.EqualTo(5));
            Assert.That(modelResponse.Result.entities[1].id, Is.EqualTo(2));
            Assert.That(modelResponse.Result.entities[1].title, Is.EqualTo("Test2Test2Test2"));
        }

        [TestCase("TP", "APITestCase2")]
        [Description("Create test case - Positive")]
        public void CreateTestCasePositive(string projectCode, string caseTitle)
        {
            var requestBody = new CreateCaseRequestBuilder()
                                    .Title($"{caseTitle}")
                                    .Build();
            var response = SetAndExecute.RequestWithBody(BaseUrl, $"{CasesUrl}{projectCode}", Method.Post, requestBody);

            Assert.That((int)response.StatusCode, Is.EqualTo(200));

            var modelResponse = JsonConvert.DeserializeObject<CreateCaseResponse>(response.Content);
            var jsonResponse = JObject.Parse(response.Content);

            Console.WriteLine("{0}", jsonResponse);
            Assert.That(modelResponse.Status, Is.True);
        }

        [TestCase("TPPPPP1", "APITestCase1")]
        [Description("Create test case - Negative")]
        public void CreateTestCaseNegative(string projectCode, string caseTitle)
        {
            var requestBody = new CreateCaseRequestBuilder()
                                    .Title($"{caseTitle}")
                                    .Build();
            var response = SetAndExecute.RequestWithBody(BaseUrl, $"{CasesUrl}{projectCode}", Method.Post, requestBody);

            Assert.That((int)response.StatusCode, Is.EqualTo(404));

            var modelResponse = JsonConvert.DeserializeObject<CreateCaseResponse>(response.Content);
            var jsonResponse = JObject.Parse(response.Content);

            Console.WriteLine("{0}", jsonResponse);
            Assert.That(modelResponse.Status, Is.False);
            Assert.That(modelResponse.ErrorMessage, Is.EqualTo("Project not found"));
        }

        [TestCase("TP", 7)]
        [Description("Get test case - Positive")]
        public void GetTestCasePositive(string projectCode, int testCaseId)
        {
            var response = SetAndExecute.Request(BaseUrl, $"{CasesUrl}{projectCode}/{testCaseId}", Method.Get);

            Assert.That((int)response.StatusCode, Is.EqualTo(200));

            var modelResponse = JsonConvert.DeserializeObject<GetCaseResponse>(response.Content);
            var jsonResponse = JObject.Parse(response.Content);

            Console.WriteLine("{0}", jsonResponse);

            Assert.That(modelResponse.Status, Is.True);
            Assert.That(modelResponse.Result.id, Is.EqualTo(testCaseId));
            Assert.That(modelResponse.Result.title, Is.EqualTo("APITestCaseAPI"));
        }

        [TestCase("TP", 0)]
        [Description("Get test case - Negative")]
        public void GetTestCaseNegative(string projectCode, int testCaseId)
        {
            var response = SetAndExecute.Request(BaseUrl, $"{CasesUrl}{projectCode}/{testCaseId}", Method.Get);

            Assert.That((int)response.StatusCode, Is.EqualTo(404));

            var modelResponse = JsonConvert.DeserializeObject<GetCaseResponse>(response.Content);
            var jsonResponse = JObject.Parse(response.Content);

            Console.WriteLine("{0}", jsonResponse);
            Assert.That(modelResponse.Status, Is.False);
            Assert.That(modelResponse.ErrorMessage, Is.EqualTo("TestCase not found"));
        }

        [TestCase("TP", 10)]
        [Description("Delete test case - Positive")]
        public void DeleteTestCasePositive(string projectCode, int testCaseId)
        {
            var response = SetAndExecute.Request(BaseUrl, $"{CasesUrl}{projectCode}/{testCaseId}", Method.Delete);

            Assert.That((int)response.StatusCode, Is.EqualTo(200));

            var modelResponse = JsonConvert.DeserializeObject<DeleteCaseResponse>(response.Content);
            var jsonResponse = JObject.Parse(response.Content);

            Console.WriteLine("{0}", jsonResponse);
            Assert.That(modelResponse.Status, Is.True);
            Assert.That(modelResponse.Result.id, Is.EqualTo(testCaseId));
        }

        [TestCase("TP", 10)]
        [Description("Delete test case - Negative")]
        public void DeleteTestCaseNegative(string projectCode, int testCaseId)
        {
            var response = SetAndExecute.Request(BaseUrl, $"{CasesUrl}{projectCode}/{testCaseId}", Method.Delete);

            Assert.That((int)response.StatusCode, Is.EqualTo(404));

            var modelResponse = JsonConvert.DeserializeObject<DeleteCaseResponse>(response.Content);
            var jsonResponse = JObject.Parse(response.Content);

            Console.WriteLine("{0}", jsonResponse);
            Assert.That(modelResponse.Status, Is.False);
            Assert.That(modelResponse.ErrorMessage, Is.EqualTo("TestCase not found"));
        }

        [TestCase("TP", 11, "UpdatedTestCaseNameAPI")]
        [Description("Update test case - Positive")]
        public void UpdateTestCasePositive(string projectCode, int testCaseId, string caseTitle)
        {
            var requestBody = new UpdateCaseRequestBuilder()
                                    .Title($"{caseTitle}")
                                    .Build();
            var response = SetAndExecute.RequestWithBody(BaseUrl, $"{CasesUrl}{projectCode}/{testCaseId}", Method.Patch, requestBody);

            Assert.That((int)response.StatusCode, Is.EqualTo(200));

            var modelResponse = JsonConvert.DeserializeObject<DeleteCaseResponse>(response.Content);
            var jsonResponse = JObject.Parse(response.Content);

            Console.WriteLine("{0}", jsonResponse);
            Assert.That(modelResponse.Status, Is.True);
            Assert.That(modelResponse.Result.id, Is.EqualTo(testCaseId));
        }

        [TestCase("TP", 99, "UpdatedTestCaseNameAPI")]
        [Description("Update test case - Negative")]
        public void UpdateTestCaseNegative(string projectCode, int testCaseId, string caseTitle)
        {
            var requestBody = new UpdateCaseRequestBuilder()
                                    .Title($"{caseTitle}")
                                    .Build();
            var response = SetAndExecute.RequestWithBody(BaseUrl, $"{CasesUrl}{projectCode}/{testCaseId}", Method.Patch, requestBody);

            Assert.That((int)response.StatusCode, Is.EqualTo(404));

            var modelResponse = JsonConvert.DeserializeObject<DeleteCaseResponse>(response.Content);
            var jsonResponse = JObject.Parse(response.Content);

            Console.WriteLine("{0}", jsonResponse);
            Assert.That(modelResponse.Status, Is.False);
            Assert.That(modelResponse.ErrorMessage, Is.EqualTo("TestCase not found"));
        }
    }
}
