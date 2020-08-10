using Microsoft.AspNetCore.Cors;
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

        [HttpGet]
        [Produces(typeof(List<TeamDTO>))]
        public List<TeamDTO> Get() 
        {
            List<TeamDTO> retour = new List<TeamDTO>();
            retour = _logic.ListActive();
            return retour;
        }

        [HttpGet("{id}")]
        public TeamDTO GetById(int id)
        {
            TeamDTO retour = new TeamDTO();
            retour = _logic.GetById(id);
            return retour;
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        //modification d'entité avec fourniture de l'Id obligatoire
        public ActionResult<TeamDTO> Post([FromBody] TeamDTO objet)
        {
            if (ModelState.IsValid && objet.Id.HasValue)
            {
                try
                {
                    TeamDTO resultat = _logic.Create(objet);
                    return resultat;
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return BadRequest("TeamDTO invalide");
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
                    return null;
                }
            }
            else
            {
                return BadRequest("TeamDTO invalide");
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
                    return null;
                }
            }
            else
            {
                return BadRequest("id invalide");
            }
        }
    }
}
