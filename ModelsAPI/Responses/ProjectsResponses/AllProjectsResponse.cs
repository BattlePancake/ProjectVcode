namespace ProjectVcode.ModelsAPI.Responses.ProjectsResponses
{
    internal class AllProjectsResponse
    {
        public required bool Status { get; set; }
        public ResultObject5 Result { get; set; } = new ResultObject5();
    }
    internal class ResultObject5
    {
        public int total { get; set; }
        public EntitiesArray1[] entities { get; set; } = Array.Empty<EntitiesArray1>();
    }
    internal class EntitiesArray1
    {
        public string title { get; set; }
        public string code { get; set; }
        public CountsObject counts { get; set; } = new CountsObject();
    }
    internal class CountsObject
    {
        public int cases { get; set; }
        public int suites { get; set; }
    }
}
