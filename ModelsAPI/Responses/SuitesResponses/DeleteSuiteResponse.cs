namespace ProjectVcode.ModelsAPI.Responses.SuitesResponses
{
    internal class DeleteSuiteResponse
    {
        public required bool Status { get; set; }
        public ResultObject12 Result { get; set; } = new ResultObject12();

        public string ErrorMessage { get; set; }
    }
    internal class ResultObject12
    {
        public int id { get; set; }
    }
}
