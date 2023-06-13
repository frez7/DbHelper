using DbHelper.DAL.Entities.DTOs;

namespace DbHelper.DAL.Common.ProjectResponses
{
    public class ProjectDTOsResponse : Response
    {
        public List<ProjectDTO> ProjectDTOs { get; set; }
        public ProjectDTOsResponse(int statusCode, bool success, string message, List<ProjectDTO> projectDTOs) : base(statusCode, success, message)
        {
            ProjectDTOs = projectDTOs;
        }
    }
}
