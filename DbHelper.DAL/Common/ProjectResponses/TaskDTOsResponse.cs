using DbHelper.DAL.Entities.DTOs;

namespace DbHelper.DAL.Common.ProjectResponses
{

    public class TaskDTOsResponse : Response
    {
        public List<TaskDTO> TaskDTOs { get; set; }
        public TaskDTOsResponse(int statusCode, bool success, string message, List<TaskDTO> taskDTOs) : base(statusCode, success, message)
        {
            TaskDTOs = taskDTOs;
        }
    }
}
