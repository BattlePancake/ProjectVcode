namespace ProjectVcode.ModelsAPI.Responses
{
    internal class GetCaseResponse
    {
        public required bool Status { get; set; }
        public ResultObject1 Result { get; set; } = new ResultObject1();

        public string ErrorMessage { get; set; }
    }
    internal class ResultObject1
    {
        public int id { get; set; }
        public string title { get; set; }
    }
}
