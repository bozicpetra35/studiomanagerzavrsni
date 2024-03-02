using Azure;
using Microsoft.AspNetCore.Mvc;
using StudioManager.Data;
using StudioManager.Models;
using System.Runtime.Intrinsics.X86;

namespace StudioManager.Controllers
{

/// <summary>
    /// Kreirano za crud operacije s entitetom plan i program u bazi
    /// </summary>


    [ApiController]
    [Route("api/v1/[controller]")]

    public class PlaniprogramController : ControllerBase
    {

/// <summary>
/// kontekst za rad s bazom postavljen koristeci Dependancy Injectionom
/// </summary>

        private readonly StudioManagerContext _context;

//D.I. je privatno svojstvo dodjeljeno korištenjem konstruktora

        public PlaniprogramController(StudioManagerContext context)
        {
        _context = context;
        }

/// <summary>Pregled svih programa u bazi</summary>
        ///<returns>Smjerovi u bazi</returns>
        ///<response code = "200" > Sve OK, ako nema podataka content-length: 0 </response>
        /// <response code="400">Zahtjev nije valjan</response>
        /// <response code="503">Baza na koju se spajamo nije dostupna</response>

        [HttpGet]

        public IActionResult Get()
        {
            // kontrola valjanosti upita

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


/// <summary>
        /// Dodajemo novi program (plan i program u bazi)
        /// </summary>
        /// <param name="planiprogram">Smjer za unos  u json formatu</param>
        /// <returns>Novi program s generiranom šifrom</returns>
        /// 
        /// <response code="200">Program je kreiran</response>
        /// <response code="400">Zahtjev nije valjan</response>
        /// <response code="503">Baza nije dostupna</response> 


        [HttpPost]

        public IActionResult Post (Planiprogram planiprogram)
        {
            if (!ModelState.IsValid || planiprogram == null)
            {
                return BadRequest();
            }
            try
            {
                _context.Planiprogrami.Add(planiprogram);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, planiprogram);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }
        }



/// <summary>
        /// Mijenjamo podatke već postojećeg plana i programa iz baze
        /// </summary>
        /// <param name="sifra">Šifra programa kojeg želimo promjeniti</param>  
        /// <param name="program">Program za unos u JSON formatu</param>  
        /// <returns>Svi poslani podaci programa spremljeni u bazi</returns>
        /// <response code="200">Sve je u redu</response>
        /// <response code="204">U bazi ne postoji program kojeg želite promjeniti</response>
        /// <response code="415">Nismo poslali JSON</response> 
        /// <response code="503">Baza nedostupna</response> 
        ///ima rutu jer moramo znat šifru elementa kojeg mjenjamo

        [HttpPut]
        [Route("{sifra:int}")]



        public IActionResult Put (int sifra, Planiprogram planiprogram)
        {
            if (sifra <= 0 || !ModelState.IsValid || planiprogram == null)
            {
                return BadRequest();
            }


            try
            {


                var planiprogramizBaze = _context.Planiprogrami.Find(sifra);

                if (planiprogramizBaze == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, sifra);
                }

//ovo inace rade maperi, ali sada smo napravili rucno

                planiprogramizBaze.Naziv = planiprogram.Naziv;
                planiprogramizBaze.TjednaSatnica = planiprogram.TjednaSatnica;
                planiprogramizBaze.Cijena = planiprogram.Cijena;
                planiprogramizBaze.Trener = planiprogram.Trener;
        

                _context.Planiprogrami.Update(planiprogramizBaze);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, planiprogramizBaze);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }

        }


    }
}

