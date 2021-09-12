using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimbirSquize.Data;
using SimbirSquize.Data.Dtos;
using SimbirSquize.Data.Testing;

namespace SimbirSquize.Services.Questions
{
    public class QuestionService : IQuestionsService
    {
        private TestingContext _db;

        public QuestionService(TestingContext db)
        {
            _db = db;
        }

        public async Task<List<Dictionary<string, string>>> GetQuestions(Guid? courseId)
        {
            var list = new List<Dictionary<string, string>>();
            var questions = _db.Questions.AsQueryable();

            if (courseId != null)
            {
                questions = questions.Where(q => q.CourseId.Equals(courseId));
            }

            var answers = await _db.TestAnswer.Where(x => questions.Select(x => x.Id).Contains(x.QuestionId))
                .ToListAsync();

            foreach (var question in questions.ToList())
            {
                var questionDict = new Dictionary<string, string>();
                questionDict.Add("text", question.QuestionText);
                questionDict.Add("RightAnswer", question.RightAnswerId);
                var questionAnswers = answers.Where(x => x.QuestionId == question.Id);

                foreach (var answer in questionAnswers)
                {
                    questionDict.Add("option" + answer.Id, answer.Text);
                }
                list.Add(questionDict);
            }


            return list;
        }

        public Question CreateQuestion(QuestionDto questionDto)
        {
            var question = new Question
            {
                Id = new Guid(),
                CourseId = questionDto.CourseId,
                QuestionText = questionDto.Text,
                RightAnswerId = questionDto.RightOption
            };
            _db.Questions.Add(question);
            _db.SaveChanges();

            if (questionDto.OptionA != null)
            {
                CreateAnswer(questionDto.OptionA, "A", question.Id);
            }

            if (questionDto.OptionB != null)
            {
                CreateAnswer(questionDto.OptionB, "B", question.Id);
            }

            if (questionDto.OptionC != null)
            {
                CreateAnswer(questionDto.OptionA, "C", question.Id);
            }

            if (questionDto.OptionD != null)
            {
                CreateAnswer(questionDto.OptionD, "D", question.Id);
            }

            return question;
        }

        public Score CreateScore(ScoreDto scoreDto, Guid userId)
        {
            var score = new Score
            {
                CourseId = scoreDto.CourseId,
                ScoreId = scoreDto.Score,
                RightCount = scoreDto.RightCount,
                UserId = userId
            };
            _db.Scores.Add(score);
            _db.SaveChanges();

            return score;
        }

        public async Task<List<Score>> GetScores(Guid userId)
        {
            var scores = _db.Scores.Where(x => x.UserId.Equals(userId));
            return await scores.ToListAsync();
        }


        private TestAnswer CreateAnswer(string answerText, string optionId, Guid questionId)
        {
            var answer = new TestAnswer
            {
                Text = answerText,
                Id = optionId,
                QuestionId = questionId
            };
            _db.TestAnswer.Add(answer);
            _db.SaveChanges();

            return answer;
        }
    }
}