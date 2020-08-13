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
    public class ScrumMasterController : Controller
    {
        private readonly IScrumMasterLogic _logic;

        public ScrumMasterController(IScrumMasterLogic logic) 
        {
            _logic = logic;
        }

        [HttpGet]
        [Produces(typeof(List<ScrumMasterDTO>))]
        public List<ScrumMasterDTO> Get()
        {
            List<ScrumMasterDTO> retour = new List<ScrumMasterDTO>();
            retour = _logic.ListActive();
            return retour;
        }

        [HttpGet("{id}")]
        public ScrumMasterDTO GetById(int id)
        {
            ScrumMasterDTO retour = new ScrumMasterDTO();
            retour = _logic.GetById(id);
            return retour;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<ScrumMasterDTO> Post([FromBody] ScrumMasterDTO objet)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ScrumMasterDTO resultat = _logic.Create(objet);
                    return resultat;
                }
                catch 
                {
                    return null;
                }
            }
            else 
            {
                return BadRequest("TechnicalManagerDTO invalide, Is the model Valid???");
            }
        }

        //modification d'entité avec fourniture de l'Id obligatoire
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status202Accepted)]

        public ActionResult<ScrumMasterDTO> Put([FromBody] ScrumMasterDTO objet)
        {
            if (ModelState.IsValid && objet.Id.HasValue)
            {
                try
                {
                    ScrumMasterDTO resultat = _logic.Update(objet);
                    return resultat;
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return BadRequest("TechnicalManagerDTO invalide");
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
