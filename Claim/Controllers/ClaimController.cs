using Claim.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.Collections.Generic;

namespace Claim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimController : ControllerBase
    {
        private readonly IClaimService _claimService;
        public ClaimController(IClaimService claimService)
        {
            _claimService = claimService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_claimService.Get());
        }

        [HttpPost]
        public IActionResult ClaimPet([FromBody] PetClaimModel petClaimModel)
        {
            var isClaimed = _claimService.ProcessClaim(petClaimModel.PetId, petClaimModel.InvoiceId);
            return Ok();
        }
    }
}