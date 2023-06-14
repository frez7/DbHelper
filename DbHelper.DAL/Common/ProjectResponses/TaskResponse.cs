namespace DbHelper.DAL.Common.ProjectResponses
{
    public class TaskResponse : Response
    {
        public int TaskId { get; set; }
        public TaskResponse(int statusCode, bool success, string message, int taskId) : base(statusCode, success, message)
        {
            TaskId = taskId;
        }
    }
}
