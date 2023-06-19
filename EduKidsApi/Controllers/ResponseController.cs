using System.Security.Claims;
using EduKidsApi.Core;
using EduKidsApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace EduKidsApi.Controllers;

[Route("api/Responses")]
[ApiController]
public class ResponseController: ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    public ResponseController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    // GET: api/Responses
    public async Task<ActionResult<List<Response>>> GetResponses()
    {
        return Ok(await _unitOfWork.Responses.GetAllAsync());
    }

    // POST: api/Responses
    [HttpPost]
    public async Task<ActionResult<Response>> PostResponse(List<ResponseDetail> responseDetails)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var response = new Response
        {
            UserId = Guid.Parse(userId),
            Date = DateTime.Now,
            Score = CalculateScore(responseDetails),
            ResponseDetails = responseDetails
        };
        await _unitOfWork.Responses.CreateAsync(response);
        await _unitOfWork.CommitAsync();

        return Ok();
    }

    private static int CalculateScore(List<ResponseDetail> responseDetails)
    {
        var score = 0;
        foreach (var responseDetail in responseDetails)
        {
            if (responseDetail.Alternative.IsCorrect)
            {
                score += 1;
            }
        }

        return score;
    }
}