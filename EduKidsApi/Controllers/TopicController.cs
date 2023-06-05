using EduKidsApi.Core;
using EduKidsApi.Dtos;
using EduKidsApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Security;

namespace EduKidsApi.Controllers
{
    [Route("api/Topics")]
    [ApiController]
    public class TopicController: ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public TopicController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Topics/{materrId}
        [HttpGet("{matterId}")]
        public async Task<ActionResult<List<TopicDto>>> GetTopicsByMatterId(Guid matterId)
        {
            return Ok(await _unitOfWork.Topics.GetByMatterIdAsync(matterId));
        }
    }
}
