namespace ProjectVcode.ModelsAPI.Responses.SuitesResponses
{
    internal class GetSuiteResponse
    {
        public required bool Status { get; set; }
        public ResultObject11 Result { get; set; } = new ResultObject11();

        public string ErrorMessage { get; set; }
    }
    internal class ResultObject11
    {
        public int id { get; set; }
        public int total { get; set; }
        public string title { get; set; }
        public int cases_count { get; set; }
    }
}
