namespace ProjectVcode.ModelsAPI.Responses
{
    internal class CreateCaseResponse
    {
        public required bool Status { get; set; }
        public ResultObject2 Result { get; set; } = new ResultObject2();

        public string ErrorMessage { get; set; }
    }

    internal class ResultObject2
    {
        public int id { get; set; }
    }
}
