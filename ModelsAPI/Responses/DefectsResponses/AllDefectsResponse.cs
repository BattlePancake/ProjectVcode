
namespace ProjectVcode.ModelsAPI.Responses.DefectsResponse
{
    internal class AllDefectsResponse
    {
        public required bool Status { get; set; }
        public ResultObject14 Result { get; set; } = new ResultObject14();
    }
    internal class ResultObject14
    {
        public int total { get; set; }
        public EntitiesArray4[] entities { get; set; } = Array.Empty<EntitiesArray4>();
    }
    internal class EntitiesArray4
    {
        public int id { get; set; }
        public string title { get; set; }
        public string actual_result { get; set; }
        public string status { get; set; }
        public string severity { get; set; }
        public DateTime created { get; set; }
    }
}
