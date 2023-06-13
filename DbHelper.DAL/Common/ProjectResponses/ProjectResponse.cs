namespace DbHelper.DAL.Common.ProjectResponses
{
    public class ProjectResponse : Response
    {
        public int ProjectId { get; set; }
        public ProjectResponse(int statusCode, bool success, string message, int projectId) : base(statusCode, success, message)
        {
            ProjectId = projectId;
        }
    }
}
