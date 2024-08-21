namespace ProjectVcode.ModelsAPI.Responses.SuitesResponses
{
    internal class CreateSuiteResponse
    {
        public required bool Status { get; set; }
        public ResultObject10 Result { get; set; } = new ResultObject10();

        public string ErrorMessage { get; set; }
    }
    internal class ResultObject10
    {
        public int id { get; set; }
    }
}
