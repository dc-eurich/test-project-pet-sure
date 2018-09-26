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
        public IActionResult ClaimPet([FromBody] IList<PetClaimModel> petClaimModels)
        {
            // This will be refactored to be handled by batch insert
            foreach(var petClaimModel in petClaimModels)
            {
                var isClaimed = _claimService.ProcessClaim(petClaimModel.PetId, petClaimModel.InvoiceId);
            }

            return Ok();
        }
    }
}