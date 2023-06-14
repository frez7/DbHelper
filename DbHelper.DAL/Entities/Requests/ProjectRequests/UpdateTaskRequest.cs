namespace DbHelper.DAL.Entities.Requests.ProjectRequests
{
    public class UpdateTaskRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProjectId { get; set; }
        public int ExecutorId { get; set; }
        public string Comment { get; set; }
        public int Status { get; set; }
        public int Priority { get; set; }
    }
}
