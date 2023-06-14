namespace DbHelper.DAL.Entities.Requests.ProjectRequests
{
    public class UpdateProjectRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CustomerName { get; set; }
        public string ExecutorName { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public int Priority { get; set; }
        public int OwnerId { get; set; }
    }
}
