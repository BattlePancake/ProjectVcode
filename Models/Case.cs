namespace ProjectVcode.Models
{
    internal class Case
    {
        public string CaseName { get; set; }
        public int CaseId { get; set; }

        public Case(string caseName, int caseId)
        {
            CaseName = caseName;
            CaseId = caseId;
        }
    }
}
