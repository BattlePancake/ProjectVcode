namespace ProjectVcode.ModelsAPI.Responses.CasesResponses
{
    internal class UpdateCaseResponse
    {
        public required bool Status { get; set; }
        public ResultObject4 Result { get; set; } = new ResultObject4();

        public string ErrorMessage { get; set; }
    }

    internal class ResultObject4
    {
        public int id { get; set; }
    }
}
