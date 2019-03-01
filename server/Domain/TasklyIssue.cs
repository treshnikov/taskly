namespace Taskly.Domain
{
    public class TasklyIssue
    {
        public int Id { get; }
        public string Summary { get; }
        public string Description { get; }
        public int ProjectId { get; }
        public int IssueNum { get; }

        public TasklyIssue(int id, string summary, string description, int projectId, int issueNum)
        {
            Id = id;
            Summary = summary;
            Description = description;
            ProjectId = projectId;
            IssueNum = issueNum;
        }
    }
}