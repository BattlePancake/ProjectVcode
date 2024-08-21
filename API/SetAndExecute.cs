using ProjectVcode.Constants;
using ProjectVcode.ModelsAPI.Requests;
using RestSharp;

namespace ProjectVcode.API
{
    internal class SetAndExecute
    {
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
    }
}
