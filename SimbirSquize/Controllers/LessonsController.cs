using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimbirSquize.Data.Testing;
using SimbirSquize.Services.Lessons;

namespace SimbirSquize.Controllers
{
    [Route("api/v1/lessons")]
    public class LessonsController : AbstractController
    {
        private ILessonsService _lessonsService;
        private TestingContext _db;

        public LessonsController(ILessonsService lessonsService, TestingContext db)
        {
            _lessonsService = lessonsService;
            _db = db;
        }

        [HttpGet()]
        public IActionResult GetLessons([FromQuery] Guid? courseId)
        {
            var lessons = _db.Lessons.AsQueryable();
            if (courseId != null)
            {
                lessons = lessons.Where(x => x.CourseId.Equals(courseId));
            }

            return Ok(WrapToResponse(lessons.ToListAsync()));
        }

        [HttpPost()]
        public IActionResult CreateLesson([FromBody] Lesson lesson)
        {
            _lessonsService.CreateLesson(lesson);
            return Ok(WrapToResponse(lesson));
        }
    }
}