using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimbirSquize.Data;
using SimbirSquize.Data.Dtos;
using SimbirSquize.Data.Testing;

namespace SimbirSquize.Services.Questions
{
    public interface IQuestionsService
    {
        Task<List<Dictionary<string, string>>> GetQuestions(Guid? courseId);

        Question CreateQuestion(QuestionDto question);

        Score CreateScore(ScoreDto scoreDto, Guid userId);

        Task<List<Score>> GetScores(Guid userId);
    }
}