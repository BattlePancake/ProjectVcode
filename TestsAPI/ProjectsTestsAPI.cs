using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjectVcode.ModelsAPI.Responses.ProjectsResponses;
using ProjectVcode.RequestBuilders.ProjectsBuilders;
using ProjectVcode.API;
using NUnit.Allure.Core;

namespace ProjectVcode.TestsAPI
{
    [AllureNUnit]
    internal class ProjectsTestsAPI
    {
        private const string BaseUrl = "https://api.qase.io/v1/";
        private const string ProjectsUrl = "project";

        [Test, Order(1)]
        [Description("Get All projects - Positive")]
        public void GetAllProjectsPositive()
        {
            var response = SetAndExecute.Request(BaseUrl, $"{ProjectsUrl}", Method.Get);

            Assert.That((int)response.StatusCode, Is.EqualTo(200));

            var modelResponse = JsonConvert.DeserializeObject<AllProjectsResponse>(response.Content);
            var jsonResponse = JObject.Parse(response.Content);
            Console.WriteLine("{0}", jsonResponse);

            Assert.That(modelResponse.Status, Is.True);
            Assert.That(modelResponse.Result.total, Is.EqualTo(2));
            Assert.That(modelResponse.Result.entities[0].title, Is.EqualTo("Demo Project"));
            Assert.That(modelResponse.Result.entities[0].code, Is.EqualTo("DEMO"));
            Assert.That(modelResponse.Result.entities[0].counts.cases, Is.EqualTo(10));
            Assert.That(modelResponse.Result.entities[0].counts.suites, Is.EqualTo(3));
        }

        [TestCase("NewAPIProject", "NAP", ""), Order(2)]
        [Description("Create project - Positive")]
        public void CreateProjectPositive(string projectTitle, string projectCode, string description)
        {
            var requestBody = new CreateProjectRequestBuilder()
                                    .Title(projectTitle)
                                    .Code(projectCode)
                                    .Build();
            var response = SetAndExecute.RequestWithBody(BaseUrl, $"{ProjectsUrl}", Method.Post, requestBody);

            Assert.That((int)response.StatusCode, Is.EqualTo(200));

            var modelResponse = JsonConvert.DeserializeObject<CreateProjectResponse>(response.Content);
            var jsonResponse = JObject.Parse(response.Content);
            Console.WriteLine("{0}", jsonResponse);

            Assert.That(modelResponse.Status, Is.True);
            Assert.That(modelResponse.Result.code, Is.EqualTo(projectCode));
        }

        [TestCase("NewAPIProject", "1"), Order(3)]
        [Description("Create project - Negative")]
        public void CreateProjectNegative(string projectTitle, string projectCode)
        {
            var requestBody = new CreateProjectRequestBuilder()
                                    .Title(projectTitle)
                                    .Code(projectCode)
                                    .Build();
            var response = SetAndExecute.RequestWithBody(BaseUrl, $"{ProjectsUrl}", Method.Post, requestBody);

            Assert.That((int)response.StatusCode, Is.EqualTo(400));

            var modelResponse = JsonConvert.DeserializeObject<CreateProjectResponse>(response.Content);
            var jsonResponse = JObject.Parse(response.Content);
            Console.WriteLine("{0}", jsonResponse);

            Assert.That(modelResponse.Status, Is.False);
            Assert.That(modelResponse.ErrorMessage, Is.EqualTo("Data is invalid."));
        }

        [TestCase("TP"), Order(4)]
        [Description("Get project - Positive")]
        public void GetProjectPositive(string projectCode)
        {
            var response = SetAndExecute.Request(BaseUrl, $"{ProjectsUrl}/{projectCode}", Method.Get);

            Assert.That((int)response.StatusCode, Is.EqualTo(200));

            var modelResponse = JsonConvert.DeserializeObject<GetProjectResponse>(response.Content);
            var jsonResponse = JObject.Parse(response.Content);
            Console.WriteLine("{0}", jsonResponse);

            Assert.That(modelResponse.Status, Is.True);
            Assert.That(modelResponse.Result.title, Is.EqualTo("TestProject"));
            Assert.That(modelResponse.Result.code, Is.EqualTo(projectCode));
            Assert.That(modelResponse.Result.counts.cases, Is.EqualTo(2));
            Assert.That(modelResponse.Result.counts.suites, Is.EqualTo(0));
        }

        [TestCase("2"), Order(5)]
        [Description("Get project - Negative")]
        public void GetProjectNegative(string projectCode)
        {
            var response = SetAndExecute.Request(BaseUrl, $"{ProjectsUrl}/{projectCode}", Method.Get);

            Assert.That((int)response.StatusCode, Is.EqualTo(404));

            var modelResponse = JsonConvert.DeserializeObject<GetProjectResponse>(response.Content);
            var jsonResponse = JObject.Parse(response.Content);
            Console.WriteLine("{0}", jsonResponse);

            Assert.That(modelResponse.Status, Is.False);
            Assert.That(modelResponse.ErrorMessage, Is.EqualTo("Project not found"));
        }

        [TestCase("NAP"), Order(6)]
        [Description("Delete project - Positive")]
        public void DeleteProjectPositive(string projectCode)
        {
            var response = SetAndExecute.Request(BaseUrl, $"{ProjectsUrl}/{projectCode}", Method.Delete);

            Assert.That((int)response.StatusCode, Is.EqualTo(200));

            var modelResponse = JsonConvert.DeserializeObject<DeleteProjectResponse>(response.Content);
            var jsonResponse = JObject.Parse(response.Content);
            Console.WriteLine("{0}", jsonResponse);

            Assert.That(modelResponse.Status, Is.True);
        }

        [TestCase("1"), Order(7)]
        [Description("Delete project - Negative")]
        public void DeleteProjectNegative(string projectCode)
        {
            var response = SetAndExecute.Request(BaseUrl, $"{ProjectsUrl}/{projectCode}", Method.Delete);

            Assert.That((int)response.StatusCode, Is.EqualTo(404));

            var modelResponse = JsonConvert.DeserializeObject<DeleteProjectResponse>(response.Content);
            var jsonResponse = JObject.Parse(response.Content);
            Console.WriteLine("{0}", jsonResponse);

            Assert.That(modelResponse.Status, Is.False);
            Assert.That(modelResponse.ErrorMessage, Is.EqualTo("Project not found"));
        }
    }
}
