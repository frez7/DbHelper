using DbHelper.DAL.Entities.DTOs;

namespace DbHelper.DAL.Common.ProjectResponses
{
    public class TaskDTOResponse : Response
    {
        public TaskDTO TaskDTO { get; set; }
        public TaskDTOResponse(int statusCode, bool success, string message, TaskDTO taskDTO) : base(statusCode, success, message)
        {
            TaskDTO = taskDTO;
        }
    }
}
