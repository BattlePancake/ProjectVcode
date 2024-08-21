namespace ProjectVcode.ModelsAPI.Responses.ProjectsResponses
{
    internal class GetProjectResponse
    {
        public required bool Status { get; set; }
        public ResultObject7 Result { get; set; } = new ResultObject7();

        public string ErrorMessage { get; set; }
    }
    internal class ResultObject7
    {
        public string title { get; set; }
        public string code { get; set; }
        public CountsObject1 counts { get; set; } = new CountsObject1();
    }
    internal class CountsObject1
    {
        public int cases { get; set; }
        public int suites { get; set; }
    }
}
