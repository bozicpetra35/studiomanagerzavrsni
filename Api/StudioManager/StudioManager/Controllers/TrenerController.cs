using Microsoft.AspNetCore.Mvc;
using StudioManager.Data;
using StudioManager.Models;

namespace StudioManager.Controllers
{

/// <summary>
    /// Kreirano za crud operacije s entitetom trener u bazi
    /// </summary>

    [ApiController]
    [Route("api/v1/[controller]")]

    public class TrenerController : ControllerBase
    {

/// <summary>
        /// kontekst za rad s bazom postavljen koristeci Dependancy Injectionom
        /// </summary>

        private readonly StudioManagerContext _context;

        public TrenerController(StudioManagerContext context)
        {
            _context = context;
        }

  /// <summary>Pregled svih trenera u bazi</summary>
        ///<returns>Treneri u bazi</returns>
        ///<response code = "200" > Sve OK, ako nema podataka content-length: 0 </response>
        /// <response code="400">Zahtjev nije valjan</response>
        /// <response code="503">Baza na koju se spajamo nije dostupna</response>

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
                var lista = _context.Treneri.ToList();
                if (lista == null || lista.Count == 0)
                {
                    return new EmptyResult();
                }
                return new JsonResult(lista);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }
        }

/// <summary>
        /// Dodajemo novog trenera s generiranom šifrom
        /// </summary>
        /// <param name="trener">Trener za unos  u json formatu</param>
        /// <returns>Novi trener s generiranom šifrom</returns>
        /// 
        /// <response code="200">Trener je kreiran</response>
        /// <response code="400">Zahtjev nije valjan</response>
        /// <response code="503">Baza nije dostupna</response> 

        [HttpPost]
        public IActionResult Post(Trener entitet)
        {
            if (!ModelState.IsValid || entitet == null)
            {
                return BadRequest();
            }
            try
            {
                _context.Treneri.Add(entitet);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, entitet);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }
        }

/// <summary>
        /// Mijenjamo podatke već postojećeg trenera iz baze
        /// </summary>
        /// <param name="sifra">Šifra trenera kojeg želimo promjeniti</param>  
        /// <param name="trener">Trener za unos u JSON formatu</param>  
        /// <returns>Svi poslani podaci o treneru spremljeni su u bazi</returns>
        /// <response code="200">Sve je u redu</response>
        /// <response code="204">U bazi ne postoji trener kojeg želite promjeniti</response>
        /// <response code="415">Nismo poslali JSON</response> 
        /// <response code="503">Baza nedostupna</response> 
        ///ima rutu jer moramo znat šifru elementa kojeg mjenjamo


        [HttpPut]
        [Route("{sifra:int}")]
        public IActionResult Put(int sifra, Trener entitet)
        {
            if (sifra <= 0 || !ModelState.IsValid || entitet == null)
            {
                return BadRequest();
            }


            try
            {


                var entitetIzBaze = _context.Treneri.Find(sifra);

                if (entitetIzBaze == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, sifra);
                }


                // inače ovo rade mapperi,sada ručno

                entitetIzBaze.Ime = entitet.Ime;
                entitetIzBaze.Prezime = entitet.Prezime;
                entitetIzBaze.Oib = entitet.Oib;
                entitetIzBaze.Telefon = entitet.Telefon;
                entitetIzBaze.Iban = entitet.Iban;

                _context.Treneri.Update(entitetIzBaze);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, entitetIzBaze);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }

        }

/// <summary>
        /// Brisanje trenera iz baze
        /// </summary>
        /// <response code="200">OK</response>

        [HttpDelete]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int sifra)
        {
            if (!ModelState.IsValid || sifra <= 0)
            {
                return BadRequest();
            }

            try
            {
                var entitetIzbaze = _context.Treneri.Find(sifra);

                if (entitetIzbaze == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, sifra);
                }

                _context.Treneri.Remove(entitetIzbaze);
                _context.SaveChanges();

                return new JsonResult(new { poruka = "Obrisano" }); // ovo nije baš najbolja praksa ali da znake kako i to može

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }

        }



    }
}
