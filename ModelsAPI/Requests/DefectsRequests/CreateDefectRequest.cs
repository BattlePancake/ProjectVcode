namespace ProjectVcode.ModelsAPI.Requests.DefectsRequests
{
    internal class CreateDefectRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Actual_result { get; set; } = string.Empty;
        public int? Severity { get; set; } = null;
    }
}
