namespace ProjectVcode.ModelsAPI.Responses.CasesResponses
{
    internal class DeleteCaseResponse
    {
        public required bool Status { get; set; }
        public ResultObject3 Result { get; set; } = new ResultObject3();

        public string ErrorMessage { get; set; }
    }

    internal class ResultObject3
    {
        public int id { get; set; }
    }
}
