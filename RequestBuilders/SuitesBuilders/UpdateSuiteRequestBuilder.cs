using ProjectVcode.ModelsAPI.Requests.SuitesRequests;

namespace ProjectVcode.RequestBuilders.SuitesBuilders
{
    internal class UpdateSuiteRequestBuilder
    {
        private readonly UpdateSuiteRequest _request;

        public UpdateSuiteRequestBuilder()
        {
            _request = new UpdateSuiteRequest();
        }

        public UpdateSuiteRequestBuilder Title(string title)
        {
            _request.Title = title;
            return this;
        }
        public UpdateSuiteRequestBuilder Description(string description)
        {
            _request.Description = description;
            return this;
        }

        public UpdateSuiteRequest Build()
        {
            return _request;
        }
    }
}
