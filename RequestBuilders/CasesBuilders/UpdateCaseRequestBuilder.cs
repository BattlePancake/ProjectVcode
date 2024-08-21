using ProjectVcode.ModelsAPI.Requests.CasesRequests;

namespace ProjectVcode.RequestBuilders.CasesBuilders
{
    internal class UpdateCaseRequestBuilder
    {
        private readonly UpdateCaseRequest _request;

        public UpdateCaseRequestBuilder()
        {
            _request = new UpdateCaseRequest();
        }

        public UpdateCaseRequestBuilder Title(string title)
        {
            _request.Title = title;
            return this;
        }

        public UpdateCaseRequest Build()
        {
            return _request;
        }
    }
}
