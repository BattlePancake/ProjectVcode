using ProjectVcode.ModelsAPI.Requests.CasesRequests;

namespace ProjectVcode.RequestBuilders.CasesBuilders
{
    internal class CreateCaseRequestBuilder
    {
        private readonly CreateCaseRequest _request;

        public CreateCaseRequestBuilder()
        {
            _request = new CreateCaseRequest();
        }

        public CreateCaseRequestBuilder Title(string title)
        {
            _request.Title = title;
            return this;
        }

        public CreateCaseRequest Build()
        {
            return _request;
        }
    }
}
