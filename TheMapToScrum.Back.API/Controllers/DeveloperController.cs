using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TheMapToScrum.Back.BLL.Interfaces;
using TheMapToScrum.Back.DTO;

namespace UserStoryWebAPI2.Controllers
{

    //[Authorize]    
    [Produces("application/json")]
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    public class DeveloperController : Controller
    {
        private readonly IDeveloperLogic _logic;

        public DeveloperController(IDeveloperLogic logic)
        {
            _logic = logic;
        }


        // Statuscode 500 = erreur serveur
        // les exceptions seront loggees
        [HttpGet]
        [Produces(typeof(List<DeveloperDTO>))]
        public ActionResult<List<DeveloperDTO>> get()
        {
            try
            {
                List<DeveloperDTO> retour = new List<DeveloperDTO>();
                retour = _logic.ListActive();
                return retour;
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
        }


        [HttpGet("{id}")]
        public ActionResult<DeveloperDTO> GetById(int id)
        {
            try
            {
                DeveloperDTO retour = new DeveloperDTO();
                retour = _logic.GetById(id);
                return retour;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]

        public ActionResult<DeveloperDTO> Post([FromBody] DeveloperDTO objet)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DeveloperDTO resultat = _logic.Create(objet);
                    return resultat;
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex);
                }
            }
            else
            {
                return BadRequest("Invalid DeveloperDTO ModelState: failed to POST");
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        //modification d'entité avec fourniture de l'Id obligatoire
        public ActionResult<DeveloperDTO> Put([FromBody] DeveloperDTO objet)
        {
            if (ModelState.IsValid && objet.Id.HasValue)
            {
                try
                {
                    DeveloperDTO resultat = _logic.Update(objet);
                    return resultat;
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex);
                }
            }
            else
            {
                return BadRequest("Invalid DeveloperDTO ModelState: failed to PUT");
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<bool> Delete(int? Id)
        {
            if (Id.HasValue)
            {
                try
                {
                    bool resultat = _logic.Delete((int)Id);
                    return resultat;
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex);
                }
            }
            else
            {
                return BadRequest("Invalid DeveloperDTO ModelState: failed to DELETE");
            }
        }



    }
}
