using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimbirSquize.Data.Testing;

namespace SimbirSquize.Services.Lessons
{
    public class LessonService : ILessonsService
    {
        private readonly TestingContext _db;

        public LessonService(TestingContext db)
        {
            _db = db;
        }

        public async Task<List<Lesson>> GetLessons(Guid? courseId)
        {
            var lessons = _db.Lessons.AsQueryable();

            if (courseId != null)
            {
                lessons = lessons.Where(l => l.CourseId.Equals(courseId));
            }

            return await lessons.ToListAsync();
        }

        public Lesson CreateLesson(Lesson lesson)
        {
            lesson.Id = new Guid();
            _db.Lessons.Add(lesson);
            _db.SaveChanges();

            return lesson;
        }
    }
}