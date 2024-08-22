using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using ProjectVcode.ModelsAPI.Responses.CasesResponses;
using ProjectVcode.RequestBuilders.CasesBuilders;
using ProjectVcode.API;
using NUnit.Allure.Core;

namespace ProjectVcode.TestsAPI
{
    [AllureNUnit]
    internal class CasesTestsAPI
    {
        private const string BaseUrl = "https://api.qase.io/v1/";
        private const string CasesUrl = "case/";

        [TestCase("TP")]
        [Description("Get All test cases - Positive")]
        public void GetAllCasesPositive(string projectCode)
        {   
            var response = SetAndExecute.Request(BaseUrl, $"{CasesUrl}{projectCode}", Method.Get);

            Assert.That((int)response.StatusCode, Is.EqualTo(200));

            var modelResponse = JsonConvert.DeserializeObject<AllCasesResponse>(response.Content);
            var jsonResponse = JObject.Parse(response.Content);

            Console.WriteLine("{0}", jsonResponse["result"]);

            Assert.That(modelResponse.Status, Is.True);
            Assert.That(modelResponse.Result.total, Is.EqualTo(2));
            Assert.That(modelResponse.Result.entities[1].id, Is.EqualTo(2));
            Assert.That(modelResponse.Result.entities[1].title, Is.EqualTo("Test2Test2Test2"));
        }

        [TestCase("TP", "APIcreatedCase1")]
        [Description("Create test case - Positive")]
        public void CreateCasePositive(string projectCode, string caseTitle)
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
        public void CreateCaseNegative(string projectCode, string caseTitle)
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

        [TestCase("TP", 1)]
        [Description("Get test case - Positive")]
        public void GetCasePositive(string projectCode, int testCaseId)
        {
            var response = SetAndExecute.Request(BaseUrl, $"{CasesUrl}{projectCode}/{testCaseId}", Method.Get);

            Assert.That((int)response.StatusCode, Is.EqualTo(200));

            var modelResponse = JsonConvert.DeserializeObject<GetCaseResponse>(response.Content);
            var jsonResponse = JObject.Parse(response.Content);

            Console.WriteLine("{0}", jsonResponse);

            Assert.That(modelResponse.Status, Is.True);
            Assert.That(modelResponse.Result.id, Is.EqualTo(testCaseId));
            Assert.That(modelResponse.Result.title, Is.EqualTo("TestTestTest"));
        }

        [TestCase("TP", 0)]
        [Description("Get test case - Negative")]
        public void GetCaseNegative(string projectCode, int testCaseId)
        {
            var response = SetAndExecute.Request(BaseUrl, $"{CasesUrl}{projectCode}/{testCaseId}", Method.Get);

            Assert.That((int)response.StatusCode, Is.EqualTo(404));

            var modelResponse = JsonConvert.DeserializeObject<GetCaseResponse>(response.Content);
            var jsonResponse = JObject.Parse(response.Content);

            Console.WriteLine("{0}", jsonResponse);
            Assert.That(modelResponse.Status, Is.False);
            Assert.That(modelResponse.ErrorMessage, Is.EqualTo("TestCase not found"));
        }

        [TestCase("TP", 22)]
        [Description("Delete test case - Positive")]
        public void DeleteCasePositive(string projectCode, int testCaseId)
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
        public void DeleteCaseNegative(string projectCode, int testCaseId)
        {
            var response = SetAndExecute.Request(BaseUrl, $"{CasesUrl}{projectCode}/{testCaseId}", Method.Delete);

            Assert.That((int)response.StatusCode, Is.EqualTo(404));

            var modelResponse = JsonConvert.DeserializeObject<DeleteCaseResponse>(response.Content);
            var jsonResponse = JObject.Parse(response.Content);

            Console.WriteLine("{0}", jsonResponse);
            Assert.That(modelResponse.Status, Is.False);
            Assert.That(modelResponse.ErrorMessage, Is.EqualTo("TestCase not found"));
        }

        [TestCase("TP", 1, "UpdatedTestCaseNameAPI")]
        [Description("Update test case - Positive")]
        public void UpdateCasePositive(string projectCode, int testCaseId, string caseTitle)
        {
            var requestBody = new UpdateCaseRequestBuilder()
                                    .Title($"{caseTitle}")
                                    .Build();
            var response = SetAndExecute.RequestWithBody(BaseUrl, $"{CasesUrl}{projectCode}/{testCaseId}", Method.Patch, requestBody);

            Assert.That((int)response.StatusCode, Is.EqualTo(200));

            var modelResponse = JsonConvert.DeserializeObject<UpdateCaseResponse>(response.Content);
            var jsonResponse = JObject.Parse(response.Content);

            Console.WriteLine("{0}", jsonResponse);
            Assert.That(modelResponse.Status, Is.True);
            Assert.That(modelResponse.Result.id, Is.EqualTo(testCaseId));
        }

        [TestCase("TP", 99, "UpdatedTestCaseNameAPI")]
        [Description("Update test case - Negative")]
        public void UpdateCaseNegative(string projectCode, int testCaseId, string caseTitle)
        {
            var requestBody = new UpdateCaseRequestBuilder()
                                    .Title($"{caseTitle}")
                                    .Build();
            var response = SetAndExecute.RequestWithBody(BaseUrl, $"{CasesUrl}{projectCode}/{testCaseId}", Method.Patch, requestBody);

            Assert.That((int)response.StatusCode, Is.EqualTo(404));

            var modelResponse = JsonConvert.DeserializeObject<UpdateCaseResponse>(response.Content);
            var jsonResponse = JObject.Parse(response.Content);

            Console.WriteLine("{0}", jsonResponse);
            Assert.That(modelResponse.Status, Is.False);
            Assert.That(modelResponse.ErrorMessage, Is.EqualTo("TestCase not found"));
        }
    }
}
