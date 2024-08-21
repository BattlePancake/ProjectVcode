namespace ProjectVcode.ModelsAPI.Responses.ProjectsResponses
{
    internal class CreateProjectResponse
    {
        public required bool Status { get; set; }
        public ResultObject6 Result { get; set; } = new ResultObject6();

        public string ErrorMessage { get; set; }
    }
    internal class ResultObject6
    {
        public string code { get; set; }
    }
}
