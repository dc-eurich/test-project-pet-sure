using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace PetManagement.Controllers
{
    [Route("api/pets")]
    [ApiController]
    public class PetManagementController : ControllerBase
    {
        private readonly IPetManagementService _petManagementService;
        public PetManagementController(IPetManagementService petManagementService)
        {
            _petManagementService = petManagementService;
        }

        [Produces("application/json")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_petManagementService.Get());
        }
    }
}