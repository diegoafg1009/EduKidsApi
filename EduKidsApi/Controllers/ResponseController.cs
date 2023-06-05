using EduKidsApi.Core;
using EduKidsApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace EduKidsApi.Controllers
{
    [Route("api/Responses")]
    [ApiController]
    public class ResponseController: ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ResponseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // POST: api/Responses
        [HttpPost]
        public async Task<ActionResult<Response>> PostResponse(Response response)
        {
            await _unitOfWork.Responses.CreateAsync(response);
            await _unitOfWork.CommitAsync();

            return Ok();
        }
    }
}
