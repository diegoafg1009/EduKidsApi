using EduKidsApi.Core;
using EduKidsApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace EduKidsApi.Controllers
{
    public class QuestionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public QuestionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Questions
        [HttpGet("{topicId:Guid}")]
        public async Task<ActionResult<List<Question>>> GetQuestionsByTopic(Guid topicId)
        {
            return Ok(await _unitOfWork.Questions.GetByTopicIdWithAlternatives(topicId));
        }

        // GET: api/GeneralQuestionnaire
        [HttpGet("GeneralQuestionnaire")]
        public async Task<ActionResult<List<Question>>> GetGeneralQuestionnaire()
        {
            return Ok(await _unitOfWork.Questions.GetQuestionsPerTopic());
        }
    }
}
