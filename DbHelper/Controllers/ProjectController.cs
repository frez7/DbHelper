using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DbHelper.WebApi.Controllers
{

    [ApiController]
    [Authorize]
    [Route("api/project")]
    public class ProjectController
    {
    }
}
