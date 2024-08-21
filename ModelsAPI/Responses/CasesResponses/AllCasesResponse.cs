namespace ProjectVcode.ModelsAPI.Responses.CasesResponses
{
    internal class AllCasesResponse
    {
        public required bool Status { get; set; }
        public ResultObject Result { get; set; } = new ResultObject();
    }
    internal class ResultObject
    {
        public int total { get; set; }
        public EntitiesArray[] entities { get; set; } = Array.Empty<EntitiesArray>();
    }
    internal class EntitiesArray
    {
        public int id { get; set; }
        public string title { get; set; }
    }
}
