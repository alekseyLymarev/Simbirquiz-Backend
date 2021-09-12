using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SimbirSquize.Data;
using SimbirSquize.Data.Dtos;
using SimbirSquize.Data.Testing;
using SimbirSquize.Services.Questions;

namespace SimbirSquize.Controllers
{
    [Route("api/v1/questions")]
    public class QuestionsController : AbstractController
    {

        private readonly IQuestionsService _questionsService;
        private readonly UserManager<ApplicationUser> _userManager;

        public QuestionsController(IQuestionsService questionsService, UserManager<ApplicationUser> userManager)
        {
            _questionsService = questionsService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetQuestions([FromQuery] Guid? courseId)
        {
            var questions = await _questionsService.GetQuestions(courseId);

            return Ok(WrapToResponse(questions));
        }

        [HttpPost("score")]
        public async Task<IActionResult> CreatesSCore([FromBody] ScoreDto score)
        {
            var userId = new Guid("0fed4347-eeb7-4333-b173-bc476876e034");
            var scoreData = _questionsService.CreateScore(score, userId);
            return Ok(WrapToResponse(scoreData));
        }
        
        [HttpGet("scores")]
        public async Task<IActionResult> GetScores()
        {
            var userId = new Guid("0fed4347-eeb7-4333-b173-bc476876e034");
            var scoreData = _questionsService.GetScores(userId);
            return Ok(WrapToResponse(scoreData));
        }

        [HttpPost]
        public IActionResult CreateQuestion([FromBody] QuestionDto questionDto)
        {
            var question = _questionsService.CreateQuestion(questionDto);
            return Ok(WrapToResponse(question));
        }
    }
}