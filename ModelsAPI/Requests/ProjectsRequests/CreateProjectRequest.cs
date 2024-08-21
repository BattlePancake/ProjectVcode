namespace ProjectVcode.ModelsAPI.Requests.ProjectsRequests
{
    internal class CreateProjectRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
