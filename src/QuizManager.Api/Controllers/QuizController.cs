using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizManager.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuizController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetQuizzes(Guid organisationId)
        {
            return Ok();
        }
    }
}
