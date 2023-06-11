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

    // GET: api/Topics/{matterId}
    [HttpGet("{matterId:guid}")]
    public async Task<ActionResult<List<TopicDto>>> GetTopicsByMatterId(Guid matterId)
    {
        return Ok(await _unitOfWork.Topics.GetByMatterIdAsync(matterId));
    }
}