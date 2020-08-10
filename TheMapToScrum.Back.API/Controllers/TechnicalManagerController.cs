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
    public class TechnicalManagerController : Controller
    {
        private readonly ITechnicalManagerLogic _logic;

        public TechnicalManagerController(ITechnicalManagerLogic logic) 
        {
            _logic = logic;
        }

        [HttpGet]
        [Produces(typeof(List<TechnicalManagerDTO>))]
        public List<TechnicalManagerDTO> Get()
        {
            List<TechnicalManagerDTO> retour = new List<TechnicalManagerDTO>();
            retour = _logic.List();
            return retour;
        }

        [HttpGet("{id}")]
        public TechnicalManagerDTO GetById(int id)
        {
            TechnicalManagerDTO retour = new TechnicalManagerDTO();
            retour = _logic.GetById(id);
            return retour;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<TechnicalManagerDTO> Post([FromBody] TechnicalManagerDTO objet)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TechnicalManagerDTO resultat = _logic.Create(objet);
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

        public ActionResult<TechnicalManagerDTO> Put([FromBody] TechnicalManagerDTO objet)
        {
            if (ModelState.IsValid && objet.Id.HasValue)
            {
                try
                {
                    TechnicalManagerDTO resultat = _logic.Update(objet);
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
