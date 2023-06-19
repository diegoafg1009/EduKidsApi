using EduKidsApi.Core;
using EduKidsApi.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EduKidsApi.Controllers;

[Route("api/Topics")]
[ApiController]
public class TopicController: ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    public TopicController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // GET: api/Topics/
    [HttpGet]
    public async Task<ActionResult<List<TopicDto>>> GetTopicsByMatterId([FromQuery] FilterTopicDto model)
    {
        var topics = await _unitOfWork.Topics.GetWithFiltersAsync(model);
        return Ok(topics);
    }
}