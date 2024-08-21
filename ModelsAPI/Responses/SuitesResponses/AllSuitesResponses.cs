namespace ProjectVcode.ModelsAPI.Responses.SuitesResponses
{
    internal class AllSuitesResponse
    {
        public required bool Status { get; set; }
        public ResultObject9 Result { get; set; } = new ResultObject9();
    }
    internal class ResultObject9
    {
        public int total { get; set; }
        public EntitiesArray2[] entities { get; set; } = Array.Empty<EntitiesArray2>();
    }
    internal class EntitiesArray2
    {
        public int id { get; set; }
        public string title { get; set; }
        public int cases_count { get; set; }
    }
}
