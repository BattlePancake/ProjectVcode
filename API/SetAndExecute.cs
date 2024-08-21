using RestSharp;
using ProjectVcode.Constants;
using ProjectVcode.ModelsAPI.Requests.ProjectsRequests;
using ProjectVcode.ModelsAPI.Requests.CasesRequests;
using ProjectVcode.ModelsAPI.Requests.SuitesRequests;
using ProjectVcode.ModelsAPI.Requests.DefectsRequests;

namespace ProjectVcode.API
{
    internal class SetAndExecute
    {
        //----------------- Cases ----------------------------
        public static RestResponse Request(string baseUrl, string? resource, Method method)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest($"{resource}", method);
            request.AddHeader("Token", Consts.AuthToken);
            var response = client.Execute(request);
            Console.WriteLine("Status code: {0}", (int)response.StatusCode);
            return response;
        }

        //var client = new RestClient(BaseUrl);
        //var request = new RestRequest($"case/{projectCode}", Method.Get);
        //request.AddHeader("Token", Consts.AuthToken);
        //var response = client.Execute(request);
        //Console.WriteLine("Status code: {0}", (int)response.StatusCode);

        public static RestResponse RequestWithBody(string baseUrl, string? resource, Method method, CreateCaseRequest requestBody)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest($"{resource}", method);
            request.AddHeader("Token", Consts.AuthToken);
            request.AddJsonBody(requestBody);
            var response = client.Execute(request);
            Console.WriteLine("Status code: {0}", (int)response.StatusCode);
            return response;
        }

        //var client = new RestClient(BaseUrl);
        //var request = new RestRequest($"{CreateCaseUrl}{projectCode}", Method.Post);
        //request.AddHeader("Token", Consts.AuthToken);

        //var casesRequestBody = new CreateCaseRequestBuilder()
        //                            .Title($"{caseTitle}")
        //                            .Build();
        //request.AddJsonBody(casesRequestBody);
        //var response = client.Execute(request);

        public static RestResponse RequestWithBody(string baseUrl, string? resource, Method method, UpdateCaseRequest requestBody)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest($"{resource}", method);
            request.AddHeader("Token", Consts.AuthToken);
            request.AddJsonBody(requestBody);
            var response = client.Execute(request);
            Console.WriteLine("Status code: {0}", (int)response.StatusCode);
            return response;
        }


        //----------------- Projects ----------------------------
        public static RestResponse RequestWithBody(string baseUrl, string? resource, Method method, CreateProjectRequest requestBody)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest($"{resource}", method);
            request.AddHeader("Token", Consts.AuthToken);
            request.AddJsonBody(requestBody);
            var response = client.Execute(request);
            Console.WriteLine("Status code: {0}", (int)response.StatusCode);
            return response;
        }


        //----------------- Suites ----------------------------
        public static RestResponse RequestWithBody(string baseUrl, string? resource, Method method, CreateSuiteRequest requestBody)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest($"{resource}", method);
            request.AddHeader("Token", Consts.AuthToken);
            request.AddJsonBody(requestBody);
            var response = client.Execute(request);
            Console.WriteLine("Status code: {0}", (int)response.StatusCode);
            return response;
        }

        public static RestResponse RequestWithBody(string baseUrl, string? resource, Method method, UpdateSuiteRequest requestBody)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest($"{resource}", method);
            request.AddHeader("Token", Consts.AuthToken);
            request.AddJsonBody(requestBody);
            var response = client.Execute(request);
            Console.WriteLine("Status code: {0}", (int)response.StatusCode);
            return response;
        }


        //----------------- Defects ----------------------------
        public static RestResponse RequestWithBody(string baseUrl, string? resource, Method method, CreateDefectRequest requestBody)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest($"{resource}", method);
            request.AddHeader("Token", Consts.AuthToken);
            request.AddJsonBody(requestBody);
            var response = client.Execute(request);
            Console.WriteLine("Status code: {0}", (int)response.StatusCode);
            return response;
        }
    }
}
