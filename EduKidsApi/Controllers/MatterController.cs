using EduKidsApi.Core;
using EduKidsApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace EduKidsApi.Controllers
{
    [Route("api/Matters")]
    [ApiController]
    public class MatterController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public MatterController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Matters
        [HttpGet]
        public async Task<ActionResult<List<Matter>>> GetMatters()
        {
            return Ok(await _unitOfWork.Matters.GetAllAsync());
        }
    }
}
