using EduKidsApi.Core;
using EduKidsApi.Data;
using EduKidsApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace EduKidsApi.Controllers
{
    public class ResponseDetailController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public ResponseDetailController(ApplicationDbContext context)
        {
            _unitOfWork = new UnitOfWork(context);
        }

        [HttpGet("{responseId:Guid}")]
        public async Task<ActionResult<List<ResponseDetail>>> GetResponseDetailsByResponse(Guid responseId)
        {
            return Ok(await _unitOfWork.ResponseDetails.GetByResponseId(responseId));
        }
    }
}
