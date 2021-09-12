using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimbirSquize.Data.Testing;

namespace SimbirSquize.Services.Courses
{
    public interface ICoursesService
    {
        Task<List<Course>> GetAllCourses();

        Task<Course> GetCourseById(Guid id);

        Course CreateCourse(Course course);
    }
}