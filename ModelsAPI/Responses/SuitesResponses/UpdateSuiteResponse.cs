namespace ProjectVcode.ModelsAPI.Responses.SuitesResponses
{
    internal class UpdateSuiteResponse
    {
        public required bool Status { get; set; }
        public ResultObject13 Result { get; set; } = new ResultObject13();

        public string ErrorMessage { get; set; }
    }
    internal class ResultObject13
    {
        public int id { get; set; }
    }
}
