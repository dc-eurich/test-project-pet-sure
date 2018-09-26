using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace PetSure.Controllers
{
    public class ClaimsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}