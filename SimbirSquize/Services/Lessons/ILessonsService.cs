using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimbirSquize.Data.Testing;

namespace SimbirSquize.Services.Lessons
{
    public interface ILessonsService
    {
        Task<List<Lesson>> GetLessons(Guid? courseId);

        Lesson CreateLesson(Lesson lesson);
    }
}