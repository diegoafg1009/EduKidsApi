using EduKidsApi.Core;
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
    }
}
