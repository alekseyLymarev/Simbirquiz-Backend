using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimbirSquize.Data.Testing;

namespace SimbirSquize.Services.Courses
{
    public class CoursesService : ICoursesService
    {
        private readonly TestingContext _db;

        public CoursesService(TestingContext db)
        {
            _db = db;
        }

        public async Task<List<Course>> GetAllCourses()
        {
            return await _db.Courses.ToListAsync();
        }

        public async Task<Course> GetCourseById(Guid id)
        {
            return await _db.Courses.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public Course CreateCourse(Course course)
        {
            course.Id = new Guid();
            _db.Courses.Add(course);
            _db.SaveChanges();

            return course;
        }
    }
}