using ProjectVcode.ModelsAPI.Requests.ProjectsRequests;

namespace ProjectVcode.RequestBuilders.ProjectsBuilders
{
    internal class CreateProjectRequestBuilder
    {
        private readonly CreateProjectRequest _request;

        public CreateProjectRequestBuilder()
        {
            _request = new CreateProjectRequest();
        }

        public CreateProjectRequestBuilder Title(string title)
        {
            _request.Title = title;
            return this;
        }
        public CreateProjectRequestBuilder Code(string code)
        {
            _request.Code = code;
            return this;
        }

        public CreateProjectRequest Build()
        {
            return _request;
        }
    }
}
