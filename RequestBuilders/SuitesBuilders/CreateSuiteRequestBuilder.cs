using ProjectVcode.ModelsAPI.Requests.SuitesRequests;

namespace ProjectVcode.RequestBuilders.SuitesBuilders
{
    internal class CreateSuiteRequestBuilder
    {
        private readonly CreateSuiteRequest _request;

        public CreateSuiteRequestBuilder()
        {
            _request = new CreateSuiteRequest();
        }

        public CreateSuiteRequestBuilder Title(string title)
        {
            _request.Title = title;
            return this;
        }
        public CreateSuiteRequestBuilder Description(string description)
        {
            _request.Description = description;
            return this;
        }

        public CreateSuiteRequest Build()
        {
            return _request;
        }
    }
}
