﻿using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TheMapToScrum.Back.BLL.Interfaces;
using TheMapToScrum.Back.DTO;

namespace TheMapToScrum.Back.Controllers
{
    //[Authorize]    
    [Produces("application/json")]
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    public class TeamController : Controller
    {
        private readonly ITeamLogic _logic;

        public TeamController(ITeamLogic logic) 
        {
            _logic = logic;
        }


        // Statuscode 500 = erreur serveur
        // les exceptions seront loggees
        [HttpGet]
        [Produces(typeof(List<TeamDTO>))]
        public ActionResult<List<TeamDTO>> Get() 
        {
            try
            {
                List<TeamDTO> retour = new List<TeamDTO>();
                retour = _logic.ListActive();
                return retour;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<TeamDTO> GetById(int id)
        {
            try
            {
                TeamDTO retour = new TeamDTO();
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
        //modification d'entité avec fourniture de l'Id obligatoire
        public ActionResult<TeamDTO> Post([FromBody] TeamDTO objet)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TeamDTO resultat = _logic.Create(objet);
                    return resultat;
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex);
                }
            }
            else
            {
                return BadRequest("Invalid TeamDTO Model: failed to DELETE");
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        //modification d'entité avec fourniture de l'Id obligatoire
        public ActionResult<TeamDTO> Put([FromBody] TeamDTO objet)
        {
            if (ModelState.IsValid && objet.Id.HasValue)
            {
                try
                {
                    TeamDTO resultat = _logic.Update(objet);
                    return resultat;
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex);
                }
            }
            else
            {
                return BadRequest("Invalid TeamDTO Model: failed to PUT");
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
                return BadRequest("Invalid TeamDTO Id: failed to DELETE");
            }
        }
    }
}
