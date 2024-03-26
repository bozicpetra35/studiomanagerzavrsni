using StudioManager.Data;
using StudioManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace EdunovaAPP.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class VjezbacController : ControllerBase
    {

        private readonly StudioManagerContext _context;


        public VjezbacController(StudioManagerContext context)
        {
            _context = context;

        }


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
                var lista = _context.Vjezbaci.ToList();
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

        [HttpGet]
        [Route("{sifra:int}")]
        public IActionResult GetBySifra(int sifra)
        {
            // kontrola ukoliko upit nije valjan
            if (!ModelState.IsValid || sifra <= 0)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var p = _context.Vjezbaci.Find(sifra);
                if (p == null)
                {
                    return new EmptyResult();
                }
                return new JsonResult(p);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }
        }


        [HttpPost]
        public IActionResult Post(Vjezbac entitet)
        {
            if (!ModelState.IsValid || entitet == null)
            {
                return BadRequest();
            }
            try
            {
                _context.Vjezbaci.Add(entitet);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, entitet);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }
        }


        [HttpPut]
        [Route("{sifra:int}")]
        public IActionResult Put(int sifra, Vjezbac entitet)
        {
            if (sifra <= 0 || !ModelState.IsValid || entitet == null)
            {
                return BadRequest();
            }


            try
            {


                var entitetIzBaze = _context.Vjezbaci.Find(sifra);

                if (entitetIzBaze == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, sifra);
                }


                // inače ovo rade mapperi
                // za sada ručno
                entitetIzBaze.Ime = entitet.Ime;
                entitetIzBaze.Prezime = entitet.Prezime;
                entitetIzBaze.Telefon = entitet.Telefon;
                entitetIzBaze.BrojUpisnogLista = entitet.BrojUpisnogLista;

                _context.Vjezbaci.Update(entitetIzBaze);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, entitetIzBaze);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }

        }


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
                var entitetIzbaze = _context.Vjezbaci.Find(sifra);

                if (entitetIzbaze == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, sifra);
                }

                _context.Vjezbaci.Remove(entitetIzbaze);
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