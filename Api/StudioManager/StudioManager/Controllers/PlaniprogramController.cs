﻿using Azure;
using Microsoft.AspNetCore.Mvc;
using StudioManager.Data;
using StudioManager.Extensions;
using StudioManager.Models;
using StudioManager.Models.EdunovaAPP.Models;
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
        ///<returns>Plan i programi u bazi</returns>
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
                return new JsonResult(planiprogrami.MapPlaniprogramReadList());
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
                var planiprogram = _context.Planiprogrami.Find(sifra);
                if (planiprogram == null)
                {
                    return new EmptyResult();
                }
                return new JsonResult(planiprogram.MapPlaniprogramInsertUpdateToDTO());
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

        public IActionResult Post (PlaniprogramDTOInsertUpdate planiprogramDTO)
        {
            if (!ModelState.IsValid || planiprogramDTO == null)
            {
                return BadRequest();
            }
            try
            {
                var planiprogram = planiprogramDTO.MapPlaniprogramInsertUpdateFromDTO(new Planiprogram());
                _context.Planiprogrami.Add(planiprogram);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, planiprogram.MapPlaniprogramReadToDTO());
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



        public IActionResult Put (int sifra, PlaniprogramDTOInsertUpdate planiprogramDTO)
        {
            if (sifra <= 0 || !ModelState.IsValid || planiprogramDTO == null)
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



                //kaze da ovo nije dobro

                var planiprogram = planiprogramDTO.MapPlaniprogramInsertUpdateFromDTO(planiprogramizBaze);
                planiprogram.Sifra = sifra;

                _context.Planiprogrami.Update(planiprogram);
                _context.SaveChanges();

                //------------------------------------------------------

                return StatusCode(StatusCodes.Status200OK, planiprogram.MapPlaniprogramReadToDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }

        }


        /// <summary>
        /// Brisanje programa iz baze
        /// </summary>
        /// <response code="200">Sve je u redu</response>

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
                var planiprogramizBaze = _context.Planiprogrami.Find(sifra);

                if (planiprogramizBaze == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, sifra);
                }

                _context.Planiprogrami.Remove(planiprogramizBaze);
                _context.SaveChanges();

                return new JsonResult("{\"poruka\":\"Obrisano\"}"); 

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }

        }







    }
}

