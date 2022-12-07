using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingAPI.IServices;

namespace TrainingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICoursesService _course;

        public CoursesController(ICoursesService course)
        {
            _course = course;
        }

        [HttpGet(Name = "GetCoursesAll")]
        public async Task<IReadOnlyList<Training.Domain.Entities.Course>> Get()
        {
            return await _course.GetAll();
        }
    }
}
