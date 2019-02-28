using System.Collections.Generic;
using System.Data.SqlClient;
using Taskly.App.JIra.Models;
using Taskly.Infrastructure.CQRS.Abstractions.Queries;

namespace Taskly.App.JIra.Queries
{
    public class GetJiraIssuesFromMsSqlCriterion : ICriterion<JiraIssue[]>
    {
        public string DataSource { get; }
        public string UserID { get; }
        public string Password { get; }
        public string InitialCatalog { get; }

        public GetJiraIssuesFromMsSqlCriterion(string dataSource, string userID, string password, string initialCatalog)
        {
            DataSource = dataSource;
            UserID = userID;
            Password = password;
            InitialCatalog = initialCatalog;
        }
    }

    public class GetJiraIssuesFromMsSqlQuery : IQuery<GetJiraIssuesFromMsSqlCriterion, JiraIssue[]>
    {
        public JiraIssue[] Ask(GetJiraIssuesFromMsSqlCriterion criterion)
        {
            var res = new List<JiraIssue>();

            var builder = new SqlConnectionStringBuilder
            {
                DataSource = criterion.DataSource,
                UserID = criterion.UserID,
                Password = criterion.Password,
                InitialCatalog = criterion.InitialCatalog
            };

            using (var connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                var sql = "SELECT * FROM jiraissue";

                using (var command = new SqlCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            res.Add(
                                new JiraIssue(
                                    int.Parse(reader["ID"].ToString()),
                                    reader["SUMMARY"].ToString(),
                                    reader["DESCRIPTION"].ToString(),
                                    int.Parse(reader["ISSUENUM"].ToString()),
                                    int.Parse(reader["PROJECT"].ToString()),
                                    reader["CREATOR"].ToString(),
                                    reader["ASSIGNEE"].ToString(),
                                    reader["ISSUETYPE"].ToString(),
                                    int.Parse(reader["PRIORITY"].ToString()),
                                    reader["CREATED"].ToString(),
                                    reader["UPDATED"].ToString(), 
                                    reader["RESOLUTIONDATE"].ToString(),
                                    reader["TIMEORIGINALESTIMATE"].ToString()
                            ));
                        }
                    }
                }
            }


            return res.ToArray();
        }
    }
}