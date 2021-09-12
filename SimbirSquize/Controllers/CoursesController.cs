using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimbirSquize.Data.Testing;
using SimbirSquize.Services.Courses;

namespace SimbirSquize.Controllers
{
    [ApiController]
    [Route("/api/v1/courses")]
    public class CoursesController : AbstractController
    {
        private ICoursesService _coursesService;

        public CoursesController(ICoursesService coursesService)
        {
            _coursesService = coursesService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var courses = await _coursesService.GetAllCourses();
            return Ok(WrapToResponse(courses));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var course = await _coursesService.GetCourseById(id);

            return Ok(WrapToResponse(course));
        }

        [HttpPost()]
        public IActionResult CreateCourse([FromBody] Course course)
        {
            course = _coursesService.CreateCourse(course);
            return Ok(WrapToResponse(course));
        }
    }
}