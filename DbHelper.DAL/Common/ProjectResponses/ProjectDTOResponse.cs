using DbHelper.DAL.Entities.DTOs;

namespace DbHelper.DAL.Common.ProjectResponses
{
    public class ProjectDTOResponse : Response
    {
        public ProjectDTO ProjectDTO { get; set; }
        public ProjectDTOResponse(int statusCode, bool success, string message, ProjectDTO projectDTO) : base(statusCode, success, message)
        {
            ProjectDTO = projectDTO;
        }
    }
}
