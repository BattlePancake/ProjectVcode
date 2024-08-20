namespace ProjectVcode.Models
{
    internal class Project
    {
        public string ProjectName { get; set; }
        public string ProjectCode { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }

        public Project(string projectName, string projectCode, string description)
        {
            ProjectName = projectName;
            ProjectCode = projectCode;
            Description = description;
        }

        public Project(string projectName, string projectCode)
        {
            ProjectName = projectName;
            ProjectCode = projectCode;
        }

        public Project(string projectName)
        {
            ProjectName = projectName;
        }

        public Project(string projectName, int projectId)
        {
            ProjectName = projectName;
            ProjectId = projectId;
        }
    }
}
