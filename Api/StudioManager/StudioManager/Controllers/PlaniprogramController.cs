using Azure;
using Microsoft.AspNetCore.Mvc;
using StudioManager.Data;
using System.Runtime.Intrinsics.X86;

namespace StudioManager.Controllers
{

/// <summary>
    /// kreiramo za crud operacije s entitetom plan i program u bazi
    /// </summary>


    [ApiController]
    [Route("api/v1/[controller]")]
    public class PlaniprogramController : ControllerBase
    {

/// <summary>
/// kontekst za rad s bazom postavljen koristeci Dependancy Injectionom
/// </summary>

        private readonly StudioManagerContext _context;

        public PlaniprogramController(StudioManagerContext context)
        {
        _context = context;
        }

/// <summary>Dohvaća sve smjerove iz baze</summary>
        ///<returns>Smjerovi u bazi</returns>
        ///<response code = "200" > Sve OK, ako nema podataka content-length: 0 </response>
        /// <response code="400">Zahtjev nije valjan</response>
        /// <response code="503">Baza na koju se spajam nije dostupna</response>

        [HttpGet]

        public IActionResult Get()
        {
            // kontrola ukoliko upit nije valjan

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var planiprogrami = _context.Planiprogrami.ToList();
                if (planiprogrami == null || planiprogrami.Count == 0)
                {
                    return new EmptyResult();
                }
                return new JsonResult(planiprogrami);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }
        }


    }
}

