namespace Taskly.App.JIra.Models
{
    public class JiraIssue
    {
        public int Id { get; }
        public string Summary { get; }
        public string Description { get; }
        public int IssueNum { get; }
        public int ProjectId { get; }
        public string Creator { get; }
        public string Assignee { get; }
        public string IssueType { get; } //todo
        public int Priority { get; } // todo
        public string Created { get; }
        public string Updated { get; }
        public string ResolutionDate { get; }
        public string TimeOriginalEstimate { get; }

        public JiraIssue(int id, string summary, string description, int issueNum, int projectId, string creator, string assignee, string issueType, int priority, string created, string updated, string resolutionDate, string timeOriginalEstimate)
        {
            Id = id;
            Summary = summary;
            Description = description;
            IssueNum = issueNum;
            ProjectId = projectId;
            Creator = creator;
            Assignee = assignee;
            IssueType = issueType;
            Priority = priority;
            Created = created;
            Updated = updated;
            ResolutionDate = resolutionDate;
            TimeOriginalEstimate = timeOriginalEstimate;
        }
    }
}