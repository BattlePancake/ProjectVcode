using ProjectVcode.ModelsAPI.Requests.DefectsRequests;

namespace ProjectVcode.RequestBuilders.DefectsBuilders
{
    internal class CreateDefectRequestBuilder
    {
        private readonly CreateDefectRequest _request;

        public CreateDefectRequestBuilder()
        {
            _request = new CreateDefectRequest();
        }

        public CreateDefectRequestBuilder Title(string title)
        {
            _request.Title = title;
            return this;
        }

        public CreateDefectRequestBuilder Actual_result(string actual_result)
        {
            _request.Actual_result = actual_result;
            return this;
        }
        public CreateDefectRequestBuilder Severity(int severity)
        {
            _request.Severity = severity;
            return this;
        }

        public CreateDefectRequest Build()
        {
            return _request;
        }
    }
}
